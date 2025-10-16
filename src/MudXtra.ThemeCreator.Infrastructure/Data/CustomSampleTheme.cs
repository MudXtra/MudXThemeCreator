using MudBlazor;

namespace MudXtra.ThemeCreator.Infrastructure.Data;
public static class CustomSampleTheme
{
    /* 
Silver Theme (Created by Versile2)
    */
    public static readonly MudTheme Silver = new()
    {
        PaletteLight = new PaletteLight()
        {
            Black = "#594ae2ff",
            White = "#ffffffff",
            Primary = "#1984c8ff",
            PrimaryContrastText = "#FFFFFF",
            Secondary = "#87ceebff",
            SecondaryContrastText = "#ffffffff",
            Tertiary = "#2adfbbff",
            TertiaryContrastText = "#FFFFFF",
            Info = "#007bc3",
            InfoContrastText = "rgba(255,255,255,1)",
            Success = "#3ea44e",
            SuccessContrastText = "rgba(255,255,255,1)",
            Warning = "#ff9800",
            WarningContrastText = "rgba(255,255,255,1)",
            Error = "#d92800",
            ErrorContrastText = "rgba(255,255,255,1)",
            Dark = "rgba(121,142,171,1)",
            DarkContrastText = "rgba(255,255,255,1)",
            TextPrimary = "#000000ff",
            TextSecondary = "#e0e0e0ff",
            TextDisabled = "#d0d0d0ff",
            ActionDefault = "#0000008c",
            ActionDisabled = "#00000042",
            ActionDisabledBackground = "#0000001e",
            Background = "#ddddddff",
            BackgroundGray = "#f5f5f5ff",
            Surface = "#fdf6f6ff",
            DrawerBackground = "rgba(121,142,171,1)",
            DrawerText = "#000000ff",
            DrawerIcon = "#000000ff",
            AppbarBackground = "#364258ff",
            AppbarText = "#ffffffff",
            LinesDefault = "#0000001e",
            LinesInputs = "#bdbdbdff",
            TableLines = "#e0e0e0ff",
            TableStriped = "#00000033",
            TableHover = "#0000000a",
            Divider = "#9a9696ff",
            DividerLight = "#dfdedeff",
            PrimaryDarken = "#014f7bff",
            PrimaryLighten = "#66c7feff",
            SecondaryDarken = "#060608ff",
            SecondaryLighten = "#7e7e7ee3",
            TertiaryDarken = "#19a98cff",
            TertiaryLighten = "#59ffdeda",
            InfoDarken = "#0c80dfff",
            InfoLighten = "#47a7f5ff",
            SuccessDarken = "#00a344ff",
            SuccessLighten = "#00eb62ff",
            WarningDarken = "#d68100ff",
            WarningLighten = "#ffa724ff",
            ErrorDarken = "#f21c0dff",
            ErrorLighten = "#f66055ff",
            HoverOpacity = 0.06,
            RippleOpacity = 0.1,
            RippleOpacitySecondary = 0.2,
            GrayDefault = "#9e9e9eff",
            GrayLight = "#bdbdbdff",
            GrayLighter = "#e0e0e0ff",
            GrayDark = "#757575ff",
            GrayDarker = "#616161ff",
            OverlayDark = "#2121217f",
            OverlayLight = "#ffffff7f",
        },
        PaletteDark = new PaletteDark()
        {
            Black = "rgba(39,39,47,1)",
            Primary = "#1984c8",
            Secondary = "#87ceebff",
            Tertiary = "#2adfbbff",
            Info = "#007bc3",
            Success = "#3ea44e",
            Warning = "#ff9800",
            Error = "#d92800",
            Dark = "rgba(121,142,171,1)",
            TextPrimary = "#ffffff",
            TextSecondary = "#e0e0e0",
            TextDisabled = "#d0d0d0",
            ActionDefault = "rgba(173,173,177,1)",
            ActionDisabled = "rgba(255,255,255,0.25882352941176473)",
            ActionDisabledBackground = "rgba(255,255,255,0.11764705882352941)",
            Background = "#000000",
            BackgroundGray = "rgba(39,39,47,1)",
            Surface = "rgba(55,55,64,1)",
            DrawerBackground = "rgba(121,142,171,1)",
            DrawerText = "#ffffffff",
            DrawerIcon = "#ffffffff",
            AppbarBackground = "#364258",
            AppbarText = "#000000ff",
            LinesDefault = "rgba(255,255,255,0.11764705882352941)",
            LinesInputs = "rgba(255,255,255,0.2980392156862745)",
            TableLines = "rgba(255,255,255,0.11764705882352941)",
            TableStriped = "rgba(255,255,255,0.2)",
            Divider = "#9a9696ff",
            DividerLight = "#dfdedeff",
            PrimaryDarken = "#015284ff",
            PrimaryLighten = "#59bdfaff",
            SecondaryDarken = "#010103ff",
            SecondaryLighten = "#8e8e8eff",
            TertiaryLighten = "#65fee0ff",
            InfoDarken = "rgb(10,133,255)",
            InfoLighten = "rgb(92,173,255)",
            SuccessDarken = "rgb(9,154,108)",
            SuccessLighten = "rgb(13,222,156)",
            WarningDarken = "rgb(214,143,0)",
            WarningLighten = "rgb(255,182,36)",
            ErrorDarken = "rgb(244,47,70)",
            ErrorLighten = "rgb(248,119,134)",
        },
        Typography = new Typography()
        {
            Default = new DefaultTypography
            {
                FontFamily = ["Roboto", "Helvetica", "Arial", "sans-serif"],
                FontWeight = "400",
                FontSize = "18px",
                LineHeight = "1.43",
                LetterSpacing = ".01071em",
                TextTransform = "none",
            },
            H1 = new H1Typography
            {
                FontWeight = "300",
                FontSize = "6rem",
                LineHeight = "1.167",
                LetterSpacing = "-.01562em",
                TextTransform = "none",
            },
            H2 = new H2Typography
            {
                FontWeight = "300",
                FontSize = "3.75rem",
                LineHeight = "1.2",
                LetterSpacing = "-.00833em",
                TextTransform = "none",
            },
            H3 = new H3Typography
            {
                FontWeight = "400",
                FontSize = "3rem",
                LineHeight = "1.167",
                LetterSpacing = "0",
                TextTransform = "none",
            },
            H4 = new H4Typography
            {
                FontWeight = "400",
                FontSize = "2.125rem",
                LineHeight = "1.235",
                LetterSpacing = ".00735em",
                TextTransform = "none",
            },
            H5 = new H5Typography
            {
                FontWeight = "400",
                FontSize = "1.5rem",
                LineHeight = "1.334",
                LetterSpacing = "0",
                TextTransform = "none",
            },
            H6 = new H6Typography
            {
                FontWeight = "500",
                FontSize = "1.25rem",
                LineHeight = "1.6",
                LetterSpacing = ".0075em",
                TextTransform = "none",
            },
            Subtitle1 = new Subtitle1Typography
            {
                FontWeight = "400",
                FontSize = "1rem",
                LineHeight = "1.75",
                LetterSpacing = ".00938em",
                TextTransform = "none",
            },
            Subtitle2 = new Subtitle2Typography
            {
                FontWeight = "500",
                FontSize = ".875rem",
                LineHeight = "1.57",
                LetterSpacing = ".00714em",
                TextTransform = "none",
            },
            Body1 = new Body1Typography
            {
                FontWeight = "400",
                FontSize = "1rem",
                LineHeight = "1.5",
                LetterSpacing = ".00938em",
                TextTransform = "none",
            },
            Body2 = new Body2Typography
            {
                FontWeight = "400",
                FontSize = ".875rem",
                LineHeight = "1.43",
                LetterSpacing = ".01071em",
                TextTransform = "none",
            },
            Button = new ButtonTypography
            {
                FontWeight = "500",
                FontSize = ".875rem",
                LineHeight = "1.75",
                LetterSpacing = ".02857em",
                TextTransform = "uppercase",
            },
            Caption = new CaptionTypography
            {
                FontWeight = "400",
                FontSize = ".75rem",
                LineHeight = "1.66",
                LetterSpacing = ".03333em",
                TextTransform = "none",
            },
            Overline = new OverlineTypography
            {
                FontWeight = "400",
                FontSize = ".75rem",
                LineHeight = "2.66",
                LetterSpacing = ".08333em",
                TextTransform = "none",
            },
        },
        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "8px"
        },
        Shadows = new Shadow()
        {

        },
        ZIndex = new()
        {

        }
    };


}
