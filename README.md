# Theme Creator / Generator for MudBlazor

[![GitHub](https://img.shields.io/github/license/versile2/ThemeCreatorMudBlazor?color=594ae2&style=flat-square&logo=github)](https://github.com/versile2/ThemeCreatorMudBlazor?tab=MIT-1-ov-file)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)

Blazor Theme Creator site for MudBlazor library. This app is designed to be used to create and manage themes for MudBlazor, not as part of your application.

**You can navigate to https://themes.arctechonline.tech/ to use the app.**

## Prerequisites
- [MudBlazor](https://www.mudblazor.com/getting-started/installation) Installed and configurated.
  - Currently compatible with versions 6.x and 7.x of MudBlazor
  - Expected compatibility with 8.x of MudBlazor shortly after release
    - Will maintain backwards compatibility with 6.x and 7.x of MudBlazor

## Usage
1. Navigate to https://themes.arctechonline.tech/
2. Design, reuse, or customize a theme of your choosing. If you intend on using a light/dark mode ensure both palettes are filled out.
3. Once you're happy with your theme, click the "Export" icon to export the theme.
4. Insert the static theme in a CustomThemes class in your project.
5. Set your MudThemeManager to use your custom theme (replacing MySavedTheme with the name of your theme)
```html
<MudThemeProvider Theme="@CustomThemes.MySavedTheme" />
```

## Issues / Enhancements / Bugs
If you encounter any issues, bugs, or want enhancements, please open an issue on the [GitHub repository](https://github.com/versile2/ThemeCreatorMudBlazor/issues).

## About

This project is maintained by [Versile](https://github.com/versile2) Any questions or comments, please contact me on [Discord](https://discord.gg/mudblazor) **@Jilael**
