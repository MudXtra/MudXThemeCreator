using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using MudBlazorThemes.DAL.Data;
using MudBlazorThemes.DAL.Interfaces;
using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.DAL.Services
{
    public class ThemeCreatorService : IThemeCreatorService
    {
        private readonly IDbContextFactory<ThemeDbContext> _dbContextFactory;
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
                .Where(x => x.IsActive && x.IsApproved)
                .OrderBy(x => x.Id == 1 ? 0 : 1) // Default theme first
                .ThenBy(x => x.Name) // Alphabetically for the rest
                .ToListAsync();
        }

        public async Task<bool> GetApprovedThemeAsync(int themeId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            return await context.CustomThemes.AnyAsync(x => x.Id == themeId && x.IsApproved);
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

        public async Task // Complex Tuple anyone?
            <(string themeName, string otherText, List<ThemeSelection> themeSelections, List<CustomShadow> customShadows,
            List<CustomLayoutProperty> customLayoutProperties, List<CustomTypography> customTypographies,
            List<CustomZIndex> customZIndices)>
            ImportBootswatchTheme(string cssContent, int mappedThemeId = 1)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            // get theme stuff to reinsert
            var defaultThemeId = 1;
            var themeSelections = await GetThemeSelectionsAsync(defaultThemeId);
            var customShadows = await GetCustomShadowsAsync(defaultThemeId);
            var customLayouts = await GetCustomLayoutsAsync(defaultThemeId);
            var customTypographies = await GetCustomTypographiesAsync(defaultThemeId);
            var customZIndexes = await GetCustomZIndexesAsync(defaultThemeId);

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
            (string themeName, string otherText, List<ThemeSelection> themeSelections, List<CustomShadow> customShadows, List<CustomLayoutProperty> customLayoutProperties, List<CustomTypography> customTypographies, List<CustomZIndex> customZIndices)
                importedTheme = (themeName, otherText, themeSelections, customShadows, customLayouts, customTypographies, customZIndexes);
            return importedTheme;
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

        public async Task<bool> SaveTheme(IThemeStateService _themeState)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                // Create new CustomTheme record
                var customTheme = new CustomTheme
                {
                    IsActive = true,
                    IsApproved = true,
                    Name = _themeState.ThemeName,
                    CreatedWhen = DateTime.Now,
                    OtherText = _themeState.ThemeOtherText
                };

                context.CustomThemes.Add(customTheme);
                await context.SaveChangesAsync();

                // Get the ID of the newly added CustomTheme
                var customThemeId = customTheme.Id;

                var newThemeSelections = _themeState.SelectedThemes.Select(ts => new ThemeSelection
                {
                    CustomThemeId = customThemeId,
                    CssVariable = ts.CssVariable,
                    LightValue = ts.LightValue,
                    DarkValue = ts.DarkValue,
                    OrderPriority = ts.OrderPriority,
                    ThemeName = ts.ThemeName,
                    ThemeOptionId = ts.ThemeOptionId,
                    ThemeType = ts.ThemeType,
                }).ToList();
                context.ThemeSelections.AddRange(newThemeSelections);
                await context.SaveChangesAsync();

                var newCustomShadows = _themeState.SelectedShadows.Select(cs => new CustomShadow
                {
                    CustomThemeId = customThemeId,
                    CssVariable = cs.CssVariable,
                    Default = cs.Default,
                    Index = cs.Index,
                    Name = cs.Name,
                }).ToList();

                context.CustomShadows.AddRange(newCustomShadows);
                await context.SaveChangesAsync();

                var newCustomLayouts = _themeState.SelectedLayouts.Select(cl => new CustomLayoutProperty
                {
                    CustomThemeId = customThemeId,
                    CssVariable = cl.CssVariable,
                    Default = cl.Default,
                    Name = cl.Name,
                    Min = cl.Min,
                    Max = cl.Max,
                }).ToList();
                context.CustomLayoutProperties.AddRange(newCustomLayouts);
                await context.SaveChangesAsync();

                var newCustomTypographies = _themeState.SelectedTypographies.Select(ct => new CustomTypography
                {
                    CustomThemeId = customThemeId,
                    CssVariable = ct.CssVariable,
                    Default = ct.Default,
                    Name = ct.Name,
                    TypoType = ct.TypoType,
                    DataType = ct.DataType,
                }).ToList();
                context.CustomTypographies.AddRange(newCustomTypographies);
                await context.SaveChangesAsync();

                var newCustomZIndexes = _themeState.SelectedZIndexes.Select(cz => new CustomZIndex
                {
                    CustomThemeId = customThemeId,
                    CssVariable = cz.CssVariable,
                    Default = cz.Default,
                    Name = cz.Name,
                }).ToList();
                context.CustomZIndexes.AddRange(newCustomZIndexes);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
                await _themeState.ResetTheme();
                await _themeState.UpdateThemeId(customThemeId);
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
