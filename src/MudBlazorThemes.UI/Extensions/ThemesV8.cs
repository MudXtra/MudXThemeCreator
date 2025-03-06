using MudBlazor;

namespace MudBlazorThemes.UI.Extensions
{
    public class ThemesV8
    {
        public static readonly MudTheme SilverTheme = new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#1984c8",
                PrimaryContrastText = "#FFFFFF",
                Secondary = "#f3f3f4",
                SecondaryContrastText = "#FFFFFF",
                Tertiary = "#03a9f4",
                TertiaryContrastText = "#FFFFFF",
                Info = "#007bc3",
                Success = "#3ea44e",
                Warning = "#ff9800",
                Error = "#d92800",
                Dark = "#404040",
                DarkLighten = "#ebebeb",
                TextDisabled = "#8f8f8f",
                Background = "#ffffff",
                TextPrimary = "#515967",
                TextSecondary = "#666666",
                AppbarBackground = "#364258",
                AppbarText = "#ffffff",
                DrawerBackground = "#798eab",
                DrawerText = "#ffffff",
            },
            PaletteDark = new PaletteDark()
            {
                Primary = "#1984c8",
                Secondary = "#131314",
                Tertiary = "#03a9f4",
                Info = "#007bc3",
                Success = "#3ea44e",
                Warning = "#ff9800",
                Error = "#d92800",
                Dark = "#404040",
                DarkLighten = "#ebebeb",
                TextDisabled = "#d0d0d0",
                Background = "#000000",
                TextPrimary = "#ffffff",
                TextSecondary = "#e0e0e0",
                AppbarBackground = "#364258",
                AppbarText = "#ffffff",
                DrawerBackground = "#798eab",
                DrawerText = "#ffffff",
            },
            LayoutProperties = new LayoutProperties()
            {
                DefaultBorderRadius = "4px",
            },
            Typography = new Typography()
            {
                Default = new DefaultTypography()
                {
                    FontWeight = "400",
                    LineHeight = "1.4285714287",
                    FontFamily = ["Source Sans Pro", "Helvetica Neue", "Arial", "sans-serif"],
                },
                Body1 = new Body1Typography()
                {
                    FontSize = "14px",
                },
                Body2 = new Body2Typography()
                {
                    FontSize = "12px",
                },
            }
        };
    }
}
