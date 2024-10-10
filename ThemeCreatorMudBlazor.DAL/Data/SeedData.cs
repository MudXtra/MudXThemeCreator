using ThemeCreatorMudBlazor.DAL.Models;

namespace ThemeCreatorMudBlazor.DAL.Data
{
    public class SeedData
    {
        // public static List<TableName> GetInitialTableName
        public static List<ThemePalette> GetInitialPalettes()
        {
            return
            [
                new ThemePalette { Id = 1, Name = "Palette Light" },
                new ThemePalette { Id = 2, Name = "Palette Dark" }
            ];
        }

        public static List<ThemeOption> GetInitialOptions()
        {
            return
            [
                new ThemeOption{ Id = 1, Name = "Shadows" },
                new ThemeOption{ Id = 2, Name = "Layout Properties" },
                new ThemeOption{ Id = 3, Name = "Typography" },
                new ThemeOption{ Id = 4, Name = "ZIndex" }
            ];
        }

        public static List<CustomTheme> GetCustomThemes()
        {
            return
            [
                new CustomTheme{ Id = 1, IsActive = true, IsApproved = true, Name = "Default Theme", CreatedWhen = DateTime.Now, OtherText = "The Default Theme for MudBlazor" }
            ];
        }

        public static List<ThemeSelection> GetThemeSelection()
        {
            return
            [
                new ThemeSelection{ Id = 1, CustomThemeId = 1, OrderPriority = 99, ThemeName = "Black", ThemeType = "MudColor", LightValue = "rgba(89,74,226,1)", DarkValue = "rgba(39,39,47,1)", CssVariable = "--mud-palette-black" },
                new ThemeSelection{ Id = 2, CustomThemeId = 1, OrderPriority = 99, ThemeName = "White", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-white" },
                new ThemeSelection{ Id = 3, CustomThemeId = 1, OrderPriority = 1, ThemeName = "Primary", ThemeType = "MudColor", LightValue = "rgba(89,74,226,1)", DarkValue = "rgba(119,107,231,1)", CssVariable = "--mud-palette-primary" },
                new ThemeSelection{ Id = 4, CustomThemeId = 1, OrderPriority = 1, ThemeName = "PrimaryContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-primary-text" },
                new ThemeSelection{ Id = 5, CustomThemeId = 1, OrderPriority = 2, ThemeName = "Secondary", ThemeType = "MudColor", LightValue = "rgba(255,64,129,1)", CssVariable = "--mud-palette-secondary" },
                new ThemeSelection{ Id = 6, CustomThemeId = 1, OrderPriority = 2, ThemeName = "SecondaryContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-secondary-text" },
                new ThemeSelection{ Id = 7, CustomThemeId = 1, OrderPriority = 3, ThemeName = "Tertiary", ThemeType = "MudColor", LightValue = "rgba(30,200,165,1)", CssVariable = "--mud-palette-tertiary" },
                new ThemeSelection{ Id = 8, CustomThemeId = 1, OrderPriority = 3, ThemeName = "TertiaryContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-tertiary-text" },
                new ThemeSelection{ Id = 9, CustomThemeId = 1, OrderPriority = 4, ThemeName = "Info", ThemeType = "MudColor", LightValue = "rgba(33,150,243,1)",DarkValue = "rgba(50,153,255,1)", CssVariable = "--mud-palette-info" },
                new ThemeSelection{ Id = 10, CustomThemeId = 1, OrderPriority = 4, ThemeName = "InfoContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-info-text" },
                new ThemeSelection{ Id = 11, CustomThemeId = 1, OrderPriority = 5, ThemeName = "Success", ThemeType = "MudColor", LightValue = "rgba(0,200,83,1)",DarkValue = "rgba(11,186,131,1)", CssVariable = "--mud-palette-success" },
                new ThemeSelection{ Id = 12, CustomThemeId = 1, OrderPriority = 5, ThemeName = "SuccessContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-success-text" },
                new ThemeSelection{ Id = 13, CustomThemeId = 1, OrderPriority = 6, ThemeName = "Warning", ThemeType = "MudColor", LightValue = "rgba(255,152,0,1)",DarkValue = "rgba(255,168,0,1)", CssVariable = "--mud-palette-warning" },
                new ThemeSelection{ Id = 14, CustomThemeId = 1, OrderPriority = 6, ThemeName = "WarningContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-warning-text" },
                new ThemeSelection{ Id = 15, CustomThemeId = 1, OrderPriority = 7, ThemeName = "Error", ThemeType = "MudColor", LightValue = "rgba(244,67,54,1)",DarkValue = "rgba(246,78,98,1)", CssVariable = "--mud-palette-error" },
                new ThemeSelection{ Id = 16, CustomThemeId = 1, OrderPriority = 7, ThemeName = "ErrorContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-error-text" },
                new ThemeSelection{ Id = 17, CustomThemeId = 1, OrderPriority = 8, ThemeName = "Dark", ThemeType = "MudColor", LightValue = "rgba(66,66,66,1)", DarkValue="rgba(39,39,47,1)", CssVariable = "--mud-palette-dark" },
                new ThemeSelection{ Id = 18, CustomThemeId = 1, OrderPriority = 8, ThemeName = "DarkContrastText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", CssVariable = "--mud-palette-dark-text" },
                new ThemeSelection{ Id = 19, CustomThemeId = 1, OrderPriority = 1, ThemeName = "TextPrimary", ThemeType = "MudColor", LightValue = "rgba(66,66,66,1)", DarkValue="rgba(255,255,255,0.6980392156862745)", CssVariable = "--mud-palette-text-primary" },
                new ThemeSelection{ Id = 20, CustomThemeId = 1, OrderPriority = 2, ThemeName = "TextSecondary", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.5372549019607843)", DarkValue="rgba(255,255,255,0.4980392156862745)", CssVariable = "--mud-palette-text-secondary" },
                new ThemeSelection{ Id = 21, CustomThemeId = 1, OrderPriority = 9, ThemeName = "TextDisabled", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.3764705882352941)", DarkValue="rgba(255,255,255,0.2)", CssVariable = "--mud-palette-text-disabled" },
                new ThemeSelection{ Id = 22, CustomThemeId = 1, OrderPriority = 99, ThemeName = "ActionDefault", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.5372549019607843)", DarkValue="rgba(173,173,177,1)", CssVariable = "--mud-palette-action-default" },
                new ThemeSelection{ Id = 23, CustomThemeId = 1, OrderPriority = 99, ThemeName = "ActionDisabled", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.25882352941176473)", DarkValue="rgba(255,255,255,0.25882352941176473)", CssVariable = "--mud-palette-action-disabled" },
                new ThemeSelection{ Id = 24, CustomThemeId = 1, OrderPriority = 99, ThemeName = "ActionDisabledBackground", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.11764705882352941)", DarkValue="rgba(255,255,255,0.11764705882352941)", CssVariable = "--mud-palette-action-disabled-background" },
                new ThemeSelection{ Id = 25, CustomThemeId = 1, OrderPriority = 11, ThemeName = "Background", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", DarkValue="rgba(50,51,61,1)", CssVariable = "--mud-palette-background" },
                new ThemeSelection{ Id = 26, CustomThemeId = 1, OrderPriority = 11, ThemeName = "BackgroundGray", ThemeType = "MudColor", LightValue = "rgba(245,245,245,1)", DarkValue="rgba(39,39,47,1)", CssVariable = "--mud-palette-background-gray" },
                new ThemeSelection{ Id = 27, CustomThemeId = 1, OrderPriority = 10, ThemeName = "Surface", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", DarkValue="rgba(55,55,64,1)", CssVariable = "--mud-palette-surface" },
                new ThemeSelection{ Id = 28, CustomThemeId = 1, OrderPriority = 12, ThemeName = "DrawerBackground", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", DarkValue="rgba(39,39,47,1)", CssVariable = "--mud-palette-drawer-background" },
                new ThemeSelection{ Id = 29, CustomThemeId = 1, OrderPriority = 12, ThemeName = "DrawerText", ThemeType = "MudColor", LightValue = "rgba(66,66,66,1)", DarkValue="rgba(255,255,255,0.4980392156862745)", CssVariable = "--mud-palette-drawer-text" },
                new ThemeSelection{ Id = 30, CustomThemeId = 1, OrderPriority = 12, ThemeName = "DrawerIcon", ThemeType = "MudColor", LightValue = "rgba(97,97,97,1)", DarkValue="rgba(255,255,255,0.4980392156862745)", CssVariable = "--mud-palette-drawer-icon" },
                new ThemeSelection{ Id = 31, CustomThemeId = 1, OrderPriority = 13, ThemeName = "AppbarBackground", ThemeType = "MudColor", LightValue = "rgba(89,74,226,1)", DarkValue="rgba(39,39,47,1)", CssVariable = "--mud-palette-appbar-background" },
                new ThemeSelection{ Id = 32, CustomThemeId = 1, OrderPriority = 13, ThemeName = "AppbarText", ThemeType = "MudColor", LightValue = "rgba(255,255,255,1)", DarkValue="rgba(255,255,255,0.6980392156862745)", CssVariable = "--mud-palette-appbar-text" },
                new ThemeSelection{ Id = 33, CustomThemeId = 1, OrderPriority = 99, ThemeName = "LinesDefault", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.11764705882352941)", DarkValue="rgba(255,255,255,0.11764705882352941)", CssVariable = "--mud-palette-lines-default" },
                new ThemeSelection{ Id = 34, CustomThemeId = 1, OrderPriority = 99, ThemeName = "LinesInputs", ThemeType = "MudColor", LightValue = "rgba(189,189,189,1)", DarkValue="rgba(255,255,255,0.2980392156862745)", CssVariable = "--mud-palette-lines-inputs"},
                new ThemeSelection{ Id = 35, CustomThemeId = 1, OrderPriority = 99, ThemeName = "TableLines", ThemeType = "MudColor", LightValue = "rgba(224,224,224,1)", DarkValue="rgba(255,255,255,0.11764705882352941)", CssVariable = "--mud-palette-table-lines" },
                new ThemeSelection{ Id = 36, CustomThemeId = 1, OrderPriority = 99, ThemeName = "TableStriped", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.0196078431372549)", DarkValue="rgba(255,255,255,0.2)", CssVariable = "--mud-palette-table-striped" },
                new ThemeSelection{ Id = 37, CustomThemeId = 1, OrderPriority = 99, ThemeName = "TableHover", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.0392156862745098)", CssVariable = "--mud-palette-table-hover" },
                new ThemeSelection{ Id = 38, CustomThemeId = 1, OrderPriority = 99, ThemeName = "Divider", ThemeType = "MudColor", LightValue = "rgba(224,224,224,1)", DarkValue="rgba(255,255,255,0.11764705882352941)", CssVariable = "--mud-palette-divider"  },
                new ThemeSelection{ Id = 39, CustomThemeId = 1, OrderPriority = 99, ThemeName = "DividerLight", ThemeType = "MudColor", LightValue = "rgba(0,0,0,0.8)", DarkValue="rgba(255,255,255,0.058823529411764705)", CssVariable = "--mud-palette-divider-light"  },
                new ThemeSelection{ Id = 40, CustomThemeId = 1, OrderPriority = 1, ThemeName = "PrimaryDarken", ThemeType = "MudColor", LightValue = "rgb(62,44,221)", DarkValue="rgb(90,75,226)", CssVariable = "--mud-palette-primary-darken"  },
                new ThemeSelection{ Id = 41, CustomThemeId = 1, OrderPriority = 1, ThemeName = "PrimaryLighten", ThemeType = "MudColor", LightValue = "rgb(118,106,231)", DarkValue="rgb(151,141,236)", CssVariable = "--mud-palette-primary-lighten"  },
                new ThemeSelection{ Id = 42, CustomThemeId = 1, OrderPriority = 2, ThemeName = "SecondaryDarken", ThemeType = "MudColor", LightValue = "rgb(255,31,105)", CssVariable = "--mud-palette-secondary-darken"  },
                new ThemeSelection{ Id = 43, CustomThemeId = 1, OrderPriority = 2, ThemeName = "SecondaryLighten", ThemeType = "MudColor", LightValue = "rgb(255,102,153)", CssVariable = "--mud-palette-secondary-lighten"  },
                new ThemeSelection{ Id = 44, CustomThemeId = 1, OrderPriority = 3, ThemeName = "TertiaryDarken", ThemeType = "MudColor", LightValue = "rgb(25,169,140)", CssVariable = "--mud-palette-tertiary-darken"  },
                new ThemeSelection{ Id = 45, CustomThemeId = 1, OrderPriority = 3, ThemeName = "TertiaryLighten", ThemeType = "MudColor", LightValue = "rgb(42,223,187)", CssVariable = "--mud-palette-tertiary-lighten"  },
                new ThemeSelection{ Id = 46, CustomThemeId = 1, OrderPriority = 4, ThemeName = "InfoDarken", ThemeType = "MudColor", LightValue = "rgb(12,128,223)", DarkValue="rgb(10,133,255)", CssVariable = "--mud-palette-info-darken"  },
                new ThemeSelection{ Id = 47, CustomThemeId = 1, OrderPriority = 4, ThemeName = "InfoLighten", ThemeType = "MudColor", LightValue = "rgb(71,167,245)", DarkValue="rgb(92,173,255)", CssVariable = "--mud-palette-info-lighten"  },
                new ThemeSelection{ Id = 48, CustomThemeId = 1, OrderPriority = 5, ThemeName = "SuccessDarken", ThemeType = "MudColor", LightValue = "rgb(0,163,68)", DarkValue="rgb(9,154,108)", CssVariable = "--mud-palette-success-darken"  },
                new ThemeSelection{ Id = 49, CustomThemeId = 1, OrderPriority = 5, ThemeName = "SuccessLighten", ThemeType = "MudColor", LightValue = "rgb(0,235,98)", DarkValue="rgb(13,222,156)", CssVariable = "--mud-palette-success-lighten"  },
                new ThemeSelection{ Id = 50, CustomThemeId = 1, OrderPriority = 6, ThemeName = "WarningDarken", ThemeType = "MudColor", LightValue = "rgb(214,129,0)", DarkValue="rgb(214,143,0)", CssVariable = "--mud-palette-warning-darken"  },
                new ThemeSelection{ Id = 51, CustomThemeId = 1, OrderPriority = 6, ThemeName = "WarningLighten", ThemeType = "MudColor", LightValue = "rgb(255,167,36)", DarkValue="rgb(255,182,36)", CssVariable = "--mud-palette-warning-lighten"  },
                new ThemeSelection{ Id = 52, CustomThemeId = 1, OrderPriority = 7, ThemeName = "ErrorDarken", ThemeType = "MudColor", LightValue = "rgb(242,28,13)", DarkValue="rgb(244,47,70)", CssVariable = "--mud-palette-error-darken"  },
                new ThemeSelection{ Id = 53, CustomThemeId = 1, OrderPriority = 7, ThemeName = "ErrorLighten", ThemeType = "MudColor", LightValue = "rgb(246,96,85)", DarkValue="rgb(248,119,134)", CssVariable = "--mud-palette-error-lighten"  },
                new ThemeSelection{ Id = 54, CustomThemeId = 1, OrderPriority = 8, ThemeName = "DarkDarken", ThemeType = "MudColor", LightValue = "rgb(46,46,46)", DarkValue="rgb(23,23,28)", CssVariable = "--mud-palette-dark-darken"  },
                new ThemeSelection{ Id = 55, CustomThemeId = 1, OrderPriority = 8, ThemeName = "DarkLighten", ThemeType = "MudColor", LightValue = "rgb(87,87,87)", DarkValue="rgb(56,56,67)", CssVariable = "--mud-palette-dark-lighten"  },
                new ThemeSelection{ Id = 56, CustomThemeId = 1, OrderPriority = 99, ThemeName = "HoverOpacity", ThemeType = "Double", LightValue = "0.06", CssVariable = "--mud-palette-hover-opacity"  },
                new ThemeSelection{ Id = 57, CustomThemeId = 1, OrderPriority = 99, ThemeName = "RippleOpacity", ThemeType = "Double", LightValue = "0.1", CssVariable = "--mud-palette-ripple-opacity"  },
                new ThemeSelection{ Id = 58, CustomThemeId = 1, OrderPriority = 99, ThemeName = "RippleOpacitySecondary", ThemeType = "Double", LightValue = "0.2", CssVariable = "--mud-palette-ripple-opacity-secondary"  },
                new ThemeSelection{ Id = 59, CustomThemeId = 1, OrderPriority = 99, ThemeName = "GrayDefault", ThemeType = "MudColor", LightValue = "#9E9E9E", CssVariable = "--mud-palette-gray-default"  },
                new ThemeSelection{ Id = 60, CustomThemeId = 1, OrderPriority = 99, ThemeName = "GrayLight", ThemeType = "MudColor", LightValue = "#BDBDBD", CssVariable = "--mud-palette-gray-light"  },
                new ThemeSelection{ Id = 61, CustomThemeId = 1, OrderPriority = 99, ThemeName = "GrayLighter", ThemeType = "MudColor", LightValue = "#E0E0E0", CssVariable = "--mud-palette-gray-lighter"  },
                new ThemeSelection{ Id = 62, CustomThemeId = 1, OrderPriority = 99, ThemeName = "GrayDark", ThemeType = "MudColor", LightValue = "#757575", CssVariable = "--mud-palette-gray-dark"  },
                new ThemeSelection{ Id = 63, CustomThemeId = 1, OrderPriority = 99, ThemeName = "GrayDarker", ThemeType = "MudColor", LightValue = "#616161", CssVariable = "--mud-palette-gray-darker"  },
                new ThemeSelection{ Id = 64, CustomThemeId = 1, OrderPriority = 99, ThemeName = "OverlayDark", ThemeType = "MudColor", LightValue = "rgba(33,33,33,0.4980392156862745)", CssVariable = "--mud-palette-overlay-dark"  },
                new ThemeSelection{ Id = 65, CustomThemeId = 1, OrderPriority = 99, ThemeName = "OverlayLight", ThemeType = "MudColor", LightValue = "rgba(255,255,255,0.4980392156862745)", CssVariable = "--mud-palette-overlay-light" },
            ];
        }

        public static List<CustomShadow> GetCustomShadows()
        {
            return
            [
                new CustomShadow{ Id = 1, Name = "Elevation", CustomThemeId = 1, Index = 0, Default = "none", CssVariable = "--mud-elevation-0" },
                new CustomShadow{ Id = 2, Name = "Elevation", CustomThemeId = 1, Index = 1, Default = "0px 2px 1px -1px rgba(0,0,0,0.2),0px 1px 1px 0px rgba(0,0,0,0.14),0px 1px 3px 0px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-1" },
                new CustomShadow{ Id = 3, Name = "Elevation", CustomThemeId = 1, Index = 2, Default = "0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-2" },
                new CustomShadow{ Id = 4, Name = "Elevation", CustomThemeId = 1, Index = 3, Default = "0px 3px 3px -2px rgba(0,0,0,0.2),0px 3px 4px 0px rgba(0,0,0,0.14),0px 1px 8px 0px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-3" },
                new CustomShadow{ Id = 5, Name = "Elevation", CustomThemeId = 1, Index = 4, Default = "0px 2px 4px -1px rgba(0,0,0,0.2),0px 4px 5px 0px rgba(0,0,0,0.14),0px 1px 10px 0px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-4" },
                new CustomShadow{ Id = 6, Name = "Elevation", CustomThemeId = 1, Index = 5, Default = "0px 3px 5px -1px rgba(0,0,0,0.2),0px 5px 8px 0px rgba(0,0,0,0.14),0px 1px 14px 0px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-5" },
                new CustomShadow{ Id = 7, Name = "Elevation", CustomThemeId = 1, Index = 6, Default = "0px 3px 5px -1px rgba(0,0,0,0.2),0px 6px 10px 0px rgba(0,0,0,0.14),0px 1px 18px 0px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-6" },
                new CustomShadow{ Id = 8, Name = "Elevation", CustomThemeId = 1, Index = 7, Default = "0px 4px 5px -2px rgba(0,0,0,0.2),0px 7px 10px 1px rgba(0,0,0,0.14),0px 2px 16px 1px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-7" },
                new CustomShadow{ Id = 9, Name = "Elevation", CustomThemeId = 1, Index = 8, Default = "0px 5px 5px -3px rgba(0,0,0,0.2),0px 8px 10px 1px rgba(0,0,0,0.14),0px 3px 14px 2px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-8" },
                new CustomShadow{ Id = 10, Name = "Elevation", CustomThemeId = 1, Index = 9, Default = "0px 5px 6px -3px rgba(0,0,0,0.2),0px 9px 12px 1px rgba(0,0,0,0.14),0px 3px 16px 2px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-9" },
                new CustomShadow{ Id = 11, Name = "Elevation", CustomThemeId = 1, Index = 10, Default = "0px 6px 6px -3px rgba(0,0,0,0.2),0px 10px 14px 1px rgba(0,0,0,0.14),0px 4px 18px 3px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-10" },
                new CustomShadow{ Id = 12, Name = "Elevation", CustomThemeId = 1, Index = 11, Default = "0px 6px 7px -4px rgba(0,0,0,0.2),0px 11px 15px 1px rgba(0,0,0,0.14),0px 4px 20px 3px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-11" },
                new CustomShadow{ Id = 13, Name = "Elevation", CustomThemeId = 1, Index = 12, Default = "0px 7px 8px -4px rgba(0,0,0,0.2),0px 12px 17px 2px rgba(0,0,0,0.14),0px 5px 22px 4px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-12" },
                new CustomShadow{ Id = 14, Name = "Elevation", CustomThemeId = 1, Index = 13, Default = "0px 7px 8px -4px rgba(0,0,0,0.2),0px 13px 19px 2px rgba(0,0,0,0.14),0px 5px 24px 4px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-13" },
                new CustomShadow{ Id = 15, Name = "Elevation", CustomThemeId = 1, Index = 14, Default = "0px 7px 9px -4px rgba(0,0,0,0.2),0px 14px 21px 2px rgba(0,0,0,0.14),0px 5px 26px 4px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-14" },
                new CustomShadow{ Id = 16, Name = "Elevation", CustomThemeId = 1, Index = 15, Default = "0px 8px 9px -5px rgba(0,0,0,0.2),0px 15px 22px 2px rgba(0,0,0,0.14),0px 6px 28px 5px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-15" },
                new CustomShadow{ Id = 17, Name = "Elevation", CustomThemeId = 1, Index = 16, Default = "0px 8px 10px -5px rgba(0,0,0,0.2),0px 16px 24px 2px rgba(0,0,0,0.14),0px 6px 30px 5px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-16" },
                new CustomShadow{ Id = 18, Name = "Elevation", CustomThemeId = 1, Index = 17, Default = "0px 8px 11px -5px rgba(0,0,0,0.2),0px 17px 26px 2px rgba(0,0,0,0.14),0px 6px 32px 5px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-17" },
                new CustomShadow{ Id = 19, Name = "Elevation", CustomThemeId = 1, Index = 18, Default = "0px 9px 11px -5px rgba(0,0,0,0.2),0px 18px 28px 2px rgba(0,0,0,0.14),0px 7px 34px 6px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-18" },
                new CustomShadow{ Id = 20, Name = "Elevation", CustomThemeId = 1, Index = 19, Default = "0px 9px 12px -6px rgba(0,0,0,0.2),0px 19px 29px 2px rgba(0,0,0,0.14),0px 7px 36px 6px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-19" },
                new CustomShadow{ Id = 21, Name = "Elevation", CustomThemeId = 1, Index = 20, Default = "0px 10px 13px -6px rgba(0,0,0,0.2),0px 20px 31px 3px rgba(0,0,0,0.14),0px 8px 38px 7px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-20" },
                new CustomShadow{ Id = 22, Name = "Elevation", CustomThemeId = 1, Index = 21, Default = "0px 10px 13px -6px rgba(0,0,0,0.2),0px 21px 33px 3px rgba(0,0,0,0.14),0px 8px 40px 7px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-21" },
                new CustomShadow{ Id = 23, Name = "Elevation", CustomThemeId = 1, Index = 22, Default = "0px 10px 14px -6px rgba(0,0,0,0.2),0px 22px 35px 3px rgba(0,0,0,0.14),0px 8px 42px 7px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-22" },
                new CustomShadow{ Id = 24, Name = "Elevation", CustomThemeId = 1, Index = 23, Default = "0px 11px 14px -7px rgba(0,0,0,0.2),0px 23px 36px 3px rgba(0,0,0,0.14),0px 9px 44px 8px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-23" },
                new CustomShadow{ Id = 25, Name = "Elevation", CustomThemeId = 1, Index = 24, Default = "0px 11px 15px -7px rgba(0,0,0,0.2),0px 24px 38px 3px rgba(0,0,0,0.14),0px 9px 46px 8px rgba(0,0,0,0.12)", CssVariable = "--mud-elevation-24" },
                new CustomShadow{ Id = 26, Name = "Elevation", CustomThemeId = 1, Index = 25, Default = "0 5px 5px -3px rgba(0,0,0,.06), 0 8px 10px 1px rgba(0,0,0,.042), 0 3px 14px 2px rgba(0,0,0,.036)", CssVariable = "--mud-elevation-25" },
            ];
        }

        public static List<CustomLayoutProperty> GetCustomLayoutProperties()
        {
            return
            [
                new CustomLayoutProperty { Id = 1, CustomThemeId = 1, Name = "DefaultBorderRadius", Default = 4, Min = 0, Max = 10, CssVariable = "--mud-default-borderradius" },
                new CustomLayoutProperty { Id = 2, CustomThemeId = 1, Name = "DrawerMiniWidthLeft", Default = 56, Min = 0, Max = 100, CssVariable = "--mud-drawer-mini-width-left" },
                new CustomLayoutProperty { Id = 3, CustomThemeId = 1, Name = "DrawerMiniWidthRight", Default = 56, Min = 0, Max = 100, CssVariable = "--mud-drawer-mini-width-right" },
                new CustomLayoutProperty { Id = 4, CustomThemeId = 1, Name = "DrawerWidthLeft", Default = 240, Min=0, Max= 500, CssVariable = "--mud-drawer-width-left" },
                new CustomLayoutProperty { Id = 5, CustomThemeId = 1, Name = "DrawerWidthRight", Default = 240, Min=0, Max = 500, CssVariable = "--mud-drawer-width-right" },
                new CustomLayoutProperty { Id = 6, CustomThemeId = 1, Name = "AppbarHeight", Default = 64, Min = 0, Max = 200, CssVariable = "--mud-appbar-height" },
            ];
        }

        public static List<CustomTypography> GetCustomTypographies()
        {
            return
            [
				// Default
				new CustomTypography { Id = 1, CustomThemeId = 1, TypoType = "Default", Name="FontFamily", DataType = "String[]", Default = "Roboto, Helvetica, Arial, sans-serif", CssVariable = "--mud-typography-default-family" },
                new CustomTypography { Id = 2, CustomThemeId = 1, TypoType = "Default", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-default-weight" },
                new CustomTypography { Id = 3, CustomThemeId = 1, TypoType = "Default", Name="FontSize", DataType = "String", Default = ".875rem", CssVariable = "--mud-typography-default-size" },
                new CustomTypography { Id = 4, CustomThemeId = 1, TypoType = "Default", Name="LineHeight", DataType = "Double", Default = "1.43", CssVariable = "--mud-typography-default-lineheight" },
                new CustomTypography { Id = 5, CustomThemeId = 1, TypoType = "Default", Name="LetterSpacing", DataType = "String", Default = ".01071em", CssVariable = "--mud-typography-default-letterspacing" },
                new CustomTypography { Id = 6, CustomThemeId = 1, TypoType = "Default", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-default-text-transform" },
        
				// H1
				new CustomTypography { Id = 7, CustomThemeId = 1, TypoType = "H1", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-h1-family" },
                new CustomTypography { Id = 8, CustomThemeId = 1, TypoType = "H1", Name="FontWeight", DataType = "Int32", Default = "300", CssVariable = "--mud-typography-h1-weight" },
                new CustomTypography { Id = 9, CustomThemeId = 1, TypoType = "H1", Name="FontSize", DataType = "String", Default = "6rem", CssVariable = "--mud-typography-h1-size" },
                new CustomTypography { Id = 10, CustomThemeId = 1, TypoType = "H1", Name="LineHeight", DataType = "Double", Default = "1.167", CssVariable = "--mud-typography-h1-lineheight" },
                new CustomTypography { Id = 11, CustomThemeId = 1, TypoType = "H1", Name="LetterSpacing", DataType = "String", Default = "-.01562em", CssVariable = "--mud-typography-h1-letterspacing" },
                new CustomTypography { Id = 12, CustomThemeId = 1, TypoType = "H1", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-h1-text-transform" },
        
				// H2
				new CustomTypography { Id = 13, CustomThemeId = 1, TypoType = "H2", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-h2-family" },
                new CustomTypography { Id = 14, CustomThemeId = 1, TypoType = "H2", Name="FontWeight", DataType = "Int32", Default = "300", CssVariable = "--mud-typography-h2-weight" },
                new CustomTypography { Id = 15, CustomThemeId = 1, TypoType = "H2", Name="FontSize", DataType = "String", Default = "3.75rem", CssVariable = "--mud-typography-h2-size" },
                new CustomTypography { Id = 16, CustomThemeId = 1, TypoType = "H2", Name="LineHeight", DataType = "Double", Default = "1.2", CssVariable = "--mud-typography-h2-lineheight" },
                new CustomTypography { Id = 17, CustomThemeId = 1, TypoType = "H2", Name="LetterSpacing", DataType = "String", Default = "-.00833em", CssVariable = "--mud-typography-h2-letterspacing" },
                new CustomTypography { Id = 18, CustomThemeId = 1, TypoType = "H2", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-h2-text-transform" },
        
				// H3
				new CustomTypography { Id = 19, CustomThemeId = 1, TypoType = "H3", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-h3-family" },
                new CustomTypography { Id = 20, CustomThemeId = 1, TypoType = "H3", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-h3-weight" },
                new CustomTypography { Id = 21, CustomThemeId = 1, TypoType = "H3", Name="FontSize", DataType = "String", Default = "3rem", CssVariable = "--mud-typography-h3-size" },
                new CustomTypography { Id = 22, CustomThemeId = 1, TypoType = "H3", Name="LineHeight", DataType = "Double", Default = "1.167", CssVariable = "--mud-typography-h3-lineheight" },
                new CustomTypography { Id = 23, CustomThemeId = 1, TypoType = "H3", Name="LetterSpacing", DataType = "String", Default = "0", CssVariable = "--mud-typography-h3-letterspacing" },
                new CustomTypography { Id = 24, CustomThemeId = 1, TypoType = "H3", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-h3-text-transform" },

				// H4
				new CustomTypography { Id = 25, CustomThemeId = 1, TypoType = "H4", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-h4-family" },
                new CustomTypography { Id = 26, CustomThemeId = 1, TypoType = "H4", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-h4-weight" },
                new CustomTypography { Id = 27, CustomThemeId = 1, TypoType = "H4", Name="FontSize", DataType = "String", Default = "2.125rem", CssVariable = "--mud-typography-h4-size" },
                new CustomTypography { Id = 28, CustomThemeId = 1, TypoType = "H4", Name="LineHeight", DataType = "Double", Default = "1.235", CssVariable = "--mud-typography-h4-lineheight" },
                new CustomTypography { Id = 29, CustomThemeId = 1, TypoType = "H4", Name="LetterSpacing", DataType = "String", Default = ".00735em", CssVariable = "--mud-typography-h4-letterspacing" },
                new CustomTypography { Id = 30, CustomThemeId = 1, TypoType = "H4", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-h4-text-transform" },

				// H5
				new CustomTypography { Id = 31, CustomThemeId = 1, TypoType = "H5", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-h5-family" },
                new CustomTypography { Id = 32, CustomThemeId = 1, TypoType = "H5", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-h5-weight" },
                new CustomTypography { Id = 33, CustomThemeId = 1, TypoType = "H5", Name="FontSize", DataType = "String", Default = "1.5rem", CssVariable = "--mud-typography-h5-size" },
                new CustomTypography { Id = 34, CustomThemeId = 1, TypoType = "H5", Name="LineHeight", DataType = "Double", Default = "1.334", CssVariable = "--mud-typography-h5-lineheight" },
                new CustomTypography { Id = 35, CustomThemeId = 1, TypoType = "H5", Name="LetterSpacing", DataType = "String", Default = "0", CssVariable = "--mud-typography-h5-letterspacing" },
                new CustomTypography { Id = 36, CustomThemeId = 1, TypoType = "H5", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-h5-text-transform" },

				// H6
				new CustomTypography { Id = 37, CustomThemeId = 1, TypoType = "H6", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-h6-family" },
                new CustomTypography { Id = 38, CustomThemeId = 1, TypoType = "H6", Name="FontWeight", DataType = "Int32", Default = "500", CssVariable = "--mud-typography-h6-weight" },
                new CustomTypography { Id = 39, CustomThemeId = 1, TypoType = "H6", Name="FontSize", DataType = "String", Default = "1.25rem", CssVariable = "--mud-typography-h6-size" },
                new CustomTypography { Id = 40, CustomThemeId = 1, TypoType = "H6", Name="LineHeight", DataType = "Double", Default = "1.6", CssVariable = "--mud-typography-h6-lineheight" },
                new CustomTypography { Id = 41, CustomThemeId = 1, TypoType = "H6", Name="LetterSpacing", DataType = "String", Default = ".0075em", CssVariable = "--mud-typography-h6-letterspacing" },
                new CustomTypography { Id = 42, CustomThemeId = 1, TypoType = "H6", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-h6-text-transform" },

				// Subtitle1
				new CustomTypography { Id = 43, CustomThemeId = 1, TypoType = "Subtitle1", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-subtitle1-family" },
                new CustomTypography { Id = 44, CustomThemeId = 1, TypoType = "Subtitle1", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-subtitle1-weight" },
                new CustomTypography { Id = 45, CustomThemeId = 1, TypoType = "Subtitle1", Name="FontSize", DataType = "String", Default = "1rem", CssVariable = "--mud-typography-subtitle1-size" },
                new CustomTypography { Id = 46, CustomThemeId = 1, TypoType = "Subtitle1", Name="LineHeight", DataType = "Double", Default = "1.75", CssVariable = "--mud-typography-subtitle1-lineheight" },
                new CustomTypography { Id = 47, CustomThemeId = 1, TypoType = "Subtitle1", Name="LetterSpacing", DataType = "String", Default = ".00938em", CssVariable = "--mud-typography-subtitle1-letterspacing" },
                new CustomTypography { Id = 48, CustomThemeId = 1, TypoType = "Subtitle1", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-subtitle1-text-transform" },

				// Subtitle2
				new CustomTypography { Id = 49, CustomThemeId = 1, TypoType = "Subtitle2", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-subtitle2-family" },
                new CustomTypography { Id = 50, CustomThemeId = 1, TypoType = "Subtitle2", Name="FontWeight", DataType = "Int32", Default = "500", CssVariable = "--mud-typography-subtitle2-weight" },
                new CustomTypography { Id = 51, CustomThemeId = 1, TypoType = "Subtitle2", Name="FontSize", DataType = "String", Default = ".875rem", CssVariable = "--mud-typography-subtitle2-size" },
                new CustomTypography { Id = 52, CustomThemeId = 1, TypoType = "Subtitle2", Name="LineHeight", DataType = "Double", Default = "1.57", CssVariable = "--mud-typography-subtitle2-lineheight" },
                new CustomTypography { Id = 53, CustomThemeId = 1, TypoType = "Subtitle2", Name="LetterSpacing", DataType = "String", Default = ".00714em", CssVariable = "--mud-typography-subtitle2-letterspacing" },
                new CustomTypography { Id = 54, CustomThemeId = 1, TypoType = "Subtitle2", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-subtitle2-text-transform" },

				// Body1
				new CustomTypography { Id = 55, CustomThemeId = 1, TypoType = "Body1", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-body1-family" },
                new CustomTypography { Id = 56, CustomThemeId = 1, TypoType = "Body1", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-body1-weight" },
                new CustomTypography { Id = 57, CustomThemeId = 1, TypoType = "Body1", Name="FontSize", DataType = "String", Default = "1rem", CssVariable = "--mud-typography-body1-size" },
                new CustomTypography { Id = 58, CustomThemeId = 1, TypoType = "Body1", Name="LineHeight", DataType = "Double", Default = "1.5", CssVariable = "--mud-typography-body1-lineheight" },
                new CustomTypography { Id = 59, CustomThemeId = 1, TypoType = "Body1", Name="LetterSpacing", DataType = "String", Default = ".00938em", CssVariable = "--mud-typography-body1-letterspacing" },
                new CustomTypography { Id = 60, CustomThemeId = 1, TypoType = "Body1", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-body1-text-transform" },

				// Body2
				new CustomTypography { Id = 61, CustomThemeId = 1, TypoType = "Body2", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-body2-family" },
                new CustomTypography { Id = 62, CustomThemeId = 1, TypoType = "Body2", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-body2-weight" },
                new CustomTypography { Id = 63, CustomThemeId = 1, TypoType = "Body2", Name="FontSize", DataType = "String", Default = ".875rem", CssVariable = "--mud-typography-body2-size" },
                new CustomTypography { Id = 64, CustomThemeId = 1, TypoType = "Body2", Name="LineHeight", DataType = "Double", Default = "1.43", CssVariable = "--mud-typography-body2-lineheight" },
                new CustomTypography { Id = 65, CustomThemeId = 1, TypoType = "Body2", Name="LetterSpacing", DataType = "String", Default = ".01071em", CssVariable = "--mud-typography-body2-letterspacing" },
                new CustomTypography { Id = 66, CustomThemeId = 1, TypoType = "Body2", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-body2-text-transform" },

				// Input
				new CustomTypography { Id = 67, CustomThemeId = 1, TypoType = "Input", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-input-family" },
                new CustomTypography { Id = 68, CustomThemeId = 1, TypoType = "Input", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-input-weight" },
                new CustomTypography { Id = 69, CustomThemeId = 1, TypoType = "Input", Name="FontSize", DataType = "String", Default = "1rem", CssVariable = "--mud-typography-input-size" },
                new CustomTypography { Id = 70, CustomThemeId = 1, TypoType = "Input", Name="LineHeight", DataType = "Double", Default = "1.1876", CssVariable = "--mud-typography-input-lineheight" },
                new CustomTypography { Id = 71, CustomThemeId = 1, TypoType = "Input", Name="LetterSpacing", DataType = "String", Default = ".00938em", CssVariable = "--mud-typography-input-letterspacing" },
                new CustomTypography { Id = 72, CustomThemeId = 1, TypoType = "Input", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-input-text-transform" },

				// Button
				new CustomTypography { Id = 73, CustomThemeId = 1, TypoType = "Button", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-button-family" },
                new CustomTypography { Id = 74, CustomThemeId = 1, TypoType = "Button", Name="FontWeight", DataType = "Int32", Default = "500", CssVariable = "--mud-typography-button-weight" },
                new CustomTypography { Id = 75, CustomThemeId = 1, TypoType = "Button", Name="FontSize", DataType = "String", Default = ".875rem", CssVariable = "--mud-typography-button-size" },
                new CustomTypography { Id = 76, CustomThemeId = 1, TypoType = "Button", Name="LineHeight", DataType = "Double", Default = "1.75", CssVariable = "--mud-typography-button-lineheight" },
                new CustomTypography { Id = 77, CustomThemeId = 1, TypoType = "Button", Name="LetterSpacing", DataType = "String", Default = ".02857em", CssVariable = "--mud-typography-button-letterspacing" },
                new CustomTypography { Id = 78, CustomThemeId = 1, TypoType = "Button", Name="TextTransform", DataType = "String", Default = "uppercase", CssVariable = "--mud-typography-button-text-transform" },

				// Caption
				new CustomTypography { Id = 79, CustomThemeId = 1, TypoType = "Caption", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-caption-family" },
                new CustomTypography { Id = 80, CustomThemeId = 1, TypoType = "Caption", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-caption-weight" },
                new CustomTypography { Id = 81, CustomThemeId = 1, TypoType = "Caption", Name="FontSize", DataType = "String", Default = ".75rem", CssVariable = "--mud-typography-caption-size" },
                new CustomTypography { Id = 82, CustomThemeId = 1, TypoType = "Caption", Name="LineHeight", DataType = "Double", Default = "1.66", CssVariable = "--mud-typography-caption-lineheight" },
                new CustomTypography { Id = 83, CustomThemeId = 1, TypoType = "Caption", Name="LetterSpacing", DataType = "String", Default = ".03333em", CssVariable = "--mud-typography-caption-letterspacing" },
                new CustomTypography { Id = 84, CustomThemeId = 1, TypoType = "Caption", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-caption-text-transform" },

				// Overline
				new CustomTypography { Id = 85, CustomThemeId = 1, TypoType = "Overline", Name="FontFamily", DataType = "String[]", Default = "", CssVariable = "--mud-typography-overline-family" },
                new CustomTypography { Id = 86, CustomThemeId = 1, TypoType = "Overline", Name="FontWeight", DataType = "Int32", Default = "400", CssVariable = "--mud-typography-overline-weight" },
                new CustomTypography { Id = 87, CustomThemeId = 1, TypoType = "Overline", Name="FontSize", DataType = "String", Default = ".75rem", CssVariable = "--mud-typography-overline-size" },
                new CustomTypography { Id = 88, CustomThemeId = 1, TypoType = "Overline", Name="LineHeight", DataType = "Double", Default = "2.66", CssVariable = "--mud-typography-overline-lineheight" },
                new CustomTypography { Id = 89, CustomThemeId = 1, TypoType = "Overline", Name="LetterSpacing", DataType = "String", Default = ".08333em", CssVariable = "--mud-typography-overline-letterspacing" },
                new CustomTypography { Id = 90, CustomThemeId = 1, TypoType = "Overline", Name="TextTransform", DataType = "String", Default = "none", CssVariable = "--mud-typography-overline-text-transform" }
            ];
        }

        public static List<CustomZIndex> GetCustomZIndexes()
        {
            return
            [
                new CustomZIndex { Id = 1, CustomThemeId = 1, Name = "Drawer", Default = "1100", CssVariable = "--mud-zindex-drawer"},
                new CustomZIndex { Id = 2, CustomThemeId = 1, Name = "Popover", Default = "1200", CssVariable = "--mud-zindex-popover"},
                new CustomZIndex { Id = 3, CustomThemeId = 1, Name = "AppBar", Default = "1300", CssVariable = "--mud-zindex-appbar"},
                new CustomZIndex { Id = 4, CustomThemeId = 1, Name = "Dialog", Default = "1400", CssVariable = "--mud-zindex-dialog"},
                new CustomZIndex { Id = 5, CustomThemeId = 1, Name = "Snackbar", Default = "1500", CssVariable = "--mud-zindex-snackbar"},
                new CustomZIndex { Id = 6, CustomThemeId = 1, Name = "Tooltip", Default = "1600", CssVariable = "--mud-zindex-tooltip"},
            ];
        }

        public static List<MappedTheme> GetMappedThemes()
        {
            return
            [
                new MappedTheme { Id = 1, Name = "Bootstrap to MudBlazor" }
            ];
        }

        public static List<MappedCssVariables> GetMappedCssVariables()
        {
            return
        [
            // Colors
            new MappedCssVariables { Id = 1, MappedThemeId = 1, NativeCssVariable = "--bs-black", MappedCssVariable = "--mud-palette-black" },
            new MappedCssVariables { Id = 2, MappedThemeId = 1, NativeCssVariable = "--bs-white", MappedCssVariable = "--mud-palette-white" },
            new MappedCssVariables { Id = 3, MappedThemeId = 1, NativeCssVariable = "--bs-primary", MappedCssVariable = "--mud-palette-primary" },
            new MappedCssVariables { Id = 4, MappedThemeId = 1, NativeCssVariable = "--bs-primary-bg-subtle", MappedCssVariable = "--mud-palette-primary-text" },
            new MappedCssVariables { Id = 5, MappedThemeId = 1, NativeCssVariable = "--bs-secondary", MappedCssVariable = "--mud-palette-secondary" },
            new MappedCssVariables { Id = 6, MappedThemeId = 1, NativeCssVariable = "--bs-secondary-bg-subtle", MappedCssVariable = "--mud-palette-secondary-text" },
            new MappedCssVariables { Id = 7, MappedThemeId = 1, NativeCssVariable = "--bs-tertiary-color", MappedCssVariable = "--mud-palette-tertiary" },
            new MappedCssVariables { Id = 8, MappedThemeId = 1, NativeCssVariable = "--bs-tertiary-bg", MappedCssVariable = "--mud-palette-tertiary-text" },
            new MappedCssVariables { Id = 9, MappedThemeId = 1, NativeCssVariable = "--bs-info", MappedCssVariable = "--mud-palette-info" },
            new MappedCssVariables { Id = 10, MappedThemeId = 1, NativeCssVariable = "--bs-info-bg-subtle", MappedCssVariable = "--mud-palette-info-text" },
            new MappedCssVariables { Id = 11, MappedThemeId = 1, NativeCssVariable = "--bs-success", MappedCssVariable = "--mud-palette-success" },
            new MappedCssVariables { Id = 12, MappedThemeId = 1, NativeCssVariable = "--bs-success-bg-subtle", MappedCssVariable = "--mud-palette-success-text" },
            new MappedCssVariables { Id = 13, MappedThemeId = 1, NativeCssVariable = "--bs-warning", MappedCssVariable = "--mud-palette-warning" },
            new MappedCssVariables { Id = 14, MappedThemeId = 1, NativeCssVariable = "--bs-warning-bg-subtle", MappedCssVariable = "--mud-palette-warning-text" },
            new MappedCssVariables { Id = 15, MappedThemeId = 1, NativeCssVariable = "--bs-error", MappedCssVariable = "--mud-palette-error" },
            new MappedCssVariables { Id = 16, MappedThemeId = 1, NativeCssVariable = "--bs-error-bg-subtle", MappedCssVariable = "--mud-palette-error-text" },
            new MappedCssVariables { Id = 17, MappedThemeId = 1, NativeCssVariable = "--bs-dark", MappedCssVariable = "--mud-palette-dark" },
            new MappedCssVariables { Id = 18, MappedThemeId = 1, NativeCssVariable = "--bs-dark-bg-subtle", MappedCssVariable = "--mud-palette-dark-text" },
            new MappedCssVariables { Id = 19, MappedThemeId = 1, NativeCssVariable = "--bs-primary-text-emphasis", MappedCssVariable = "--mud-palette-text-primary" },
            new MappedCssVariables { Id = 20, MappedThemeId = 1, NativeCssVariable = "--bs-secondary-text-emphasis", MappedCssVariable = "--mud-palette-text-secondary" },
            new MappedCssVariables { Id = 21, MappedThemeId = 1, NativeCssVariable = "--bs-primary-text-emphasis", MappedCssVariable = "--mud-palette-primary-darken" },
            new MappedCssVariables { Id = 22, MappedThemeId = 1, NativeCssVariable = "--bs-primary-bg-subtle", MappedCssVariable = "--mud-palette-primary-lighten" },
            new MappedCssVariables { Id = 23, MappedThemeId = 1, NativeCssVariable = "--bs-secondary-text-emphasis", MappedCssVariable = "--mud-palette-secondary-darken" },
            new MappedCssVariables { Id = 24, MappedThemeId = 1, NativeCssVariable = "--bs-secondary-bg-subtle", MappedCssVariable = "--mud-palette-secondary-lighten" },
            new MappedCssVariables { Id = 25, MappedThemeId = 1, NativeCssVariable = "--bs-tertiary-color", MappedCssVariable = "--mud-palette-tertiary-darken" },
            new MappedCssVariables { Id = 26, MappedThemeId = 1, NativeCssVariable = "--bs-tertiary-color", MappedCssVariable = "--mud-palette-tertiary-lighten" },
            new MappedCssVariables { Id = 27, MappedThemeId = 1, NativeCssVariable = "--bs-info-text-emphasis", MappedCssVariable = "--mud-palette-info-darken" },
            new MappedCssVariables { Id = 28, MappedThemeId = 1, NativeCssVariable = "--bs-info-bg-subtle", MappedCssVariable = "--mud-palette-info-lighten" },
            new MappedCssVariables { Id = 29, MappedThemeId = 1, NativeCssVariable = "--bs-success-text-emphasis", MappedCssVariable = "--mud-palette-success-darken" },
            new MappedCssVariables { Id = 30, MappedThemeId = 1, NativeCssVariable = "--bs-success-bg-subtle", MappedCssVariable = "--mud-palette-success-lighten" },
            new MappedCssVariables { Id = 31, MappedThemeId = 1, NativeCssVariable = "--bs-warning-text-emphasis", MappedCssVariable = "--mud-palette-warning-darken" },
            new MappedCssVariables { Id = 32, MappedThemeId = 1, NativeCssVariable = "--bs-warning-bg-subtle", MappedCssVariable = "--mud-palette-warning-lighten" },
            new MappedCssVariables { Id = 33, MappedThemeId = 1, NativeCssVariable = "--bs-error-text-emphasis", MappedCssVariable = "--mud-palette-error-darken" },
            new MappedCssVariables { Id = 34, MappedThemeId = 1, NativeCssVariable = "--bs-error-bg-subtle", MappedCssVariable = "--mud-palette-error-lighten" },

            // appbar and drawer
            new MappedCssVariables { Id = 35, MappedThemeId = 1, NativeCssVariable = "--bs-primary", MappedCssVariable = "--mud-palette-appbar-text" },
            new MappedCssVariables { Id = 36, MappedThemeId = 1, NativeCssVariable = "--bs-primary-bg-subtle", MappedCssVariable = "--mud-palette-appbar-background" },
            new MappedCssVariables { Id = 37, MappedThemeId = 1, NativeCssVariable = "--bs-secondary", MappedCssVariable = "--mud-palette-drawer-text" },
            new MappedCssVariables { Id = 38, MappedThemeId = 1, NativeCssVariable = "--bs-secondary-bg-subtle", MappedCssVariable = "--mud-palette-drawer-background" },
            new MappedCssVariables { Id = 39, MappedThemeId = 1, NativeCssVariable = "--bs-secondary", MappedCssVariable = "--mud-palette-drawer-icon" },

            // Body
            new MappedCssVariables { Id = 40, MappedThemeId = 1, NativeCssVariable = "--bs-body-font-size", MappedCssVariable = "--mud-typography-body1-size" },
            new MappedCssVariables { Id = 41, MappedThemeId = 1, NativeCssVariable = "--bs-body-font-weight", MappedCssVariable = "--mud-typography-body1-weight" },
            new MappedCssVariables { Id = 42, MappedThemeId = 1, NativeCssVariable = "--bs-body-line-height", MappedCssVariable = "--mud-typography-body1-lineheight" },

            // Button
            new MappedCssVariables { Id = 43, MappedThemeId = 1, NativeCssVariable = "--bs-btn-font-weight", MappedCssVariable = "--mud-typography-button-weight" },
            new MappedCssVariables { Id = 44, MappedThemeId = 1, NativeCssVariable = "--bs-btn-font-size", MappedCssVariable = "--mud-typography-button-size" },
            new MappedCssVariables { Id = 45, MappedThemeId = 1, NativeCssVariable = "--bs-btn-line-height", MappedCssVariable = "--mud-typography-button-lineheight" },
        ];
        }
    }
}