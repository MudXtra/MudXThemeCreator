using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomLayoutProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomThemeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Default = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    CssVariable = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomLayoutProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomShadows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomThemeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Default = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    CssVariable = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomShadows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    CreatedWhen = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomThemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomTypographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomThemeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    TypoType = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    DataType = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Default = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    CssVariable = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTypographies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomZIndexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomThemeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Default = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    CssVariable = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomZIndexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemePalettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemePalettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemeSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomThemeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ThemePaletteId = table.Column<int>(type: "INTEGER", nullable: true),
                    ThemeOptionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ThemeName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    ThemeType = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    LightValue = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    DarkValue = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    CssVariable = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeSelections", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CustomLayoutProperties",
                columns: new[] { "Id", "CssVariable", "CustomThemeId", "Default", "Name" },
                values: new object[,]
                {
                    { 1, "--mud-default-border-radius", 1, "4px", "DefaultBorderRadius" },
                    { 2, "--mud-drawer-mini-width-left", 1, "56px", "DrawerMiniWidthLeft" },
                    { 3, "--mud-drawer-mini-width-right", 1, "56px", "DrawerMiniWidthRight" },
                    { 4, "--mud-drawer-width-left", 1, "2404px", "DrawerWidthLeft" },
                    { 5, "--mud-drawer-width-right", 1, "240px", "DrawerWidthRight" },
                    { 6, "--mud-appbar-height", 1, "64px", "AppbarHeight" }
                });

            migrationBuilder.InsertData(
                table: "CustomShadows",
                columns: new[] { "Id", "CssVariable", "CustomThemeId", "Default", "Index", "Name" },
                values: new object[,]
                {
                    { 1, "--mud-elevation-0", 1, "none", 0, "Elevation" },
                    { 2, "--mud-elevation-1", 1, "0px 2px 1px -1px rgba(0,0,0,0.2),0px 1px 1px 0px rgba(0,0,0,0.14),0px 1px 3px 0px rgba(0,0,0,0.12)", 1, "Elevation" },
                    { 3, "--mud-elevation-2", 1, "0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12)", 2, "Elevation" },
                    { 4, "--mud-elevation-3", 1, "0px 3px 3px -2px rgba(0,0,0,0.2),0px 3px 4px 0px rgba(0,0,0,0.14),0px 1px 8px 0px rgba(0,0,0,0.12)", 3, "Elevation" },
                    { 5, "--mud-elevation-4", 1, "0px 2px 4px -1px rgba(0,0,0,0.2),0px 4px 5px 0px rgba(0,0,0,0.14),0px 1px 10px 0px rgba(0,0,0,0.12)", 4, "Elevation" },
                    { 6, "--mud-elevation-5", 1, "0px 3px 5px -1px rgba(0,0,0,0.2),0px 5px 8px 0px rgba(0,0,0,0.14),0px 1px 14px 0px rgba(0,0,0,0.12)", 5, "Elevation" },
                    { 7, "--mud-elevation-6", 1, "0px 3px 5px -1px rgba(0,0,0,0.2),0px 6px 10px 0px rgba(0,0,0,0.14),0px 1px 18px 0px rgba(0,0,0,0.12)", 6, "Elevation" },
                    { 8, "--mud-elevation-7", 1, "0px 4px 5px -2px rgba(0,0,0,0.2),0px 7px 10px 1px rgba(0,0,0,0.14),0px 2px 16px 1px rgba(0,0,0,0.12)", 7, "Elevation" },
                    { 9, "--mud-elevation-8", 1, "0px 5px 5px -3px rgba(0,0,0,0.2),0px 8px 10px 1px rgba(0,0,0,0.14),0px 3px 14px 2px rgba(0,0,0,0.12)", 8, "Elevation" },
                    { 10, "--mud-elevation-9", 1, "0px 5px 6px -3px rgba(0,0,0,0.2),0px 9px 12px 1px rgba(0,0,0,0.14),0px 3px 16px 2px rgba(0,0,0,0.12)", 9, "Elevation" },
                    { 11, "--mud-elevation-10", 1, "0px 6px 6px -3px rgba(0,0,0,0.2),0px 10px 14px 1px rgba(0,0,0,0.14),0px 4px 18px 3px rgba(0,0,0,0.12)", 10, "Elevation" },
                    { 12, "--mud-elevation-11", 1, "0px 6px 7px -4px rgba(0,0,0,0.2),0px 11px 15px 1px rgba(0,0,0,0.14),0px 4px 20px 3px rgba(0,0,0,0.12)", 11, "Elevation" },
                    { 13, "--mud-elevation-12", 1, "0px 7px 8px -4px rgba(0,0,0,0.2),0px 12px 17px 2px rgba(0,0,0,0.14),0px 5px 22px 4px rgba(0,0,0,0.12)", 12, "Elevation" },
                    { 14, "--mud-elevation-13", 1, "0px 7px 8px -4px rgba(0,0,0,0.2),0px 13px 19px 2px rgba(0,0,0,0.14),0px 5px 24px 4px rgba(0,0,0,0.12)", 13, "Elevation" },
                    { 15, "--mud-elevation-14", 1, "0px 7px 9px -4px rgba(0,0,0,0.2),0px 14px 21px 2px rgba(0,0,0,0.14),0px 5px 26px 4px rgba(0,0,0,0.12)", 14, "Elevation" },
                    { 16, "--mud-elevation-15", 1, "0px 8px 9px -5px rgba(0,0,0,0.2),0px 15px 22px 2px rgba(0,0,0,0.14),0px 6px 28px 5px rgba(0,0,0,0.12)", 15, "Elevation" },
                    { 17, "--mud-elevation-16", 1, "0px 8px 10px -5px rgba(0,0,0,0.2),0px 16px 24px 2px rgba(0,0,0,0.14),0px 6px 30px 5px rgba(0,0,0,0.12)", 16, "Elevation" },
                    { 18, "--mud-elevation-17", 1, "0px 8px 11px -5px rgba(0,0,0,0.2),0px 17px 26px 2px rgba(0,0,0,0.14),0px 6px 32px 5px rgba(0,0,0,0.12)", 17, "Elevation" },
                    { 19, "--mud-elevation-18", 1, "0px 9px 11px -5px rgba(0,0,0,0.2),0px 18px 28px 2px rgba(0,0,0,0.14),0px 7px 34px 6px rgba(0,0,0,0.12)", 18, "Elevation" },
                    { 20, "--mud-elevation-19", 1, "0px 9px 12px -6px rgba(0,0,0,0.2),0px 19px 29px 2px rgba(0,0,0,0.14),0px 7px 36px 6px rgba(0,0,0,0.12)", 19, "Elevation" },
                    { 21, "--mud-elevation-20", 1, "0px 10px 13px -6px rgba(0,0,0,0.2),0px 20px 31px 3px rgba(0,0,0,0.14),0px 8px 38px 7px rgba(0,0,0,0.12)", 20, "Elevation" },
                    { 22, "--mud-elevation-21", 1, "0px 10px 13px -6px rgba(0,0,0,0.2),0px 21px 33px 3px rgba(0,0,0,0.14),0px 8px 40px 7px rgba(0,0,0,0.12)", 21, "Elevation" },
                    { 23, "--mud-elevation-22", 1, "0px 10px 14px -6px rgba(0,0,0,0.2),0px 22px 35px 3px rgba(0,0,0,0.14),0px 8px 42px 7px rgba(0,0,0,0.12)", 22, "Elevation" },
                    { 24, "--mud-elevation-23", 1, "0px 11px 14px -7px rgba(0,0,0,0.2),0px 23px 36px 3px rgba(0,0,0,0.14),0px 9px 44px 8px rgba(0,0,0,0.12)", 23, "Elevation" },
                    { 25, "--mud-elevation-24", 1, "0px 11px 15px -7px rgba(0,0,0,0.2),0px 24px 38px 3px rgba(0,0,0,0.14),0px 9px 46px 8px rgba(0,0,0,0.12)", 24, "Elevation" },
                    { 26, "--mud-elevation-25", 1, "0 5px 5px -3px rgba(0,0,0,.06), 0 8px 10px 1px rgba(0,0,0,.042), 0 3px 14px 2px rgba(0,0,0,.036)", 25, "Elevation" }
                });

            migrationBuilder.InsertData(
                table: "CustomThemes",
                columns: new[] { "Id", "CreatedWhen", "IsActive", "IsApproved", "Name" },
                values: new object[] { 1, new DateTime(2024, 9, 23, 9, 49, 48, 136, DateTimeKind.Local).AddTicks(9289), true, true, "Default Theme" });

            migrationBuilder.InsertData(
                table: "CustomTypographies",
                columns: new[] { "Id", "CssVariable", "CustomThemeId", "DataType", "Default", "Name", "TypoType" },
                values: new object[,]
                {
                    { 1, "--mud-typography-default-family", 1, "String[]", "Roboto, Helvetica, Arial, sans-serif", "FontFamily", "Default" },
                    { 2, "--mud-typography-default-weight", 1, "Int32", "400", "FontWeight", "Default" },
                    { 3, "--mud-typography-default-size", 1, "String", ".875rem", "FontSize", "Default" },
                    { 4, "--mud-typography-default-lineheight", 1, "Double", "1.43", "LineHeight", "Default" },
                    { 5, "--mud-typography-default-letterspacing", 1, "String", ".01071em", "LetterSpacing", "Default" },
                    { 6, "--mud-typography-default-text-transform", 1, "String", "none", "TextTransform", "Default" },
                    { 7, "--mud-typography-h1-family", 1, "String[]", "", "FontFamily", "H1" },
                    { 8, "--mud-typography-h1-weight", 1, "Int32", "300", "FontWeight", "H1" },
                    { 9, "--mud-typography-h1-size", 1, "String", "6rem", "FontSize", "H1" },
                    { 10, "--mud-typography-h1-lineheight", 1, "Double", "1.167", "LineHeight", "H1" },
                    { 11, "--mud-typography-h1-letterspacing", 1, "String", "-.01562em", "LetterSpacing", "H1" },
                    { 12, "--mud-typography-h1-text-transform", 1, "String", "none", "TextTransform", "H1" },
                    { 13, "--mud-typography-h2-family", 1, "String[]", "", "FontFamily", "H2" },
                    { 14, "--mud-typography-h2-weight", 1, "Int32", "300", "FontWeight", "H2" },
                    { 15, "--mud-typography-h2-size", 1, "String", "3.75rem", "FontSize", "H2" },
                    { 16, "--mud-typography-h2-lineheight", 1, "Double", "1.2", "LineHeight", "H2" },
                    { 17, "--mud-typography-h2-letterspacing", 1, "String", "-.00833em", "LetterSpacing", "H2" },
                    { 18, "--mud-typography-h2-text-transform", 1, "String", "none", "TextTransform", "H2" },
                    { 19, "--mud-typography-h3-family", 1, "String[]", "", "FontFamily", "H3" },
                    { 20, "--mud-typography-h3-weight", 1, "Int32", "400", "FontWeight", "H3" },
                    { 21, "--mud-typography-h3-size", 1, "String", "3rem", "FontSize", "H3" },
                    { 22, "--mud-typography-h3-lineheight", 1, "Double", "1.167", "LineHeight", "H3" },
                    { 23, "--mud-typography-h3-letterspacing", 1, "String", "0", "LetterSpacing", "H3" },
                    { 24, "--mud-typography-h3-text-transform", 1, "String", "none", "TextTransform", "H3" },
                    { 25, "--mud-typography-h4-family", 1, "String[]", "", "FontFamily", "H4" },
                    { 26, "--mud-typography-h4-weight", 1, "Int32", "400", "FontWeight", "H4" },
                    { 27, "--mud-typography-h4-size", 1, "String", "2.125rem", "FontSize", "H4" },
                    { 28, "--mud-typography-h4-lineheight", 1, "Double", "1.235", "LineHeight", "H4" },
                    { 29, "--mud-typography-h4-letterspacing", 1, "String", ".00735em", "LetterSpacing", "H4" },
                    { 30, "--mud-typography-h4-text-transform", 1, "String", "none", "TextTransform", "H4" },
                    { 31, "--mud-typography-h5-family", 1, "String[]", "", "FontFamily", "H5" },
                    { 32, "--mud-typography-h5-weight", 1, "Int32", "400", "FontWeight", "H5" },
                    { 33, "--mud-typography-h5-size", 1, "String", "1.5rem", "FontSize", "H5" },
                    { 34, "--mud-typography-h5-lineheight", 1, "Double", "1.334", "LineHeight", "H5" },
                    { 35, "--mud-typography-h5-letterspacing", 1, "String", "0", "LetterSpacing", "H5" },
                    { 36, "--mud-typography-h5-text-transform", 1, "String", "none", "TextTransform", "H5" },
                    { 37, "--mud-typography-h6-family", 1, "String[]", "", "FontFamily", "H6" },
                    { 38, "--mud-typography-h6-weight", 1, "Int32", "500", "FontWeight", "H6" },
                    { 39, "--mud-typography-h6-size", 1, "String", "1.25rem", "FontSize", "H6" },
                    { 40, "--mud-typography-h6-lineheight", 1, "Double", "1.6", "LineHeight", "H6" },
                    { 41, "--mud-typography-h6-letterspacing", 1, "String", ".0075em", "LetterSpacing", "H6" },
                    { 42, "--mud-typography-h6-text-transform", 1, "String", "none", "TextTransform", "H6" },
                    { 43, "--mud-typography-subtitle1-family", 1, "String[]", "", "FontFamily", "Subtitle1" },
                    { 44, "--mud-typography-subtitle1-weight", 1, "Int32", "400", "FontWeight", "Subtitle1" },
                    { 45, "--mud-typography-subtitle1-size", 1, "String", "1rem", "FontSize", "Subtitle1" },
                    { 46, "--mud-typography-subtitle1-lineheight", 1, "Double", "1.75", "LineHeight", "Subtitle1" },
                    { 47, "--mud-typography-subtitle1-letterspacing", 1, "String", ".00938em", "LetterSpacing", "Subtitle1" },
                    { 48, "--mud-typography-subtitle1-text-transform", 1, "String", "none", "TextTransform", "Subtitle1" },
                    { 49, "--mud-typography-subtitle2-family", 1, "String[]", "", "FontFamily", "Subtitle2" },
                    { 50, "--mud-typography-subtitle2-weight", 1, "Int32", "500", "FontWeight", "Subtitle2" },
                    { 51, "--mud-typography-subtitle2-size", 1, "String", ".875rem", "FontSize", "Subtitle2" },
                    { 52, "--mud-typography-subtitle2-lineheight", 1, "Double", "1.57", "LineHeight", "Subtitle2" },
                    { 53, "--mud-typography-subtitle2-letterspacing", 1, "String", ".00714em", "LetterSpacing", "Subtitle2" },
                    { 54, "--mud-typography-subtitle2-text-transform", 1, "String", "none", "TextTransform", "Subtitle2" },
                    { 55, "--mud-typography-body1-family", 1, "String[]", "", "FontFamily", "Body1" },
                    { 56, "--mud-typography-body1-weight", 1, "Int32", "400", "FontWeight", "Body1" },
                    { 57, "--mud-typography-body1-size", 1, "String", "1rem", "FontSize", "Body1" },
                    { 58, "--mud-typography-body1-lineheight", 1, "Double", "1.5", "LineHeight", "Body1" },
                    { 59, "--mud-typography-body1-letterspacing", 1, "String", ".00938em", "LetterSpacing", "Body1" },
                    { 60, "--mud-typography-body1-text-transform", 1, "String", "none", "TextTransform", "Body1" },
                    { 61, "--mud-typography-body2-family", 1, "String[]", "", "FontFamily", "Body2" },
                    { 62, "--mud-typography-body2-weight", 1, "Int32", "400", "FontWeight", "Body2" },
                    { 63, "--mud-typography-body2-size", 1, "String", ".875rem", "FontSize", "Body2" },
                    { 64, "--mud-typography-body2-lineheight", 1, "Double", "1.43", "LineHeight", "Body2" },
                    { 65, "--mud-typography-body2-letterspacing", 1, "String", ".01071em", "LetterSpacing", "Body2" },
                    { 66, "--mud-typography-body2-text-transform", 1, "String", "none", "TextTransform", "Body2" },
                    { 67, "--mud-typography-input-family", 1, "String[]", "", "FontFamily", "Input" },
                    { 68, "--mud-typography-input-weight", 1, "Int32", "400", "FontWeight", "Input" },
                    { 69, "--mud-typography-input-size", 1, "String", "1rem", "FontSize", "Input" },
                    { 70, "--mud-typography-input-lineheight", 1, "Double", "1.1876", "LineHeight", "Input" },
                    { 71, "--mud-typography-input-letterspacing", 1, "String", ".00938em", "LetterSpacing", "Input" },
                    { 72, "--mud-typography-input-text-transform", 1, "String", "none", "TextTransform", "Input" },
                    { 73, "--mud-typography-button-family", 1, "String[]", "", "FontFamily", "Button" },
                    { 74, "--mud-typography-button-weight", 1, "Int32", "500", "FontWeight", "Button" },
                    { 75, "--mud-typography-button-size", 1, "String", ".875rem", "FontSize", "Button" },
                    { 76, "--mud-typography-button-lineheight", 1, "Double", "1.75", "LineHeight", "Button" },
                    { 77, "--mud-typography-button-letterspacing", 1, "String", ".02857em", "LetterSpacing", "Button" },
                    { 78, "--mud-typography-button-text-transform", 1, "String", "uppercase", "TextTransform", "Button" },
                    { 79, "--mud-typography-caption-family", 1, "String[]", "", "FontFamily", "Caption" },
                    { 80, "--mud-typography-caption-weight", 1, "Int32", "400", "FontWeight", "Caption" },
                    { 81, "--mud-typography-caption-size", 1, "String", ".75rem", "FontSize", "Caption" },
                    { 82, "--mud-typography-caption-lineheight", 1, "Double", "1.66", "LineHeight", "Caption" },
                    { 83, "--mud-typography-caption-letterspacing", 1, "String", ".03333em", "LetterSpacing", "Caption" },
                    { 84, "--mud-typography-caption-text-transform", 1, "String", "none", "TextTransform", "Caption" },
                    { 85, "--mud-typography-overline-family", 1, "String[]", "", "FontFamily", "Overline" },
                    { 86, "--mud-typography-overline-weight", 1, "Int32", "400", "FontWeight", "Overline" },
                    { 87, "--mud-typography-overline-size", 1, "String", ".75rem", "FontSize", "Overline" },
                    { 88, "--mud-typography-overline-lineheight", 1, "Double", "2.66", "LineHeight", "Overline" },
                    { 89, "--mud-typography-overline-letterspacing", 1, "String", ".08333em", "LetterSpacing", "Overline" },
                    { 90, "--mud-typography-overline-text-transform", 1, "String", "none", "TextTransform", "Overline" }
                });

            migrationBuilder.InsertData(
                table: "CustomZIndexes",
                columns: new[] { "Id", "CssVariable", "CustomThemeId", "Default", "Name" },
                values: new object[,]
                {
                    { 1, "--mud-zindex-drawer", 1, "1100", "Drawer" },
                    { 2, "--mud-zindex-popover", 1, "1200", "Popover" },
                    { 3, "--mud-zindex-appbar", 1, "1300", "AppBar" },
                    { 4, "--mud-zindex-dialog", 1, "1400", "Dialog" },
                    { 5, "--mud-zindex-snackbar", 1, "1500", "Snackbar" },
                    { 6, "--mud-zindex-tooltip", 1, "1600", "Tooltip" }
                });

            migrationBuilder.InsertData(
                table: "ThemeOptions",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Shadows" },
                    { 2, true, "LayoutProperties" },
                    { 3, true, "Typography" },
                    { 4, true, "ZIndex" }
                });

            migrationBuilder.InsertData(
                table: "ThemePalettes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PaletteLight" },
                    { 2, "PaletteDark" }
                });

            migrationBuilder.InsertData(
                table: "ThemeSelections",
                columns: new[] { "Id", "CssVariable", "CustomThemeId", "DarkValue", "LightValue", "ThemeName", "ThemeOptionId", "ThemePaletteId", "ThemeType" },
                values: new object[,]
                {
                    { 1, "--mud-palette-black", 1, "rgba(39,39,47,1)", "rgba(89,74,226,1)", "Black", null, 1, "MudColor" },
                    { 2, "--mud-palette-white", 1, null, "rgba(255,255,255,1)", "White", null, 1, "MudColor" },
                    { 3, "--mud-palette-primary", 1, "rgba(119,107,231,1)", "rgba(89,74,226,1)", "Primary", null, 1, "MudColor" },
                    { 4, "--mud-palette-primary-text", 1, null, "rgba(255,255,255,1)", "PrimaryContrastText", null, 1, "MudColor" },
                    { 5, "--mud-palette-secondary", 1, null, "rgba(255,64,129,1)", "Secondary", null, 1, "MudColor" },
                    { 6, "--mud-palette-secondary-text", 1, null, "rgba(255,255,255,1)", "SecondaryContrastText", null, 1, "MudColor" },
                    { 7, "--mud-palette-tertiary", 1, null, "rgba(30,200,165,1)", "Tertiary", null, 1, "MudColor" },
                    { 8, "--mud-palette-tertiary-text", 1, null, "rgba(255,255,255,1)", "TertiaryContrastText", null, 1, "MudColor" },
                    { 9, "--mud-palette-info", 1, "rgba(50,153,255,1)", "rgba(33,150,243,1)", "Info", null, 1, "MudColor" },
                    { 10, "--mud-palette-info-text", 1, null, "rgba(255,255,255,1)", "InfoContrastText", null, 1, "MudColor" },
                    { 11, "--mud-palette-success", 1, "rgba(11,186,131,1)", "rgba(0,200,83,1)", "Success", null, 1, "MudColor" },
                    { 12, "--mud-palette-success-text", 1, null, "rgba(255,255,255,1)", "SuccessContrastText", null, 1, "MudColor" },
                    { 13, "--mud-palette-warning", 1, "rgba(255,168,0,1)", "rgba(255,152,0,1)", "Warning", null, 1, "MudColor" },
                    { 14, "--mud-palette-warning-text", 1, null, "rgba(255,255,255,1)", "WarningContrastText", null, 1, "MudColor" },
                    { 15, "--mud-palette-error", 1, "rgba(246,78,98,1)", "rgba(244,67,54,1)", "Error", null, 1, "MudColor" },
                    { 16, "--mud-palette-error-text", 1, null, "rgba(255,255,255,1)", "ErrorContrastText", null, 1, "MudColor" },
                    { 17, "--mud-palette-dark", 1, "rgba(39,39,47,1)", "rgba(66,66,66,1)", "Dark", null, 1, "MudColor" },
                    { 18, "--mud-palette-dark-text", 1, null, "rgba(255,255,255,1)", "DarkContrastText", null, 1, "MudColor" },
                    { 19, "--mud-palette-text-primary", 1, "rgba(255,255,255,0.6980392156862745)", "rgba(66,66,66,1)", "TextPrimary", null, 1, "MudColor" },
                    { 20, "--mud-palette-text-secondary", 1, "rgba(255,255,255,0.4980392156862745)", "rgba(0,0,0,0.5372549019607843)", "TextSecondary", null, 1, "MudColor" },
                    { 21, "--mud-palette-text-disabled", 1, "rgba(255,255,255,0.2)", "rgba(0,0,0,0.3764705882352941)", "TextDisabled", null, 1, "MudColor" },
                    { 22, "--mud-palette-action-default", 1, "rgba(173,173,177,1)", "rgba(0,0,0,0.5372549019607843)", "ActionDefault", null, 1, "MudColor" },
                    { 23, "--mud-palette-action-disabled", 1, "rgba(255,255,255,0.25882352941176473)", "rgba(0,0,0,0.25882352941176473)", "ActionDisabled", null, 1, "MudColor" },
                    { 24, "--mud-palette-action-disabled-background", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(0,0,0,0.11764705882352941)", "ActionDisabledBackground", null, 1, "MudColor" },
                    { 25, "--mud-palette-background", 1, "rgba(50,51,61,1)", "rgba(255,255,255,1)", "Background", null, 1, "MudColor" },
                    { 26, "--mud-palette-background-gray", 1, "rgba(39,39,47,1)", "rgba(245,245,245,1)", "BackgroundGray", null, 1, "MudColor" },
                    { 27, "--mud-palette-surface", 1, "rgba(55,55,64,1)", "rgba(255,255,255,1)", "Surface", null, 1, "MudColor" },
                    { 28, "--mud-palette-drawer-background", 1, "rgba(39,39,47,1)", "rgba(255,255,255,1)", "DrawerBackground", null, 1, "MudColor" },
                    { 29, "--mud-palette-drawer-text", 1, "rgba(255,255,255,0.4980392156862745)", "rgba(66,66,66,1)", "DrawerText", null, 1, "MudColor" },
                    { 30, "--mud-palette-drawer-icon", 1, "rgba(255,255,255,0.4980392156862745)", "rgba(97,97,97,1)", "DrawerIcon", null, 1, "MudColor" },
                    { 31, "--mud-palette-appbar-background", 1, "rgba(39,39,47,1)", "rgba(89,74,226,1)", "AppbarBackground", null, 1, "MudColor" },
                    { 32, "--mud-palette-appbar-text", 1, "rgba(255,255,255,0.6980392156862745)", "rgba(255,255,255,1)", "AppbarText", null, 1, "MudColor" },
                    { 33, "--mud-palette-lines-default", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(0,0,0,0.11764705882352941)", "LinesDefault", null, 1, "MudColor" },
                    { 34, "--mud-palette-lines-inputs", 1, "rgba(255,255,255,0.2980392156862745)", "rgba(189,189,189,1)", "LinesInputs", null, 1, "MudColor" },
                    { 35, "--mud-palette-table-lines", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(224,224,224,1)", "TableLines", null, 1, "MudColor" },
                    { 36, "--mud-palette-table-striped", 1, "rgba(255,255,255,0.2)", "rgba(0,0,0,0.0196078431372549)", "TableStriped", null, 1, "MudColor" },
                    { 37, "--mud-palette-table-hover", 1, null, "rgba(0,0,0,0.0392156862745098)", "TableHover", null, 1, "MudColor" },
                    { 38, "--mud-palette-divider", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(224,224,224,1)", "Divider", null, 1, "MudColor" },
                    { 39, "--mud-palette-divider-light", 1, "rgba(255,255,255,0.058823529411764705)", "rgba(0,0,0,0.8)", "DividerLight", null, 1, "MudColor" },
                    { 40, "--mud-palette-primary-darken", 1, "rgb(90,75,226)", "rgb(62,44,221)", "PrimaryDarken", null, 1, "MudColor" },
                    { 41, "--mud-palette-primary-lighten", 1, "rgb(151,141,236)", "rgb(118,106,231)", "PrimaryLighten", null, 1, "MudColor" },
                    { 42, "--mud-palette-secondary-darken", 1, null, "rgb(255,31,105)", "SecondaryDarken", null, 1, "MudColor" },
                    { 43, "--mud-palette-secondary-lighten", 1, null, "rgb(255,102,153)", "SecondaryLighten", null, 1, "MudColor" },
                    { 44, "--mud-palette-tertiary-darken", 1, null, "rgb(25,169,140)", "TertiaryDarken", null, 1, "MudColor" },
                    { 45, "--mud-palette-tertiary-lighten", 1, null, "rgb(42,223,187)", "TertiaryLighten", null, 1, "MudColor" },
                    { 46, "--mud-palette-info-darken", 1, "rgb(10,133,255)", "rgb(12,128,223)", "InfoDarken", null, 1, "MudColor" },
                    { 47, "--mud-palette-info-lighten", 1, "rgb(92,173,255)", "rgb(71,167,245)", "InfoLighten", null, 1, "MudColor" },
                    { 48, "--mud-palette-success-darken", 1, "rgb(9,154,108)", "rgb(0,163,68)", "SuccessDarken", null, 1, "MudColor" },
                    { 49, "--mud-palette-success-lighten", 1, "rgb(13,222,156)", "rgb(0,235,98)", "SuccessLighten", null, 1, "MudColor" },
                    { 50, "--mud-palette-warning-darken", 1, "rgb(214,143,0)", "rgb(214,129,0)", "WarningDarken", null, 1, "MudColor" },
                    { 51, "--mud-palette-warning-lighten", 1, "rgb(255,182,36)", "rgb(255,167,36)", "WarningLighten", null, 1, "MudColor" },
                    { 52, "--mud-palette-error-darken", 1, "rgb(244,47,70)", "rgb(242,28,13)", "ErrorDarken", null, 1, "MudColor" },
                    { 53, "--mud-palette-error-lighten", 1, "rgb(248,119,134)", "rgb(246,96,85)", "ErrorLighten", null, 1, "MudColor" },
                    { 54, "--mud-palette-dark-darken", 1, "rgb(23,23,28)", "rgb(46,46,46)", "DarkDarken", null, 1, "MudColor" },
                    { 55, "--mud-palette-dark-lighten", 1, "rgb(56,56,67)", "rgb(87,87,87)", "DarkLighten", null, 1, "MudColor" },
                    { 56, "--mud-palette-hover-opacity", 1, null, "0.06", "HoverOpacity", null, 1, "Double" },
                    { 57, "--mud-palette-ripple-opacity", 1, null, "0.1", "RippleOpacity", null, 1, "Double" },
                    { 58, "--mud-palette-ripple-opacity-secondary", 1, null, "0.2", "RippleOpacitySecondary", null, 1, "Double" },
                    { 59, "--mud-palette-gray-default", 1, null, "#9E9E9E", "GrayDefault", null, 1, "MudColor" },
                    { 60, "--mud-palette-gray-light", 1, null, "#BDBDBD", "GrayLight", null, 1, "MudColor" },
                    { 61, "--mud-palette-gray-lighter", 1, null, "#E0E0E0", "GrayLighter", null, 1, "MudColor" },
                    { 62, "--mud-palette-gray-dark", 1, null, "#757575", "GrayDark", null, 1, "MudColor" },
                    { 63, "--mud-palette-gray-darker", 1, null, "#616161", "GrayDarker", null, 1, "MudColor" },
                    { 64, "--mud-palette-overlay-dark", 1, null, "rgba(33,33,33,0.4980392156862745)", "OverlayDark", null, 1, "MudColor" },
                    { 65, "--mud-palette-overlay-light", 1, null, "rgba(255,255,255,0.4980392156862745)", "OverlayLight", null, 1, "MudColor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomLayoutProperties");

            migrationBuilder.DropTable(
                name: "CustomShadows");

            migrationBuilder.DropTable(
                name: "CustomThemes");

            migrationBuilder.DropTable(
                name: "CustomTypographies");

            migrationBuilder.DropTable(
                name: "CustomZIndexes");

            migrationBuilder.DropTable(
                name: "ThemeOptions");

            migrationBuilder.DropTable(
                name: "ThemePalettes");

            migrationBuilder.DropTable(
                name: "ThemeSelections");
        }
    }
}
