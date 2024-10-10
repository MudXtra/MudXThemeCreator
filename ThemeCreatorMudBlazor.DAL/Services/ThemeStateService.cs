using ThemeCreatorMudBlazor.DAL.Interfaces;
using ThemeCreatorMudBlazor.DAL.Models;

namespace ThemeCreatorMudBlazor.DAL.Services
{
    public class ThemeStateService(ILocalStorageService localService) : IThemeStateService
    {
        private readonly ILocalStorageService _localService = localService;
        public bool IsDarkMode { get; set; } = false;
        public bool IsInitialized { get; set; } = false;
        public int ThemeId { get; private set; }
        public string ThemeName { get; set; } = string.Empty;
        public string ThemeOtherText { get; set; } = string.Empty;
        public List<ThemeSelection> SelectedThemes { get; private set; } = [];
        public List<CustomShadow> SelectedShadows { get; private set; } = [];
        public List<CustomLayoutProperty> SelectedLayouts { get; private set; } = [];
        public List<CustomTypography> SelectedTypographies { get; private set; } = [];
        public List<CustomZIndex> SelectedZIndexes { get; private set; } = [];

        public event Action? OnChange;

        public void NotifyStateChanged() => OnChange?.Invoke();

        public async Task Initialize()
        {
            await LoadState();
            IsInitialized = true;
        }

        public async Task UpdateThemeId(int themeId, bool saveState = true, bool notifyChanged = false)
        {
            ThemeId = themeId;
            if (saveState) await _localService.SetItemAsync("selectedThemeId", themeId);
            if (notifyChanged) NotifyStateChanged();
        }

        public async Task UpdateThemeData<T>(List<T> data, bool saveState = true, bool updateCss = false) where T : class
        {
            ArgumentNullException.ThrowIfNull(nameof(data));

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

            if (updateCss) NotifyStateChanged();
        }

        public async Task ResetTheme()
        {
            await _localService.DeleteItemAsync("selectedThemeId");
            await _localService.DeleteItemAsync("selectedThemes");
            await _localService.DeleteItemAsync("selectedShadows");
            await _localService.DeleteItemAsync("selectedLayouts");
            await _localService.DeleteItemAsync("selectedTypographies");
            await _localService.DeleteItemAsync("selectedZIndexes");
            ThemeName = string.Empty;
            ThemeOtherText = string.Empty;
            ThemeId = 1;
            await LoadState();
            NotifyStateChanged();
        }

        public async Task LoadState()
        {
            ThemeId = await _localService.GetItemAsync<int>("selectedThemeId");
            if (ThemeId == 0) { ThemeId = -1; }
            SelectedThemes = await _localService.GetItemAsync<List<ThemeSelection>>("selectedThemes") ?? [];
            SelectedShadows = await _localService.GetItemAsync<List<CustomShadow>>("selectedShadows") ?? [];
            SelectedLayouts = await _localService.GetItemAsync<List<CustomLayoutProperty>>("selectedLayouts") ?? [];
            SelectedTypographies = await _localService.GetItemAsync<List<CustomTypography>>("selectedTypographies") ?? [];
            SelectedZIndexes = await _localService.GetItemAsync<List<CustomZIndex>>("selectedZIndexes") ?? [];
        }

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
        
        public string GenerateCSharpCode()
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
                foreach (var typo in typoList)
                {
                    var typoTypographies = SelectedTypographies.Where(x => x.TypoType == typo).ToList();
                    if (typoTypographies.Count == 0) continue;

                    codeBuilder.AppendLine($"            {typo} = new {typo}");
                    codeBuilder.AppendLine("            {");
                    foreach (var typography in typoTypographies)
                    {
                        if (!string.IsNullOrEmpty(typography.Name) && !string.IsNullOrEmpty(typography.Default))
                        {
                            switch (typography.DataType)
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
    }
}
