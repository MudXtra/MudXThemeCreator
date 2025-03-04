using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.DAL.Interfaces
{
    public interface IThemeStateService
    {
        bool IsInitialized { get; }
        bool IsModified { get; set; }
        bool IsApproved { get; set; }
        string UserName { get; set; }
        int ThemeId { get; set; }
        string ThemeName { get; set; }
        string ThemeOtherText { get; set; }
        List<ThemeSelection> SelectedThemes { get; }
        List<CustomShadow> SelectedShadows { get; }
        List<CustomLayoutProperty> SelectedLayouts { get; }
        List<CustomTypography> SelectedTypographies { get; }
        List<CustomZIndex> SelectedZIndexes { get; }
        List<CustomTheme> CustomThemes { get; set; }
        event Action? OnChange;

        Task Initialize();
        Task UpdateThemeData<T>(List<T> data, bool saveState = true, bool updateCss = false) where T : class;
        Task UpdateThemeId(int themeId, bool saveState = true, bool notifyChanged = false);
        Task LoadState();
        Task ResetTheme();
        string GenerateDarkLightCSS(bool isDarkSetting);
        string GenerateStaticCSS();
        string GenerateCSharpCodeV7(bool forV8 = false);
        string GenerateCSharpCodeV8();
    }
}
