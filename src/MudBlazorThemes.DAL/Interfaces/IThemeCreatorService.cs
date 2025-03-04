using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.DAL.Interfaces
{
    public interface IThemeCreatorService
    {
        int MaxThemes(string userName);
        public Task<List<ThemeOption>> GetActiveThemeOptionsAsync();
        public Task<List<ThemePalette>> GetThemePalettesAsync();
        public Task<List<CustomTheme>> GetCustomThemesAsync();
        public Task<bool> UpdateApprovedThemeAsync(int themeId, bool approval);
        public Task<List<ThemeSelection>> GetThemeSelectionsAsync(int IdthemeId);
        public Task<List<CustomShadow>> GetCustomShadowsAsync(int themeId);
        public Task<List<CustomLayoutProperty>> GetCustomLayoutsAsync(int themeId);
        public Task<List<CustomTypography>> GetCustomTypographiesAsync(int themeId);
        public Task<List<CustomZIndex>> GetCustomZIndexesAsync(int themeId);
        public Task<(string themeName, string otherText, List<ThemeSelection> themeSelections, List<CustomShadow> customShadows, List<CustomLayoutProperty> customLayoutProperties, List<CustomTypography> customTypographies, List<CustomZIndex> customZIndices)> ImportBootswatchTheme(string cssContent, int mappedThemeId = 1);
        public Task<IThemeStateService> ImportMudBlazorTheme(string csContent, IThemeStateService themeState);
        public Task<int> SaveTheme(IThemeStateService _themeState, string userName, bool superUser);
        public Task<bool> DeleteTheme(int themeId);
    }
}
