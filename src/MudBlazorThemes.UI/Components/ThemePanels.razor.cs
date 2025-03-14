using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Utilities;
using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.UI.Components
{
    public partial class ThemePanels : ComponentBase
    {
        private List<ThemeOption> themeOptions = [];
        public List<ThemePalette> themePalettes = [];
        public List<ThemeSelection> themeSelections = [];
        public List<CustomShadow> customShadows = [];
        public List<CustomLayoutProperty> customLayouts = [];
        public List<CustomTypography> customTypographies = [];
        public List<CustomZIndex> customZIndexes = [];
        private List<string> _typoList = [];
        private int _typoValue = 0;
        private int _currentShadowIndex = 0;
        private readonly int _defaultThemeId = 1;
        private string _searchString = string.Empty;
        private bool _isLoading = true;

        private Dictionary<string, bool> panelDictionary = [];
        private bool shouldFilter = false;

        [CascadingParameter(Name = "IsDarkTheme")]
        public bool IsDarkTheme { get; set; }

        [Parameter]
        public string SearchString { get; set; } = string.Empty;

        private static List<string> GetAvailableFonts()
        {
            return [
                "Arial", "Helvetica", "Times New Roman", "Times", "Courier New", "Courier",
                "Verdana", "Georgia", "Palatino", "Garamond", "Bookman", "Comic Sans MS",
                "Trebuchet MS", "Arial Black", "Impact"
                   ];
        }

        public void SearchAllPanels(string val)
        {
            _searchString = val;
            shouldFilter = !string.IsNullOrWhiteSpace(val) && val.Length >= 2;
            var comparison = StringComparison.OrdinalIgnoreCase;

            if (shouldFilter)
            {
                // Get matching theme selections for ThemePalettes
                var matchingThemeSelections = themeSelections
                    .Where(t => t.ThemeName.Contains(val, comparison))
                    .Select(t => t.Id)
                    .ToHashSet();

                // Get matching custom items for ThemeOptions
                var matchingCustomItems = new Dictionary<int, bool>();
                foreach (var option in themeOptions)
                {
                    bool hasMatchingItems = option.Name switch
                    {
                        "Shadows" => customShadows.Any(s => s.Name.Contains(val, comparison)),
                        "Layout Properties" => customLayouts.Any(l => l.Name.Contains(val, comparison)),
                        "Typography" => customTypographies.Any(t => t.Name.Contains(val, comparison)),
                        "ZIndex" => customZIndexes.Any(z => z.Name.Contains(val, comparison)),
                        _ => false
                    };
                    matchingCustomItems[option.Id] = hasMatchingItems;
                }

                // Update panel dictionary
                panelDictionary = panelDictionary.ToDictionary(
                    kvp => kvp.Key,
                    kvp =>
                    {
                        if (kvp.Key.StartsWith('p'))
                        {
                            // Handle ThemePalette panels
                            return matchingThemeSelections.Any(); // If any themes match, show palette
                        }
                        else if (kvp.Key.StartsWith('o'))
                        {
                            // Handle ThemeOption panels
                            int optionId = int.Parse(kvp.Key[1..]);
                            return matchingCustomItems.TryGetValue(optionId, out bool hasMatches) && hasMatches;
                        }
                        return false;
                    }
                );
            }
            else if (string.IsNullOrWhiteSpace(val))
            {
                // Reset all panels to collapsed state except the first when search is cleared
                panelDictionary = panelDictionary.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Key == "p1"
                );
            }
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            // different type of theme categories and light/dark mode palettes
            themeOptions = await ThemeService.GetActiveThemeOptionsAsync();
            themePalettes = await ThemeService.GetThemePalettesAsync();
            // create dictionaries
            foreach (var option in themeOptions)
            {
                panelDictionary.Add($"o{option.Id}", false);
            }
            await LoadDefaultThemeValues();
            ThemeState.OnChange += CssChanged;
            _isLoading = false;
        }

        private void CssChanged()
        {
            LoadSavedThemeData();
            StateHasChanged();
        }

        public void Dispose()
        {
            ThemeState.OnChange -= CssChanged;
        }

        #region Loading and Selecting Full Themes

        public async Task LoadDefaultThemeValues()
        {
            // just sets defaults so even if the Theme selected doesn't have every item thte Theme Creator will show every item.
            themeSelections = await ThemeService.GetThemeSelectionsAsync(_defaultThemeId);
            await ThemeState.UpdateThemeData(themeSelections, false);
            customShadows = await ThemeService.GetCustomShadowsAsync(_defaultThemeId);
            await ThemeState.UpdateThemeData(customShadows, false);
            customLayouts = await ThemeService.GetCustomLayoutsAsync(_defaultThemeId);
            await ThemeState.UpdateThemeData(customLayouts, false);
            customTypographies = await ThemeService.GetCustomTypographiesAsync(_defaultThemeId);
            await ThemeState.UpdateThemeData(customTypographies, false);
            customZIndexes = await ThemeService.GetCustomZIndexesAsync(_defaultThemeId);
            await ThemeState.UpdateThemeData(customZIndexes, false);
            _typoList = customTypographies
                .Select(t => t.TypoType)
                .Distinct()
                .ToList();
        }

        private void LoadSavedThemeData()
        {
            if (ThemeState.SelectedThemes.Any())
            {
                UpdateThemeListValues(
                    themeSelections,
                    ThemeState.SelectedThemes,
                    keySelector: item => item.ThemeName,
                    updateAction: (original, updated) =>
                    {
                        original.LightValue = updated.LightValue;
                        original.DarkValue = updated.DarkValue;
                    }
                );
            }
            if (ThemeState.SelectedLayouts.Any())
            {
                UpdateThemeListValues(
                    customLayouts,
                    ThemeState.SelectedLayouts,
                    keySelector: item => item.Name,
                    updateAction: (original, updated) =>
                    {
                        original.Default = updated.Default;
                    }
                );
            }
            if (ThemeState.SelectedTypographies.Any())
            {
                // custom linq statement to update the default value of the typography based on TypoType and Name
                customTypographies = customTypographies
                    .GroupJoin(ThemeState.SelectedTypographies,
                        original => new { original.TypoType, original.Name },
                        second => new { second.TypoType, second.Name },
                        (original, secondMatches) => new { original, secondMatch = secondMatches.FirstOrDefault() })
                    .Select(x =>
                    {
                        if (x.secondMatch != null)
                        {
                            x.original.Default = x.secondMatch.Default;
                        }
                        return x.original;
                    }).ToList();
            }
            if (ThemeState.SelectedZIndexes.Any())
            {
                UpdateThemeListValues(
                    customZIndexes,
                    ThemeState.SelectedZIndexes,
                    keySelector: item => item.Name,
                    updateAction: (original, updated) =>
                    {
                        original.Default = updated.Default;
                    }
                );
            }
        }

        private static void UpdateThemeListValues<T>(List<T> originalList, List<T> updatedList, Func<T, string> keySelector, Action<T, T> updateAction)
        {
            // generic linq statement to update the Func value of the theme class based on the keySelector
            foreach (var original in originalList)
            {
                var key = keySelector(original);
                var updatedItem = updatedList.FirstOrDefault(updated => keySelector(updated) == key);

                if (updatedItem != null)
                {
                    updateAction(original, updatedItem);
                }
            }
        }

        #endregion

        #region Setting values in theme state service
        private async Task SpinnerIndexChanged(int newVal)
        {
            _typoValue = newVal;
            await InvokeAsync(StateHasChanged);
        }

        private async Task ThemeColorChanged(int themeId, MudColor newColor, int paletteId)
        {
            bool isLight = paletteId == 1;
            var foundTheme = themeSelections.FirstOrDefault(x => x.Id == themeId);
            ArgumentNullException.ThrowIfNull(foundTheme); // should never be null.
            if (isLight)
            {
                foundTheme.LightValue = newColor.ToString(MudColorOutputFormats.HexA);
            }
            else
            {
                foundTheme.DarkValue = newColor.ToString(MudColorOutputFormats.HexA);
            }
            // update themestate
            await ThemeState.UpdateThemeData(themeSelections, true, true);
        }

        private async Task OnThemeDoubleChanged(double val, int themeId)
        {
            var foundTheme = themeSelections.FirstOrDefault(x => x.Id == themeId);
            ArgumentNullException.ThrowIfNull(foundTheme); // should never be null
            foundTheme.LightValue = val.ToString();
            foundTheme.DarkValue = val.ToString();
            // update themestate
            await ThemeState.UpdateThemeData(themeSelections, true, true);
        }

        private async Task TextItemChanged(int id, string text, string typo)
        {
            if (typo == "typo")
            {
                var foundTypoItem = customTypographies.FirstOrDefault(x => x.Id == id);
                ArgumentNullException.ThrowIfNull(foundTypoItem); // should never be null.
                foundTypoItem.Default = text;
                await ThemeState.UpdateThemeData(customTypographies, true, true);
            }
        }

        private async Task NumberItemChanged(int id, double newVal, string typo)
        {
            if (typo == "typo")
            {
                var foundTypoItem = customTypographies.FirstOrDefault(x => x.Id == id);
                ArgumentNullException.ThrowIfNull(foundTypoItem); // should never be null.
                foundTypoItem.Default = newVal.ToString();
                await ThemeState.UpdateThemeData(customTypographies, true, true);
            }
            else if (typo == "zindex")
            {
                var foundZItem = customZIndexes.FirstOrDefault(x => x.Id == id);
                ArgumentNullException.ThrowIfNull(foundZItem); // should never be null.
                foundZItem.Default = newVal.ToString();
                await ThemeState.UpdateThemeData(customZIndexes, true, true);
            }
        }

        private async Task LayoutPropertyChanged(int layoutId, int sliderValue)
        {
            var foundLayout = customLayouts.FirstOrDefault(x => x.Id == layoutId);
            ArgumentNullException.ThrowIfNull(foundLayout); // should never be null.
            foundLayout.Default = sliderValue;
            await ThemeState.UpdateThemeData(customLayouts, true, true);
        }

        private void HandleShadowKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "ArrowUp" && _currentShadowIndex > 0)
            {
                ChangeShadowIndex(-1);
            }
            else if (e.Key == "ArrowDown" && _currentShadowIndex < customShadows.Count - 1)
            {
                ChangeShadowIndex(1);
            }
        }

        private void ChangeShadowIndex(int delta)
        {
            _currentShadowIndex = Math.Clamp(_currentShadowIndex + delta, 0, customShadows.Count - 1);
        }

        #endregion
    }
}
