using ThemeCreatorMudBlazor.DAL.Models;

namespace ThemeCreatorMudBlazor.DAL.Interfaces
{
    public interface IThemeCreatorService
    {
        public Task<List<ThemeOption>> GetActiveThemeOptionsAsync();
        public Task<List<ThemePalette>> GetThemePalettesAsync();
        public Task<List<CustomTheme>> GetCustomThemesAsync();
        public Task<List<ThemeSelection>> GetThemeSelectionsAsync(int IdthemeId);
        public Task<List<CustomShadow>> GetCustomShadowsAsync(int themeId);
        public Task<List<CustomLayoutProperty>> GetCustomLayoutsAsync(int themeId);
        public Task<List<CustomTypography>> GetCustomTypographiesAsync(int themeId);
        public Task<List<CustomZIndex>> GetCustomZIndexesAsync(int themeId);
        public Task<(string themeName, string otherText, List<ThemeSelection> themeSelections, List<CustomShadow> customShadows, List<CustomLayoutProperty> customLayoutProperties, List<CustomTypography> customTypographies, List<CustomZIndex> customZIndices)> ImportBootswatchTheme(string cssContent, int mappedThemeId = 1);
        public Task<bool> SaveTheme(IThemeStateService _themeState);
    }
}
