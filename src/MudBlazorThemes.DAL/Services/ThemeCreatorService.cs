using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazorThemes.DAL.Data;
using MudBlazorThemes.DAL.Interfaces;
using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.DAL.Services
{
    public class ThemeCreatorService : IThemeCreatorService
    {
        private readonly IDbContextFactory<ThemeDbContext> _dbContextFactory;

        private int _maxThemes = 0;
        public int MaxThemes(string userName)
        {
            if (_maxThemes == 0)
            {
                using var context = _dbContextFactory.CreateDbContext();
                var userMax = context.UserMaxes.FirstOrDefault(x => x.UserName == userName);
                if (userMax == null)
                {
                    userMax = new UserMax { UserName = userName, MaxThemes = 5 };
                    context.UserMaxes.Add(userMax);
                    context.SaveChanges();
                }
                _maxThemes = userMax.MaxThemes;
            }
            return _maxThemes;
        }

        public ThemeCreatorService(IDbContextFactory<ThemeDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            // ensure our database is setup and ready for use
            using var context = _dbContextFactory.CreateDbContext();
            context.Initialize();
        }

        public async Task<List<ThemeOption>> GetActiveThemeOptionsAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            return await context.ThemeOptions.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<List<ThemePalette>> GetThemePalettesAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            return await context.ThemePalettes.ToListAsync();
        }

        public async Task<List<CustomTheme>> GetCustomThemesAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            return await context.CustomThemes
                .Where(x => x.IsActive)
                .OrderBy(x => x.Id == 1 ? 0 : 1) // Default theme first
                .ThenBy(x => x.Name) // Alphabetically for the rest
                .ToListAsync();
        }

        public async Task<bool> UpdateApprovedThemeAsync(int themeId, bool approval)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var theme = await context.CustomThemes.FirstOrDefaultAsync(x => x.Id == themeId);
            if (theme == null)
            {
                return false;
            }
            theme.IsApproved = approval;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ThemeSelection>> GetThemeSelectionsAsync(int themeId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.ThemeSelections.Where(x => x.CustomThemeId == themeId).ToListAsync();
        }

        public async Task<List<CustomShadow>> GetCustomShadowsAsync(int themeId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.CustomShadows.Where(x => x.CustomThemeId == themeId).ToListAsync();
        }

        public async Task<List<CustomLayoutProperty>> GetCustomLayoutsAsync(int themeId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.CustomLayoutProperties.Where(x => x.CustomThemeId == themeId).ToListAsync();
        }

        public async Task<List<CustomTypography>> GetCustomTypographiesAsync(int themeId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.CustomTypographies.Where(x => x.CustomThemeId == themeId).ToListAsync();
        }

        public async Task<List<CustomZIndex>> GetCustomZIndexesAsync(int themeId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.CustomZIndexes.Where(x => x.CustomThemeId == themeId).ToListAsync();
        }

        public async Task<ThemeDTO> ImportBootswatchTheme(string cssContent)
        {
            var theme = new ThemeDTO();

            // get theme stuff to reinsert
            var defaultThemeId = 1;
            var themeSelections = await GetThemeSelectionsAsync(defaultThemeId);
            var customShadows = await GetCustomShadowsAsync(defaultThemeId);
            var customLayouts = await GetCustomLayoutsAsync(defaultThemeId);
            var customTypographies = await GetCustomTypographiesAsync(defaultThemeId);
            var customZIndexes = await GetCustomZIndexesAsync(defaultThemeId);

            using var context = await _dbContextFactory.CreateDbContextAsync();

            var mappedThemeList = await context.MappedCssVariables.Where(x => x.MappedThemeId == 1).ToListAsync();

            string pattern = @"(?i)theme:\s+(\w+)";
            Match match = Regex.Match(cssContent, pattern);
            string themeName = $"Bootswatch - ";
            themeName += match.Success ? match.Groups[1].Value : "Unknown";
            themeName = char.ToUpper(themeName[0]) + themeName[1..].ToLower();

            match = Regex.Match(cssContent, @"\/\*([\s\S]*?)\*\/");
            string otherText = string.Empty;
            if (match.Success)
            {
                otherText = match.Groups[1].Value.Trim();
            }

            var lightThemeVariables = ParseCssVariables(cssContent, "light");
            var darkThemeVariables = ParseCssVariables(cssContent, "dark");

            foreach (var sel in themeSelections)
            {
                var mapping = mappedThemeList.FirstOrDefault(x => x.MappedCssVariable == sel.CssVariable);
                if (mapping != null)
                {
                    // Update LightValue
                    if (lightThemeVariables.TryGetValue(mapping.NativeCssVariable, out var lightValue))
                    {
                        sel.LightValue = lightValue;
                    }

                    // Update DarkValue
                    if (darkThemeVariables.TryGetValue(mapping.NativeCssVariable, out var darkValue))
                    {
                        sel.DarkValue = darkValue;
                    }
                    else
                    {
                        // If no dark value is found, use the light value
                        sel.DarkValue = sel.LightValue;
                    }
                }
            }
            // we get lightvalue if it exists, otherwise we get darkvalue if it exists
            foreach (var shadow in customShadows)
            {
                var mapping = mappedThemeList.FirstOrDefault(x => x.MappedCssVariable == shadow.CssVariable);
                if (mapping != null)
                {
                    if (lightThemeVariables.TryGetValue(mapping.NativeCssVariable, out var lightValue))
                    {
                        shadow.Default = lightValue;
                    }
                    else if (darkThemeVariables.TryGetValue(mapping.NativeCssVariable, out var darkValue))
                    {
                        shadow.Default = darkValue;
                    }
                }
            }

            foreach (var layProp in customLayouts)
            {
                var mapping = mappedThemeList.FirstOrDefault(x => x.MappedCssVariable == layProp.CssVariable);
                if (mapping != null)
                {
                    if (lightThemeVariables.TryGetValue(mapping.NativeCssVariable, out var lightValue))
                    {
                        if (int.TryParse(lightValue, out int result))
                        {
                            layProp.Default = result;
                        }
                    }
                    else if (darkThemeVariables.TryGetValue(mapping.NativeCssVariable, out var darkValue))
                    {
                        if (int.TryParse(darkValue, out int result))
                        {
                            layProp.Default = result;
                        }
                    }
                }
            }

            foreach (var typ in customTypographies)
            {
                var mapping = mappedThemeList.FirstOrDefault(x => x.MappedCssVariable == typ.CssVariable);
                if (mapping != null)
                {
                    if (lightThemeVariables.TryGetValue(mapping.NativeCssVariable, out var lightValue))
                    {
                        typ.Default = lightValue;
                    }
                    else if (darkThemeVariables.TryGetValue(mapping.NativeCssVariable, out var darkValue))
                    {
                        typ.Default = darkValue;
                    }
                }
            }

            foreach (var zIndex in customZIndexes)
            {
                var mapping = mappedThemeList.FirstOrDefault(x => x.MappedCssVariable == zIndex.CssVariable);
                if (mapping != null)
                {
                    if (lightThemeVariables.TryGetValue(mapping.NativeCssVariable, out var lightValue))
                    {
                        zIndex.Default = lightValue;
                    }
                    else if (darkThemeVariables.TryGetValue(mapping.NativeCssVariable, out var darkValue))
                    {
                        zIndex.Default = darkValue;
                    }
                }
            }
            theme = new ThemeDTO
            {
                CustomTheme = new()
                {
                    Name = themeName,
                    OtherText = otherText,
                    IsActive = true,
                    IsApproved = false,
                    UploadedBy = null,
                    CreatedWhen = DateTime.UtcNow
                },
                ThemeSelections = themeSelections,
                CustomShadows = customShadows,
                CustomLayoutProperties = customLayouts,
                CustomTypographies = customTypographies,
                CustomZIndices = customZIndexes,
            };
            return theme;
        }

        private static Dictionary<string, string> ParseCssVariables(string cssContent, string theme)
        {
            var variables = new Dictionary<string, string>();
            string pattern = $@"\[data-bs-theme={theme}\]\s*{{([^}}]*?)}}";
            var themeMatch = Regex.Match(cssContent, pattern, RegexOptions.Singleline);

            if (themeMatch.Success)
            {
                string themeContent = themeMatch.Groups[1].Value;
                var variableMatches = Regex.Matches(themeContent, @"(--[^:]+):\s*([^;]+);");

                foreach (Match match in variableMatches)
                {
                    string key = match.Groups[1].Value.Trim();
                    string value = match.Groups[2].Value.Trim();
                    variables[key] = value;
                }
            }

            return variables;
        }

        public async Task<ThemeDTO> ImportMudBlazorTheme(string content)
        {
            var theme = new ThemeDTO();
            // get theme stuff to reinsert
            var defaultThemeId = 1;
            var themeSelections = await GetThemeSelectionsAsync(defaultThemeId);
            var customShadows = await GetCustomShadowsAsync(defaultThemeId);
            var customLayouts = await GetCustomLayoutsAsync(defaultThemeId);
            var customTypographies = await GetCustomTypographiesAsync(defaultThemeId);
            var customZIndexes = await GetCustomZIndexesAsync(defaultThemeId);

            using var context = await _dbContextFactory.CreateDbContextAsync();

            var themeData = new Dictionary<string, object>();

            string themePattern = @"public\s+static\s+readonly\s+MudTheme\s+(\w+)\s*=\s*(?:new\s*\(\s*\)|new\s*\w+\s*\(\s*\))\s*{([\s\S]*?)}\s*;";
            Match themeMatch = Regex.Match(content, themePattern);
            if (themeMatch.Success)
            {
                themeData["Name"] = themeMatch.Groups[1].Value;
                string fullContent = themeMatch.Groups[2].Value;

                // Helper function to parse key-value pairs
                static Dictionary<string, string> ParseKeyValuePairs(string sectionContent)
                {
                    var dict = new Dictionary<string, string>();
                    string pairPattern = @"(\w+)\s*=\s*(""[^""]*""|\[.*?\]|\d*\.?\d+)(?:,|$)";
                    foreach (Match pair in Regex.Matches(sectionContent, pairPattern))
                    {
                        dict[pair.Groups[1].Value] = pair.Groups[2].Value;
                    }
                    return dict;
                }

                // 2. PaletteLight
                Match plMatch = Regex.Match(fullContent, @"PaletteLight\s*=\s*new\s*PaletteLight\s*\(\s*\)\s*\{([\s\S]*?)\}");
                if (plMatch.Success)
                {
                    themeData["PaletteLight"] = ParseKeyValuePairs(plMatch.Groups[1].Value);
                }

                // 3. PaletteDark
                Match pdMatch = Regex.Match(fullContent, @"PaletteDark\s*=\s*new\s*PaletteDark\s*\(\s*\)\s*\{([\s\S]*?)\}");
                if (pdMatch.Success)
                {
                    themeData["PaletteDark"] = ParseKeyValuePairs(pdMatch.Groups[1].Value);
                }

                // 4. LayoutProperties
                Match lpMatch = Regex.Match(fullContent, @"LayoutProperties\s*=\s*new\s*LayoutProperties\s*\(\s*\)\s*\{([\s\S]*?)\}");
                if (lpMatch.Success)
                {
                    themeData["LayoutProperties"] = ParseKeyValuePairs(lpMatch.Groups[1].Value);
                }

                // 5. Typography
                var typography = new Dictionary<string, Dictionary<string, string>>();
                string typoPattern = @"Typography\s*=\s*new\s*Typography\s*\(\s*\)\s*\{((?:[^{}]|\{[^}]*\})*?)\}";
                Match typoMatch = Regex.Match(content, typoPattern);
                if (typoMatch.Success)
                {
                    string typoContent = typoMatch.Groups[1].Value;

                    // 2. Parse subsections
                    string subSectionPattern = @"(\w+)\s*=\s*new\s*\w+\s*{([^}]+)}";
                    MatchCollection subMatches = Regex.Matches(typoContent, subSectionPattern);

                    // Process each subsection
                    foreach (Match subMatch in subMatches)
                    {
                        string sectionName = subMatch.Groups[1].Value; // First word (Default, H1, etc.)
                        string sectionContent = subMatch.Groups[2].Value; // Content inside {}
                        typography[sectionName] = ParseKeyValuePairs(sectionContent);
                    }
                }

                // 6. ZIndex
                Match ziMatch = Regex.Match(fullContent, @"ZIndex\s*=\s*new\s*ZIndex\s*\(\s*\)\s*\{([\s\S]*?)\}");
                if (ziMatch.Success)
                {
                    themeData["ZIndex"] = ParseKeyValuePairs(ziMatch.Groups[1].Value);
                }

                // Example output
                Console.WriteLine($"Theme Name: {themeData["Name"]}");
                foreach (var section in themeData)
                {
                    if (section.Key != "Name" && section.Key != "Typography")
                    {
                        Console.WriteLine($"\n{section.Key}:");
                        var dict = (Dictionary<string, string>)section.Value;
                        foreach (var kvp in dict)
                        {
                            Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                        }
                    }
                    else if (section.Key == "Typography")
                    {
                        Console.WriteLine("\nTypography:");
                        var typoDict = (Dictionary<string, Dictionary<string, string>>)section.Value;
                        foreach (var subSection in typoDict)
                        {
                            Console.WriteLine($"  {subSection.Key}:");
                            foreach (var kvp in subSection.Value)
                            {
                                Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                            }
                        }
                    }
                }
                // Output results
                Console.WriteLine("\nTypography:");
                foreach (var section in typography)
                {
                    Console.WriteLine($"  {section.Key}:");
                    foreach (var kvp in section.Value)
                    {
                        Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                    }
                }

                foreach (var themeSection in themeSelections)
                {
                    // Check if the key exists in PaletteLight before assigning
                    if (themeData.TryGetValue("PaletteLight", out object? lValue) &&
                        lValue is Dictionary<string, string> paletteLight &&
                        paletteLight.TryGetValue(themeSection.ThemeName, out string? lightValue))
                    {
                        themeSection.LightValue = lightValue.Replace("\"", string.Empty);
                    }

                    // Check if the key exists in PaletteDark before assigning
                    if (themeData.TryGetValue("PaletteDark", out object? dValue) &&
                        dValue is Dictionary<string, string> paletteDark &&
                        paletteDark.TryGetValue(themeSection.ThemeName, out string? darkValue))
                    {
                        themeSection.DarkValue = darkValue.Replace("\"", string.Empty);
                    }
                }

                foreach (var layProp in customLayouts)
                {
                    if (themeData.TryGetValue("LayoutProperties", out object? value) &&
                        value is Dictionary<string, string> layout &&
                        layout.TryGetValue(layProp.Name, out string? newValue) &&
                        int.TryParse(Regex.Replace(newValue ?? "", "[^0-9]", ""), out int result))
                    {
                        layProp.Default = result;
                    }
                }

                foreach (var zProp in customZIndexes)
                {
                    if (themeData.TryGetValue("ZIndex", out object? value) &&
                        value is Dictionary<string, string> zindex &&
                        zindex.TryGetValue(zProp.Name, out string? newValue) &&
                        int.TryParse(Regex.Replace(newValue ?? "", "[^0-9]", ""), out int result))
                    {
                        zProp.Default = result.ToString();
                    }
                }

                foreach (var group in customTypographies.Select(x => x.TypoType).Distinct())
                {
                    foreach (var typo in customTypographies.Where(x => x.TypoType == group).ToList())
                    {
                        if (typography.TryGetValue(typo.TypoType, out var value) && // Use TypoType as key (e.g., "Default", "H1")
                            value is Dictionary<string, string> typoValue &&
                            typoValue.TryGetValue(typo.Name, out string? newValue) &&
                            newValue != null) // Ensure newValue isn't null
                        {
                            switch (typo.DataType)
                            {
                                case "Int32": // For FontWeight
                                    if (int.TryParse(Regex.Replace(newValue, "[^0-9]", ""), out int intResult))
                                    {
                                        typo.Default = intResult.ToString(); // Store as string
                                    }
                                    break;

                                case "Double": // For LineHeight
                                    if (double.TryParse(Regex.Replace(newValue, "[^0-9.-]", ""), out double doubleResult))
                                    {
                                        typo.Default = doubleResult.ToString(); // Store as string
                                    }
                                    break;

                                case "String": // For FontSize, LetterSpacing, TextTransform
                                    typo.Default = newValue.Replace("\"", string.Empty); // Keep as is
                                    break;

                                case "String[]": // For FontFamily
                                                 // Assuming newValue is like "[\"Roboto\", \"Helvetica\", \"Arial\", \"sans-serif\"]"
                                                 // Strip brackets and split if needed, or just store as is
                                    typo.Default = newValue.Trim('[', ']').Replace("\"", string.Empty);
                                    break;

                                default:
                                    Console.WriteLine($"Unknown DataType: {typo.DataType} for {typo.Name}");
                                    break;
                            }
                        }
                    }
                }

                theme = new ThemeDTO
                {
                    CustomTheme = new()
                    {
                        Name = themeData["Name"].ToString() ?? string.Empty,
                        OtherText = "Imported from MudBlazor",
                        IsActive = true,
                        IsApproved = false,
                        UploadedBy = null,
                        CreatedWhen = DateTime.UtcNow
                    },
                    ThemeSelections = themeSelections,
                    CustomShadows = customShadows,
                    CustomLayoutProperties = customLayouts,
                    CustomTypographies = customTypographies,
                    CustomZIndices = customZIndexes
                };
            }
            return theme;
        }

        #region Save/Update Theme
        public async Task<int> SaveTheme(IThemeStateService themeState, string userName, bool superUser)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                CustomTheme? customTheme;

                // Check if we're updating an existing theme or creating a new one
                if (themeState.ThemeId > 0 && (themeState.UserName == userName || superUser))
                {
                    customTheme = await context.CustomThemes
                        .FirstOrDefaultAsync(x => x.Id == themeState.ThemeId);

                    if (customTheme == null)
                    {
                        return 0; // Theme not found, no update possible
                    }

                    // Update existing theme
                    customTheme.Name = themeState.ThemeName;
                    customTheme.OtherText = themeState.ThemeOtherText;
                }
                else
                {
                    // Create new theme
                    customTheme = new CustomTheme
                    {
                        IsActive = true,
                        IsApproved = false,
                        Name = themeState.ThemeName,
                        CreatedWhen = DateTime.UtcNow,
                        OtherText = themeState.ThemeOtherText,
                        UploadedBy = userName
                    };
                    context.CustomThemes.Add(customTheme);
                }

                await context.SaveChangesAsync(); // Save to get customTheme.Id if new

                var customThemeId = customTheme.Id;

                if (themeState.ThemeId >= 0) // New or update theme case
                {
                    await AddThemeSelections(context, customThemeId, themeState.SelectedThemes);
                    await AddCustomShadows(context, customThemeId, themeState.SelectedShadows);
                    await AddCustomLayouts(context, customThemeId, themeState.SelectedLayouts);
                    await AddCustomTypographies(context, customThemeId, themeState.SelectedTypographies);
                    await AddCustomZIndexes(context, customThemeId, themeState.SelectedZIndexes);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return customThemeId;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return 0; // Consider logging the exception for debugging
            }
        }

        // Helper methods
        private static Task AddThemeSelections(ThemeDbContext context, int customThemeId, List<ThemeSelection> selections)
        {
            var oldThemeSelections = context.ThemeSelections.Where(ts => ts.CustomThemeId == customThemeId);
            context.ThemeSelections.RemoveRange(oldThemeSelections);
            var newThemeSelections = selections.Select(ts => new ThemeSelection
            {
                CustomThemeId = customThemeId,
                CssVariable = ts.CssVariable,
                LightValue = ts.LightValue,
                DarkValue = ts.DarkValue,
                OrderPriority = ts.OrderPriority,
                ThemeName = ts.ThemeName,
                ThemeOptionId = ts.ThemeOptionId,
                ThemeType = ts.ThemeType
            }).ToList();
            return context.ThemeSelections.AddRangeAsync(newThemeSelections);
        }

        private static Task AddCustomShadows(ThemeDbContext context, int customThemeId, List<CustomShadow> shadows)
        {
            var oldCustomShadows = context.CustomShadows.Where(cs => cs.CustomThemeId == customThemeId);
            context.CustomShadows.RemoveRange(oldCustomShadows);
            var newCustomShadows = shadows.Select(cs => new CustomShadow
            {
                CustomThemeId = customThemeId,
                CssVariable = cs.CssVariable,
                Default = cs.Default,
                Index = cs.Index,
                Name = cs.Name
            }).ToList();
            return context.CustomShadows.AddRangeAsync(newCustomShadows);
        }

        private static Task AddCustomLayouts(ThemeDbContext context, int customThemeId, List<CustomLayoutProperty> layouts)
        {
            var oldCustomLayouts = context.CustomLayoutProperties.Where(cl => cl.CustomThemeId == customThemeId);
            context.CustomLayoutProperties.RemoveRange(oldCustomLayouts);
            var newCustomLayouts = layouts.Select(cl => new CustomLayoutProperty
            {
                CustomThemeId = customThemeId,
                CssVariable = cl.CssVariable,
                Default = cl.Default,
                Name = cl.Name,
                Min = cl.Min,
                Max = cl.Max
            }).ToList();
            return context.CustomLayoutProperties.AddRangeAsync(newCustomLayouts);
        }

        private static Task AddCustomTypographies(ThemeDbContext context, int customThemeId, List<CustomTypography> typographies)
        {
            var oldCustomTypographies = context.CustomTypographies.Where(ct => ct.CustomThemeId == customThemeId);
            context.CustomTypographies.RemoveRange(oldCustomTypographies);
            var newCustomTypographies = typographies.Select(ct => new CustomTypography
            {
                CustomThemeId = customThemeId,
                CssVariable = ct.CssVariable,
                Default = ct.Default,
                Name = ct.Name,
                TypoType = ct.TypoType,
                DataType = ct.DataType
            }).ToList();
            return context.CustomTypographies.AddRangeAsync(newCustomTypographies);
        }

        private static Task AddCustomZIndexes(ThemeDbContext context, int customThemeId, List<CustomZIndex> zIndexes)
        {
            var oldCustomZIndexes = context.CustomZIndexes.Where(cz => cz.CustomThemeId == customThemeId);
            context.CustomZIndexes.RemoveRange(oldCustomZIndexes);
            var newCustomZIndexes = zIndexes.Select(cz => new CustomZIndex
            {
                CustomThemeId = customThemeId,
                CssVariable = cz.CssVariable,
                Default = cz.Default,
                Name = cz.Name
            }).ToList();
            return context.CustomZIndexes.AddRangeAsync(newCustomZIndexes);
        }
        #endregion

        public async Task<bool> DeleteTheme(int themeId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var theme = await context.CustomThemes.FirstOrDefaultAsync(x => x.Id == themeId);
            if (theme == null)
            {
                return false;
            }
            theme.IsActive = false;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
