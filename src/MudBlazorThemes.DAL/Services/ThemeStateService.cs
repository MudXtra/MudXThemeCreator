using Blazored.LocalStorage;
using MudBlazorThemes.DAL.Interfaces;
using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.DAL.Services
{
    public class ThemeStateService(ILocalStorageService localService) : IThemeStateService
    {
        private readonly ILocalStorageService _localService = localService;
        public bool IsDarkMode { get; set; } = false;
        public bool IsInitialized { get; private set; } = false;
        public int ThemeId { get; set; }
        public bool IsModified { get; set; }
        public string ThemeName { get; set; } = string.Empty;
        public string ThemeOtherText { get; set; } = string.Empty;
        public List<ThemeSelection> SelectedThemes { get; private set; } = [];
        public List<CustomShadow> SelectedShadows { get; private set; } = [];
        public List<CustomLayoutProperty> SelectedLayouts { get; private set; } = [];
        public List<CustomTypography> SelectedTypographies { get; private set; } = [];
        public List<CustomZIndex> SelectedZIndexes { get; private set; } = [];
        public List<CustomTheme> CustomThemes { get; set; } = [];

        public event Action? OnChange;

        public void NotifyStateChanged() => OnChange?.Invoke();

        /// <summary>
        /// Initializes the ThemeStateService
        /// </summary>
        /// <returns>returns the LoadState task loading from Local Browser Storage</returns>
        public Task Initialize()
        {
            IsInitialized = true;
            return LoadState();
        }

        /// <summary>
        /// Updates the ThemeId for the service
        /// </summary>
        /// <param name="themeId">The ThemeId to store in the service</param>
        /// <param name="saveState">If true, saves the new themeId to local storage, Defaults to <c>true</c>.</param>
        /// <param name="notifyChanged">If true, notifies the public Action that a change has occured. Defaults to <c>false</c>.</param>
        public async Task UpdateThemeId(int themeId, bool saveState = true, bool notifyChanged = false)
        {
            ThemeId = themeId;
            if (themeId > 0)
            {
                ThemeName = CustomThemes.FirstOrDefault(x => x.Id == themeId)?.Name ?? string.Empty;
                ThemeOtherText = CustomThemes.FirstOrDefault(x => x.Id == themeId)?.OtherText ?? string.Empty;
            }
            if (saveState) await _localService.SetItemAsync("selectedThemeId", themeId);
            if (notifyChanged) NotifyStateChanged();
        }

        /// <summary>
        /// Updates the ThemeStateService with a list of data
        /// </summary>
        /// <typeparam name="T">The type of List Data to store</typeparam>
        /// <param name="data">The List<typeparamref name="T"/> of data.</param>
        /// <param name="saveState">If true, saves the new themeId to local storage, Defaults to <c>true</c>.</param>
        /// <param name="notifyChanged">If true, notifies the public Action that a change has occured. Defaults to <c>false</c>.</param>
        public async Task UpdateThemeData<T>(List<T> data, bool saveState = true, bool notifyChanged = false) where T : class
        {
            if (data == null || data is { Count: 0 })
            {
                throw new ArgumentException("Data List<T> cannot be empty.");
            }

            string key = typeof(T).Name;
            switch (key)
            {
                case nameof(ThemeSelection):
                    if (data is List<ThemeSelection> themeSelections)
                    {
                        SelectedThemes = themeSelections;
                        if (saveState) await _localService.SetItemAsync("selectedThemes", SelectedThemes);
                    }
                    break;
                case nameof(CustomShadow):
                    if (data is List<CustomShadow> customShadows)
                    {
                        SelectedShadows = customShadows;
                        if (saveState) await _localService.SetItemAsync("selectedShadows", SelectedShadows);
                    }
                    break;
                case nameof(CustomLayoutProperty):
                    if (data is List<CustomLayoutProperty> customLayouts)
                    {
                        SelectedLayouts = customLayouts;
                        if (saveState) await _localService.SetItemAsync("selectedLayouts", SelectedLayouts);
                    }
                    break;
                case nameof(CustomTypography):
                    if (data is List<CustomTypography> customTypographies)
                    {
                        SelectedTypographies = customTypographies;
                        if (saveState) await _localService.SetItemAsync("selectedTypographies", SelectedTypographies);
                    }
                    break;
                case nameof(CustomZIndex):
                    if (data is List<CustomZIndex> customZIndexes)
                    {
                        SelectedZIndexes = customZIndexes;
                        if (saveState) await _localService.SetItemAsync("selectedZIndexes", SelectedZIndexes);
                    }
                    break;
                default:
                    throw new ArgumentException($"Unsupported type: {key}");
            }

            if (saveState)
            {
                IsModified = true;
                await UpdateThemeId(ThemeId);
            }

            if (notifyChanged) NotifyStateChanged();
        }

        /// <summary>
        /// Resets the ThemeStateService to no theme data of any kind
        /// </summary>
        /// <returns></returns>
        public async Task ResetTheme()
        {
            await _localService.RemoveItemAsync("selectedThemeId");
            await _localService.RemoveItemAsync("selectedThemes");
            await _localService.RemoveItemAsync("selectedShadows");
            await _localService.RemoveItemAsync("selectedLayouts");
            await _localService.RemoveItemAsync("selectedTypographies");
            await _localService.RemoveItemAsync("selectedZIndexes");
            IsModified = false;
            ThemeName = string.Empty;
            ThemeOtherText = string.Empty;
            NotifyStateChanged();
        }

        /// <summary>
        /// Loads the state of the theme from local storage and saves it in the Service
        /// </summary>
        public async Task LoadState()
        {
            ThemeId = await _localService.GetItemAsync<int>("selectedThemeId");
            // if no theme found set it to 1
            if (ThemeId == 0)
            {
                ThemeId = -1;
                // no need to try the rest
                return;
            }
            SelectedThemes = await _localService.GetItemAsync<List<ThemeSelection>>("selectedThemes") ?? [];
            SelectedShadows = await _localService.GetItemAsync<List<CustomShadow>>("selectedShadows") ?? [];
            SelectedLayouts = await _localService.GetItemAsync<List<CustomLayoutProperty>>("selectedLayouts") ?? [];
            SelectedTypographies = await _localService.GetItemAsync<List<CustomTypography>>("selectedTypographies") ?? [];
            SelectedZIndexes = await _localService.GetItemAsync<List<CustomZIndex>>("selectedZIndexes") ?? [];
        }

        /// <summary>
        /// Generates the static CSS files that do not change with Dark/Light mode into a :root selector
        /// </summary>
        /// <returns>A string representation of a css class :root { }</returns>
        public string GenerateStaticCSS()
        {
            var cssBuilder = new System.Text.StringBuilder();
            cssBuilder.AppendLine(":root {");

            foreach (var shadow in SelectedShadows)
            {
                if (!string.IsNullOrEmpty(shadow.CssVariable))
                {
                    cssBuilder.AppendLine($"    {shadow.CssVariable}: {shadow.Default};");
                }
            }

            foreach (var layout in SelectedLayouts)
            {
                if (!string.IsNullOrEmpty(layout.CssVariable))
                {
                    cssBuilder.AppendLine($"    {layout.CssVariable}: {layout.DefaultPx};");
                }
            }

            foreach (var typography in SelectedTypographies)
            {
                if (!string.IsNullOrEmpty(typography.CssVariable))
                {
                    cssBuilder.AppendLine($"    {typography.CssVariable}: {typography.Default};");
                }
            }

            foreach (var zIndex in SelectedZIndexes)
            {
                if (!string.IsNullOrEmpty(zIndex.CssVariable))
                {
                    cssBuilder.AppendLine($"    {zIndex.CssVariable}: {zIndex.Default};");
                }
            }

            cssBuilder.AppendLine("}");
            return cssBuilder.ToString();
        }

        /// <summary>
        /// Generates the CSS for the selected theme based on the current dark/light mode setting
        /// </summary>
        /// <param name="isDarkSetting">Whether you want the light or dark mode of the theme.</param>
        /// <returns>a string representation of a css class :root { }</returns>
        public string GenerateDarkLightCSS(bool isDarkSetting)
        {
            var cssBuilder = new System.Text.StringBuilder();
            cssBuilder.AppendLine(":root {");

            foreach (var theme in SelectedThemes)
            {
                if (!string.IsNullOrEmpty(theme.CssVariable))
                {
                    var value = isDarkSetting && !string.IsNullOrEmpty(theme.DarkValue) ? theme.DarkValue : theme.LightValue;
                    cssBuilder.AppendLine($"    {theme.CssVariable}: {value};");
                }
            }

            cssBuilder.AppendLine("}");
            return cssBuilder.ToString();
        }

        /// <summary>
        /// Generates the C# code for the selected theme for versions 6 and 7 of Mudblazor
        /// </summary>
        /// <param name="forV8">If Version 8 is true then it changes the output to match Version 8+</param>
        /// <returns>a string representation of a public static readonly MudTheme</returns>
        public string GenerateCSharpCodeV7(bool forV8 = false)
        {
            var className = string.IsNullOrWhiteSpace(ThemeName) ? "CustomTheme" : ThemeName.Split(' ').Last() + "Theme";
            className = className[0].ToString().ToUpper() + className[1..].ToLower();
            var codeBuilder = new System.Text.StringBuilder();

            // Other Text / Copyright
            if (!string.IsNullOrEmpty(ThemeOtherText))
            {
                codeBuilder.AppendLine("    /* ");
                codeBuilder.AppendLine(ThemeOtherText);
                codeBuilder.AppendLine("    */ ");
            }

            // MudTheme declaration
            codeBuilder.AppendLine("    public static readonly MudTheme " + className + " = new()");
            codeBuilder.AppendLine("    {");

            // PaletteLight section
            if (SelectedThemes.Any(t => !string.IsNullOrEmpty(t.LightValue)))
            {
                codeBuilder.AppendLine("        PaletteLight = new PaletteLight()");
                codeBuilder.AppendLine("        {");

                foreach (var theme in SelectedThemes)
                {
                    if (!string.IsNullOrEmpty(theme.ThemeName) && !string.IsNullOrEmpty(theme.LightValue))
                    {
                        if (theme.ThemeType != "MudColor")
                        {
                            codeBuilder.AppendLine($"            {theme.ThemeName} = {theme.LightValue},");
                        }
                        else
                        {
                            codeBuilder.AppendLine($"            {theme.ThemeName} = \"{theme.LightValue}\",");
                        }
                    }
                }
                codeBuilder.AppendLine("        },");
            }

            // PaletteDark section
            if (SelectedThemes.Any(t => !string.IsNullOrEmpty(t.DarkValue)))
            {
                codeBuilder.AppendLine("        PaletteDark = new PaletteDark()");
                codeBuilder.AppendLine("        {");

                foreach (var theme in SelectedThemes)
                {
                    if (!string.IsNullOrEmpty(theme.ThemeName) && !string.IsNullOrEmpty(theme.DarkValue))
                    {
                        if (theme.ThemeType != "MudColor")
                        {
                            codeBuilder.AppendLine($"            {theme.ThemeName} = {theme.DarkValue},");
                        }
                        else
                        {
                            codeBuilder.AppendLine($"            {theme.ThemeName} = \"{theme.DarkValue}\",");
                        }
                    }
                }
                codeBuilder.AppendLine("        },");
            }

            // LayoutProperties section
            if (SelectedLayouts.Count != 0)
            {
                codeBuilder.AppendLine("        LayoutProperties = new LayoutProperties()");
                codeBuilder.AppendLine("        {");

                foreach (var layout in SelectedLayouts)
                {
                    if (!string.IsNullOrEmpty(layout.Name) && !string.IsNullOrEmpty(layout.DefaultPx))
                    {
                        codeBuilder.AppendLine($"            {layout.Name} = \"{layout.DefaultPx}\",");
                    }
                }
                codeBuilder.AppendLine("        },");
            }

            // Typography section
            if (SelectedTypographies.Count != 0)
            {
                var typoList = SelectedTypographies
                    .Select(t => t.TypoType)
                    .Distinct()
                    .ToList();

                codeBuilder.AppendLine("        Typography = new Typography()");
                codeBuilder.AppendLine("        {");
                var typoAddon = forV8 ? "Typography" : "";
                foreach (var typo in typoList)
                {
                    if (forV8 && typo == "Input")
                    {
                        continue;
                    }
                    var typoTypographies = SelectedTypographies.Where(x => x.TypoType == typo).ToList();
                    if (typoTypographies.Count == 0) continue;

                    codeBuilder.AppendLine($"            {typo} = new {typo}{typoAddon}");
                    codeBuilder.AppendLine("            {");
                    foreach (var typography in typoTypographies)
                    {
                        var dataType = "";
                        if (forV8)
                        {
                            if (typography.Name == "FontWeight" || typography.Name == "LineHeight")
                            {
                                dataType = "string";
                            }
                            else
                            {
                                dataType = typography.DataType;
                            }
                        }
                        else
                        {
                            dataType = typography.DataType;
                        }
                        if (!string.IsNullOrEmpty(typography.Name) && !string.IsNullOrEmpty(typography.Default))
                        {
                            switch (dataType)
                            {
                                case "String[]":
                                    string[] output = typography.Default.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                                    string values = "[" + string.Join(", ", output.Select(s => "\"" + s + "\"")) + "]";
                                    codeBuilder.AppendLine($"                {typography.Name} = {values.ToString()},");
                                    break;
                                case "Int32": // passthrough to double
                                case "Double": // same
                                    codeBuilder.AppendLine($"                {typography.Name} = {typography.Default},");
                                    break;
                                default:
                                    codeBuilder.AppendLine($"                {typography.Name} = \"{typography.Default}\",");
                                    break;
                            }
                        }
                    }
                    codeBuilder.AppendLine("            },");
                }

                codeBuilder.AppendLine("        },");
            }

            // ZIndex section
            if (SelectedZIndexes.Count != 0)
            {
                codeBuilder.AppendLine("        ZIndex = new ZIndex()");
                codeBuilder.AppendLine("        {");

                foreach (var zIndex in SelectedZIndexes)
                {
                    if (!string.IsNullOrEmpty(zIndex.Name) && !string.IsNullOrEmpty(zIndex.Default))
                    {
                        codeBuilder.AppendLine($"            {zIndex.Name} = {zIndex.Default},");
                    }
                }
                codeBuilder.AppendLine("        },");
            }

            codeBuilder.AppendLine("    };");

            return codeBuilder.ToString();
        }

        /// <summary>
        /// Generates the C# code for the selected theme for version 8 of Mudblazor
        /// </summary>
        /// <returns>a string representation of a public static readonly MudTheme</returns>
        public string GenerateCSharpCodeV8()
        {
            var codeBuilder = GenerateCSharpCodeV7(true);
            return codeBuilder;
        }
    }
}
