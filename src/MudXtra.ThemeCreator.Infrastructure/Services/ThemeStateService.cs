using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudXtra.ThemeCreator.Infrastructure.Interfaces;
using MudXtra.ThemeCreator.Infrastructure.Models;

namespace MudXtra.ThemeCreator.Infrastructure.Services;

public class ThemeStateService : INotifyPropertyChanged
{
    private readonly ILocalStorageService _localService;
    private readonly ILogger<ThemeStateService> _logger;
    private readonly IThemeCreatorService _themeCreator;
    private const string _keyName = "ThemeState";

    public ThemeStateService(ILocalStorageService localService, ILogger<ThemeStateService> logger, IThemeCreatorService themeCreatorService)
    {
        _localService = localService;
        _logger = logger;
        _themeCreator = themeCreatorService;
    }

    private bool _isLoading = true;
    private int _themeId;
    private bool _isApproved;
    private string _userName = string.Empty;
    private string _themeName = string.Empty;
    private string _themeOtherText = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    bool SetProperty<T>(ref T storage, T value, bool savePreferences = true,
        [CallerMemberName] string propertyName = null!)
    {
        if (Equals(storage, value))
        {
            return false;
        }

        storage = value;
        OnPropertyChanged(propertyName);
        if (savePreferences)
            _localService.SetItemAsync($"{_keyName}.{propertyName}", value).CatchAndLog();
        return true;
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value, false);
    }

    public int ThemeId
    {
        get => _themeId;
        private set
        {
            if (SetProperty(ref _themeId, value))
            {
                var customTheme = CustomThemes.FirstOrDefault(x => x.Id == value);
                if (customTheme != null)
                {
                    _isApproved = customTheme.IsApproved;
                    _userName = customTheme.UploadedBy ?? default!;
                    _themeName = customTheme.Name ?? default!;
                    _themeOtherText = customTheme.OtherText ?? default!;
                }
                else
                {
                    _isApproved = default!;
                    _userName = default!;
                    _themeName = default!;
                    _themeOtherText = default!;
                }
            }
        }
    }

    public bool IsApproved
    {
        get => _isApproved;
        private set => SetProperty(ref _isApproved, value, false);
    }

    public bool IsModified
    {
        get
        {
            if (SelectedThemes.Count == 0 &&
                SelectedShadows.Count == 0 &&
                SelectedLayouts.Count == 0 &&
                SelectedTypographies.Count == 0 &&
                SelectedZIndexes.Count == 0)
            {
                return false;
            }
            return true;
        }
    }

    public string UserName
    {
        get => _userName;
        private set => SetProperty(ref _userName, value, false);
    }

    public string ThemeName
    {
        get => _themeName;
        set => SetProperty(ref _themeName, value);
    }

    public string ThemeOtherText
    {
        get => _themeOtherText;
        set => SetProperty(ref _themeOtherText, value);
    }

    /// <summary>
    /// List of all CustomThemes from the database
    /// </summary>
    public List<CustomTheme> CustomThemes { get; private set; } = [];


    /// <summary>
    /// Currently Tracked Theme Selections
    /// </summary>
    public List<ThemeSelection> SelectedThemes { get; private set; } = [];

    /// <summary>
    /// Currently Tracked Custom Shadows
    /// </summary>
    public List<CustomShadow> SelectedShadows { get; private set; } = [];

    /// <summary>
    /// Currently Tracked Custom Layout Properties
    /// </summary>
    public List<CustomLayoutProperty> SelectedLayouts { get; private set; } = [];

    /// <summary>
    /// Currently tracked Custom Typographies
    /// </summary>
    public List<CustomTypography> SelectedTypographies { get; private set; } = [];

    /// <summary>
    /// Currently tracked Custom ZIndexes
    /// </summary>
    public List<CustomZIndex> SelectedZIndexes { get; private set; } = [];


    /// <summary>
    /// Default values for Theme Selections
    /// </summary>
    public List<ThemeSelection> DefaultThemes { get; private set; } = [];

    /// <summary>
    /// Default values for Custom Layout Properties
    /// </summary>
    public List<CustomLayoutProperty> DefaultLayouts { get; private set; } = [];

    /// <summary>
    /// Default values for Custom Typographies
    /// </summary>
    public List<CustomTypography> DefaultTypographies { get; private set; } = [];

    /// <summary>
    /// Default values for Custom ZIndexes
    /// </summary>
    public List<CustomZIndex> DefaultZIndexes { get; private set; } = [];

    /// <summary>
    /// Default values for Custom Shadows
    /// </summary>
    public List<CustomShadow> DefaultShadows { get; private set; } = [];


    /// <summary>
    /// Updates the ThemeStateService with data of type T then saves it to local storage.
    /// </summary>
    /// <typeparam name="T">The type of Data to store</typeparam>
    /// <param name="data">The <typeparamref name="T"/> of data.</param>
    public async Task UpdateThemeData<T>(T data) where T : class
    {
        if (data == null)
        {
            throw new ArgumentException("Data cannot be null.");
        }

        string key = typeof(T).Name;
        switch (key)
        {
            case nameof(ThemeSelection):
                if (data is ThemeSelection themeSelection)
                {
                    SelectedThemes.RemoveAll(x => x.Id == themeSelection.Id);
                    SelectedThemes.Add(themeSelection);
                    await _localService.SetItemAsync($"{_keyName}.{nameof(SelectedThemes)}", SelectedThemes);
                }
                break;
            case nameof(CustomShadow):
                if (data is CustomShadow customShadow)
                {
                    SelectedShadows.RemoveAll(x => x.Id == customShadow.Id);
                    SelectedShadows.Add(customShadow);
                    await _localService.SetItemAsync($"{_keyName}.{nameof(SelectedShadows)}", SelectedShadows);
                }
                break;
            case nameof(CustomLayoutProperty):
                if (data is CustomLayoutProperty customLayout)
                {
                    SelectedLayouts.RemoveAll(x => x.Id == customLayout.Id);
                    SelectedLayouts.Add(customLayout);
                    await _localService.SetItemAsync($"{_keyName}.{nameof(SelectedLayouts)}", SelectedLayouts);
                }
                break;
            case nameof(CustomTypography):
                if (data is CustomTypography customTypography)
                {
                    SelectedTypographies.RemoveAll(x => x.Id == customTypography.Id);
                    SelectedTypographies.Add(customTypography);
                    await _localService.SetItemAsync($"{_keyName}.{nameof(SelectedTypographies)}", SelectedTypographies);
                }
                break;
            case nameof(CustomZIndex):
                if (data is CustomZIndex customZIndex)
                {
                    SelectedZIndexes.RemoveAll(x => x.Id == customZIndex.Id);
                    SelectedZIndexes.Add(customZIndex);
                    await _localService.SetItemAsync($"{_keyName}.{nameof(SelectedZIndexes)}", SelectedZIndexes);
                }
                break;
            default:
                throw new ArgumentException($"Unsupported type: {key}");
        }
        OnPropertyChanged("UpdateThemeData");
    }

    /// <summary>
    /// Updates the ThemeStateService with a list of data
    /// </summary>
    /// <typeparam name="T">The type of List Data to store</typeparam>
    /// <param name="data">The List<typeparamref name="T"/> of data.</param>
    /// <param name="saveState">If true, saves the new themeId to local storage, Defaults to <c>true</c>.</param>
    /// <param name="notifyChanged">If true, notifies the public Action that a change has occured. Defaults to <c>false</c>.</param>
    public async Task UpdateThemeLists<T>(List<T> data) where T : class
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
                    await _localService.SetItemAsync("selectedThemes", SelectedThemes);
                }
                break;
            case nameof(CustomShadow):
                if (data is List<CustomShadow> customShadows)
                {
                    SelectedShadows = customShadows;
                    await _localService.SetItemAsync("selectedShadows", SelectedShadows);
                }
                break;
            case nameof(CustomLayoutProperty):
                if (data is List<CustomLayoutProperty> customLayouts)
                {
                    SelectedLayouts = customLayouts;
                    await _localService.SetItemAsync("selectedLayouts", SelectedLayouts);
                }
                break;
            case nameof(CustomTypography):
                if (data is List<CustomTypography> customTypographies)
                {
                    SelectedTypographies = customTypographies;
                    await _localService.SetItemAsync("selectedTypographies", SelectedTypographies);
                }
                break;
            case nameof(CustomZIndex):
                if (data is List<CustomZIndex> customZIndexes)
                {
                    SelectedZIndexes = customZIndexes;
                    await _localService.SetItemAsync("selectedZIndexes", SelectedZIndexes);
                }
                break;
            default:
                throw new ArgumentException($"Unsupported type: {key}");
        }
        OnPropertyChanged("UpdateThemeLists");
    }


    /// <summary>
    /// Gets the ThemeState data of type T by Id. Searches changed values first, then default values, then falls back to a new instance of T.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public T GetThemeData<T>(int id) where T : class
    {
        T data = null!;
        string key = typeof(T).Name;
        switch (key)
        {
            case nameof(ThemeSelection):
                data = SelectedThemes.FirstOrDefault(x => x.Id == id) as T ??
                       DefaultThemes.FirstOrDefault(x => x.Id == id) as T ??
                       (T)(object)new ThemeSelection();
                break;
            case nameof(CustomShadow):
                data = SelectedShadows.FirstOrDefault(x => x.Id == id) as T ??
                       DefaultShadows.FirstOrDefault(x => x.Id == id) as T ??
                       (T)(object)new CustomShadow();
                break;
            case nameof(CustomLayoutProperty):
                data = SelectedLayouts.FirstOrDefault(x => x.Id == id) as T ??
                       DefaultLayouts.FirstOrDefault(x => x.Id == id) as T ??
                       (T)(object)new CustomLayoutProperty();
                break;
            case nameof(CustomTypography):
                data = SelectedTypographies.FirstOrDefault(x => x.Id == id) as T ??
                       DefaultTypographies.FirstOrDefault(x => x.Id == id) as T ??
                       (T)(object)new CustomTypography();
                break;
            case nameof(CustomZIndex):
                data = SelectedZIndexes.FirstOrDefault(x => x.Id == id) as T ??
                       DefaultZIndexes.FirstOrDefault(x => x.Id == id) as T ??
                       (T)(object)new CustomZIndex();
                break;
            default:
                throw new ArgumentException($"Unsupported type: {key}");
        }
        return data;
    }

    /// <summary>
    /// Resets the ThemeStateService to no theme data of any kind
    /// </summary>
    /// <params>Whether to set ThemeId after reset</params>
    public async Task ClearStorage()
    {
        await _localService.RemoveItemAsync($"{_keyName}.{nameof(ThemeId)}");
        await _localService.RemoveItemAsync($"{_keyName}.{nameof(SelectedThemes)}");
        await _localService.RemoveItemAsync($"{_keyName}.{nameof(SelectedShadows)}");
        await _localService.RemoveItemAsync($"{_keyName}.{nameof(SelectedLayouts)}");
        await _localService.RemoveItemAsync($"{_keyName}.{nameof(SelectedTypographies)}");
        await _localService.RemoveItemAsync($"{_keyName}.{nameof(SelectedZIndexes)}");
    }

    /// <summary>
    /// Resets the <see cref="CustomTheme" /> listing used for selection and adds a "new unsaved theme" if the theme 
    /// parameter is not null. Also triggers an update that rebuilds the list.
    /// </summary>
    public async Task UpdateCustomThemes(CustomTheme? theme)
    {
        CustomThemes = await _themeCreator.GetCustomThemesAsync();
        if (theme != null)
            CustomThemes.Add(theme);
        OnPropertyChanged("UpdateCustomThemes");
    }

    private async Task LoadDefaults(int themeIdToLoad)
    {
        DefaultThemes = await _themeCreator.GetThemeSelectionsAsync(themeIdToLoad);
        DefaultShadows = await _themeCreator.GetCustomShadowsAsync(themeIdToLoad);
        DefaultLayouts = await _themeCreator.GetCustomLayoutsAsync(themeIdToLoad);
        DefaultTypographies = await _themeCreator.GetCustomTypographiesAsync(themeIdToLoad);
        DefaultZIndexes = await _themeCreator.GetCustomZIndexesAsync(themeIdToLoad);
    }

    /// <summary>
    /// Loads the state of the theme from local storage and saves it in the Service
    /// </summary>
    public async Task LoadTheme(int selectedThemeId)
    {
        // Load ThemeId from localstorage
        var themeId = await LoadItemAsync($"{_keyName}.{nameof(ThemeId)}", 0);

        // if saved state doesn't match Selected or no saved state, Reset it all.
        if (selectedThemeId != themeId || themeId == 0)
        {
            await ClearStorage();
        }

        // this sets IsApproved, IsModified, UserName, ThemeName, ThemeOtherText from Theme it started from
        ThemeId = themeId;
        await LoadDefaults(selectedThemeId == 0 ? 1 : selectedThemeId);
        ThemeId = selectedThemeId;
        // Load other collections if they exist or reset
        SelectedThemes = await LoadItemAsync($"{_keyName}.{nameof(SelectedThemes)}", new List<ThemeSelection>());
        SelectedShadows = await LoadItemAsync($"{_keyName}.{nameof(SelectedShadows)}", new List<CustomShadow>());
        SelectedLayouts = await LoadItemAsync($"{_keyName}.{nameof(SelectedLayouts)}", new List<CustomLayoutProperty>());
        SelectedTypographies = await LoadItemAsync($"{_keyName}.{nameof(SelectedTypographies)}", new List<CustomTypography>());
        SelectedZIndexes = await LoadItemAsync($"{_keyName}.{nameof(SelectedZIndexes)}", new List<CustomZIndex>());
        IsLoading = false;
        OnPropertyChanged("LoadTheme");
    }

    private async Task<T> LoadItemAsync<T>(string key, T defaultValue)
    {
        try
        {
            return await _localService.GetItemAsync<T>(key) ?? defaultValue;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to deserialize item for key '{key}'. Removing corrupted item.", key);
            await _localService.RemoveItemAsync(key);
            return defaultValue;
        }
    }

    /// <summary>
    /// Generates the static CSS files that do not change with Dark/Light mode into a :root selector
    /// </summary>
    /// <returns>A string representation of a css class :root { }</returns>
    public string GenerateStaticCSS()
    {
        var cssBuilder = new System.Text.StringBuilder();
        cssBuilder.AppendLine(":root {");

        foreach (var shadow in DefaultShadows)
        {
            var shadowBuilder = SelectedShadows.FirstOrDefault(x => x.Id == shadow.Id)?.Default ??
                                shadow.Default;
            if (!string.IsNullOrEmpty(shadow.CssVariable))
            {
                cssBuilder.AppendLine($"    {shadow.CssVariable}: {shadowBuilder};");
            }
        }

        foreach (var layout in DefaultLayouts)
        {
            var layoutBuilder = SelectedLayouts.FirstOrDefault(x => x.Id == layout.Id)?.DefaultPx ??
                                layout.DefaultPx;
            if (!string.IsNullOrEmpty(layout.CssVariable))
            {
                cssBuilder.AppendLine($"    {layout.CssVariable}: {layoutBuilder};");
            }
        }

        foreach (var typography in DefaultTypographies)
        {
            var typoBuilder = SelectedTypographies.FirstOrDefault(x => x.Id == typography.Id)?.Default ??
                              typography.Default;
            if (!string.IsNullOrEmpty(typography.CssVariable))
            {
                cssBuilder.AppendLine($"    {typography.CssVariable}: {typoBuilder};");
            }
        }

        foreach (var zIndex in DefaultZIndexes)
        {
            var zBuilder = SelectedZIndexes.FirstOrDefault(x => x.Id == zIndex.Id)?.Default ??
                           zIndex.Default;
            if (!string.IsNullOrEmpty(zIndex.CssVariable))
            {
                cssBuilder.AppendLine($"    {zIndex.CssVariable}: {zBuilder};");
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

        foreach (var theme in DefaultThemes)
        {
            var themeBuilder = SelectedThemes.FirstOrDefault(x => x.Id == theme.Id) ?? theme;
            if (!string.IsNullOrEmpty(theme.CssVariable))
            {
                var themeValue = isDarkSetting && !string.IsNullOrEmpty(themeBuilder.DarkValue)
                    ? themeBuilder.DarkValue : themeBuilder.LightValue;
                cssBuilder.AppendLine($"    {theme.CssVariable}: {themeValue};");
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
        if (DefaultThemes.Any(t => !string.IsNullOrEmpty(t.LightValue)))
        {
            codeBuilder.AppendLine("        PaletteLight = new PaletteLight()");
            codeBuilder.AppendLine("        {");

            foreach (var theme in DefaultThemes)
            {
                var themeBuilder = SelectedThemes.FirstOrDefault(x => x.Id == theme.Id) ?? theme;
                if (!string.IsNullOrEmpty(theme.ThemeName) && !string.IsNullOrEmpty(themeBuilder.LightValue))
                {
                    if (theme.ThemeType != "MudColor")
                    {
                        codeBuilder.AppendLine($"            {themeBuilder.ThemeName} = {themeBuilder.LightValue},");
                    }
                    else
                    {
                        codeBuilder.AppendLine($"            {themeBuilder.ThemeName} = \"{themeBuilder.LightValue}\",");
                    }
                }
            }
            codeBuilder.AppendLine("        },");
        }

        // PaletteDark section
        if (DefaultThemes.Any(t => !string.IsNullOrEmpty(t.DarkValue)))
        {
            codeBuilder.AppendLine("        PaletteDark = new PaletteDark()");
            codeBuilder.AppendLine("        {");

            foreach (var theme in DefaultThemes)
            {
                var themeBuilder = SelectedThemes.FirstOrDefault(x => x.Id == theme.Id) ?? theme;
                if (!string.IsNullOrEmpty(theme.ThemeName) && !string.IsNullOrEmpty(themeBuilder.DarkValue))
                {
                    if (theme.ThemeType != "MudColor")
                    {
                        codeBuilder.AppendLine($"            {themeBuilder.ThemeName} = {themeBuilder.DarkValue},");
                    }
                    else
                    {
                        codeBuilder.AppendLine($"            {themeBuilder.ThemeName} = \"{themeBuilder.DarkValue}\",");
                    }
                }
            }
            codeBuilder.AppendLine("        },");
        }

        // LayoutProperties section
        if (DefaultLayouts.Count != 0)
        {
            codeBuilder.AppendLine("        LayoutProperties = new LayoutProperties()");
            codeBuilder.AppendLine("        {");

            foreach (var layout in DefaultLayouts)
            {
                var layoutBuilder = SelectedLayouts.FirstOrDefault(x => x.Id == layout.Id) ?? layout;
                if (!string.IsNullOrEmpty(layout.Name) && !string.IsNullOrEmpty(layoutBuilder.DefaultPx))
                {
                    codeBuilder.AppendLine($"            {layout.Name} = \"{layoutBuilder.DefaultPx}\",");
                }
            }
            codeBuilder.AppendLine("        },");
        }

        // Typography section
        if (DefaultTypographies.Count != 0)
        {
            var typoList = DefaultTypographies
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
                var typoTypographies = DefaultTypographies.Where(x => x.TypoType == typo).ToList();
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
                    var typoBuilder = SelectedTypographies.FirstOrDefault(x => x.Id == typography.Id) ?? typography;
                    if (!string.IsNullOrEmpty(typography.Name) && !string.IsNullOrEmpty(typoBuilder.Default))
                    {
                        switch (dataType)
                        {
                            case "String[]":
                                string[] output = typoBuilder.Default.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                                string values = "[" + string.Join(", ", output.Select(s => "\"" + s + "\"")) + "]";
                                codeBuilder.AppendLine($"                {typography.Name} = {values.ToString()},");
                                break;
                            case "Int32": // passthrough to double
                            case "Double": // same
                                codeBuilder.AppendLine($"                {typography.Name} = {typoBuilder.Default},");
                                break;
                            default:
                                codeBuilder.AppendLine($"                {typography.Name} = \"{typoBuilder.Default}\",");
                                break;
                        }
                    }
                }
                codeBuilder.AppendLine("            },");
            }

            codeBuilder.AppendLine("        },");
        }

        // ZIndex section
        if (DefaultZIndexes.Count != 0)
        {
            codeBuilder.AppendLine("        ZIndex = new ZIndex()");
            codeBuilder.AppendLine("        {");

            foreach (var zIndex in DefaultZIndexes)
            {
                var zBuilder = SelectedZIndexes.FirstOrDefault(x => x.Id == zIndex.Id) ?? zIndex;
                if (!string.IsNullOrEmpty(zIndex.Name) && !string.IsNullOrEmpty(zBuilder.Default))
                {
                    codeBuilder.AppendLine($"            {zIndex.Name} = {zBuilder.Default},");
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
