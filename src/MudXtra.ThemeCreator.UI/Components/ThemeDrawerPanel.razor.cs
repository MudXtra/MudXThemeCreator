using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Utilities;
using MudXtra.ThemeCreator.Infrastructure.Interfaces;
using MudXtra.ThemeCreator.Infrastructure.Models;
using MudXtra.ThemeCreator.Infrastructure.Services;

namespace MudXtra.ThemeCreator.UI.Components;

public partial class ThemeDrawerPanel : ComponentBase
{
    private Dictionary<string, bool> _panelDictionary = [];
    private List<string> _typoList = [];
    private int _typoValue = 0;
    private int _currentShadowIndex = 0;

    private IReadOnlyList<string> GetAvailableFonts()
    {
        return new List<string>
        {
            "Arial", "Helvetica", "Times New Roman", "Times", "Courier New", "Courier",
                "Verdana", "Georgia", "Palatino", "Garamond", "Bookman", "Comic Sans MS",
                "Trebuchet MS", "Arial Black", "Impact"
        };
    }

    [Inject]
    private IThemeCreatorService _themeCreator { get; set; } = default!;

    [Inject]
    private ThemeStateService _themeState { get; set; } = default!;

    [Inject]
    private UserPreferencesService _userPreference { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _userPreference.PropertyChanged += UpdateState;
        _themeState.PropertyChanged += UpdateState;
        _panelDictionary.Add("light", !_userPreference.IsDarkMode);
        _panelDictionary.Add("dark", _userPreference.IsDarkMode);
        foreach (var option in _themeCreator.DefaultThemeOptions)
        {
            _panelDictionary[$"o{option.Id}"] = false;
        }
        _typoList = (await _themeCreator.GetCustomTypographiesAsync(1))
            .Select(t => t.TypoType)
            .Distinct()
            .ToList();
    }

    private void _themeState_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void UpdateState(object? sender, PropertyChangedEventArgs e)
    {
        StateHasChanged();
    }

    #region Setting values in theme state service
    private async Task SpinnerIndexChanged(int newVal)
    {
        _typoValue = newVal;
        await InvokeAsync(StateHasChanged);
    }

    private Task ThemeColorChanged(int themeId, MudColor newColor, int paletteId)
    {
        bool isLight = paletteId == 1;
        var foundTheme = _themeState.DefaultThemes.FirstOrDefault(x => x.Id == themeId);
        ArgumentNullException.ThrowIfNull(foundTheme); // should never be null.
        var newSelection = new ThemeSelection
        {
            Id = foundTheme.Id,
            CssVariable = foundTheme.CssVariable,
            CustomThemeId = foundTheme.CustomThemeId,
            OrderPriority = foundTheme.OrderPriority,
            ThemeName = foundTheme.ThemeName,
            ThemeOptionId = foundTheme.ThemeOptionId,
            ThemeType = foundTheme.ThemeType,
            LightValue = isLight ? newColor.ToString(MudColorOutputFormats.HexA) : foundTheme.LightValue,
            DarkValue = isLight ? foundTheme.DarkValue : newColor.ToString(MudColorOutputFormats.HexA),
        };
        // update themestate
        return _themeState.UpdateThemeData(newSelection);
    }

    private Task OnThemeLayoutDoubleChanged(double val, int themeId)
    {
        var foundTheme = _themeState.DefaultThemes.FirstOrDefault(x => x.Id == themeId);
        ArgumentNullException.ThrowIfNull(foundTheme); // should never be null
        var newSelection = new ThemeSelection
        {
            Id = foundTheme.Id,
            CssVariable = foundTheme.CssVariable,
            CustomThemeId = foundTheme.CustomThemeId,
            OrderPriority = foundTheme.OrderPriority,
            ThemeName = foundTheme.ThemeName,
            ThemeOptionId = foundTheme.ThemeOptionId,
            ThemeType = foundTheme.ThemeType,
            LightValue = val.ToString(),
            DarkValue = val.ToString(),
        };
        // update themestate
        return _themeState.UpdateThemeData(newSelection);
    }

    private Task TextItemChanged(int id, string text, string typo)
    {
        if (typo != "typo")
        {
            throw new NotSupportedException("Only typography changes are currently supported here.");
        }
        var foundTypoItem = _themeState.DefaultTypographies.FirstOrDefault(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(foundTypoItem); // should never be null.
        var newSelection = new CustomTypography
        {
            Id = foundTypoItem.Id,
            TypoType = foundTypoItem.TypoType,
            CssVariable = foundTypoItem.CssVariable,
            Default = text,
            DataType = foundTypoItem.DataType,
            Name = foundTypoItem.Name,
            CustomThemeId = foundTypoItem.CustomThemeId
        };
        return _themeState.UpdateThemeData(newSelection);
    }

    private Task NumberItemChanged(int id, double newVal, string typo)
    {
        switch (typo)
        {
            case "typo":
                var foundTypoItem = _themeState.DefaultTypographies.FirstOrDefault(x => x.Id == id);
                ArgumentNullException.ThrowIfNull(foundTypoItem); // should never be null.
                var newTypo = new CustomTypography
                {
                    Id = foundTypoItem.Id,
                    TypoType = foundTypoItem.TypoType,
                    CssVariable = foundTypoItem.CssVariable,
                    Default = newVal.ToString(),
                    DataType = foundTypoItem.DataType,
                    Name = foundTypoItem.Name,
                    CustomThemeId = foundTypoItem.CustomThemeId
                };
                return _themeState.UpdateThemeData(newTypo);

            case "zindex":
                var foundZItem = _themeState.DefaultZIndexes.FirstOrDefault(x => x.Id == id);
                ArgumentNullException.ThrowIfNull(foundZItem); // should never be null.
                var newZ = new CustomZIndex
                {
                    Id = foundZItem.Id,
                    CssVariable = foundZItem.CssVariable,
                    Default = newVal.ToString(),
                    Name = foundZItem.Name,
                    CustomThemeId = foundZItem.CustomThemeId
                };
                return _themeState.UpdateThemeData(newZ);

            default:
                throw new NotSupportedException("Only typography and zindex changes are currently supported here.");
        }
    }

    private async Task LayoutPropertyChanged(int layoutId, int sliderValue)
    {
        var foundLayout = _themeState.DefaultLayouts.FirstOrDefault(x => x.Id == layoutId);
        ArgumentNullException.ThrowIfNull(foundLayout); // should never be null.
        var newLayout = new CustomLayoutProperty
        {
            Id = foundLayout.Id,
            CssVariable = foundLayout.CssVariable,
            CustomThemeId = foundLayout.CustomThemeId,
            Min = foundLayout.Min,
            Max = foundLayout.Max,
            Name = foundLayout.Name,
            Default = sliderValue
        };
        await _themeState.UpdateThemeData(newLayout);
    }

    private void HandleShadowKeyPress(KeyboardEventArgs e)
    {
        switch (e.Key)
        {
            case "ArrowUp":
                if (_currentShadowIndex > 0)
                {
                    ChangeShadowIndex(-1);
                }
                break;
            case "ArrowDown":
                if (_currentShadowIndex < _themeState.DefaultShadows.Count - 1)
                    ChangeShadowIndex(1);
                break;
        }
    }

    private void ChangeShadowIndex(int delta)
    {
        _currentShadowIndex = Math.Clamp(_currentShadowIndex + delta, 0, _themeState.DefaultShadows.Count - 1);
    }

    #endregion

    public void Dispose()
    {
        _userPreference.PropertyChanged -= UpdateState;
        _themeState.PropertyChanged -= UpdateState;
    }
}
