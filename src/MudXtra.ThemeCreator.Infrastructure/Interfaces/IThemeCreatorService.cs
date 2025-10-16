using MudXtra.ThemeCreator.Infrastructure.Models;
using MudXtra.ThemeCreator.Infrastructure.Models.Other;
using MudXtra.ThemeCreator.Infrastructure.Services;

namespace MudXtra.ThemeCreator.Infrastructure.Interfaces;

public interface IThemeCreatorService
{
    int MaxThemes(string userName);

    public IReadOnlyList<ThemeOption> DefaultThemeOptions { get; set; }
    public IReadOnlyList<ThemePalette> DefaultThemePalettes { get; set; }

    public Task<List<CustomTheme>> GetCustomThemesAsync();
    public Task<bool> UpdateApprovedThemeAsync(int themeId, bool approval);
    public Task<List<ThemeSelection>> GetThemeSelectionsAsync(int IdthemeId);
    public Task<List<CustomShadow>> GetCustomShadowsAsync(int themeId);
    public Task<List<CustomLayoutProperty>> GetCustomLayoutsAsync(int themeId);
    public Task<List<CustomTypography>> GetCustomTypographiesAsync(int themeId);
    public Task<List<CustomZIndex>> GetCustomZIndexesAsync(int themeId);
    public Task<ThemeDto> ImportBootswatchTheme(string cssContent);
    public Task<ThemeDto> ImportMudBlazorTheme(string content);
    public Task<int> SaveTheme(ThemeStateService _themeState, string userName, bool superUser);
    public Task<bool> DeleteTheme(int themeId);
}
