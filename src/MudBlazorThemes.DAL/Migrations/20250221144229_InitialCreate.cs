using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MudBlazorThemes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomLayoutProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomThemeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Default = table.Column<int>(type: "integer", nullable: false),
                    Min = table.Column<int>(type: "integer", nullable: false),
                    Max = table.Column<int>(type: "integer", nullable: false),
                    CssVariable = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomLayoutProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomShadows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    CustomThemeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Default = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: false),
                    CssVariable = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomShadows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedWhen = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    OtherText = table.Column<string>(type: "character varying(199)", maxLength: 199, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomThemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomTypographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomThemeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TypoType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Default = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CssVariable = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTypographies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomZIndexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomThemeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Default = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CssVariable = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomZIndexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MappedCssVariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MappedThemeId = table.Column<int>(type: "integer", nullable: false),
                    NativeCssVariable = table.Column<string>(type: "text", nullable: false),
                    MappedCssVariable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappedCssVariables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MappedThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappedThemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemePalettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemePalettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThemeSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomThemeId = table.Column<int>(type: "integer", nullable: false),
                    OrderPriority = table.Column<int>(type: "integer", nullable: false),
                    ThemeOptionId = table.Column<int>(type: "integer", nullable: true),
                    ThemeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ThemeType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LightValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DarkValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CssVariable = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeSelections", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CustomLayoutProperties",
                columns: new[] { "Id", "CssVariable", "CustomThemeId", "Default", "Max", "Min", "Name" },
                values: new object[,]
                {
                    { 1, "--mud-default-borderradius", 1, 4, 10, 0, "DefaultBorderRadius" },
                    { 2, "--mud-drawer-mini-width-left", 1, 56, 100, 0, "DrawerMiniWidthLeft" },
                    { 3, "--mud-drawer-mini-width-right", 1, 56, 100, 0, "DrawerMiniWidthRight" },
                    { 4, "--mud-drawer-width-left", 1, 240, 500, 0, "DrawerWidthLeft" },
                    { 5, "--mud-drawer-width-right", 1, 240, 500, 0, "DrawerWidthRight" },
                    { 6, "--mud-appbar-height", 1, 64, 200, 0, "AppbarHeight" }
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
                columns: new[] { "Id", "CreatedWhen", "IsActive", "IsApproved", "Name", "OtherText" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc), true, true, "Default Theme", "The Default Theme for MudBlazor" });

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
                table: "MappedCssVariables",
                columns: new[] { "Id", "MappedCssVariable", "MappedThemeId", "NativeCssVariable" },
                values: new object[,]
                {
                    { 1, "--mud-palette-black", 1, "--bs-black" },
                    { 2, "--mud-palette-white", 1, "--bs-white" },
                    { 3, "--mud-palette-primary", 1, "--bs-primary" },
                    { 4, "--mud-palette-primary-text", 1, "--bs-primary-bg-subtle" },
                    { 5, "--mud-palette-secondary", 1, "--bs-secondary" },
                    { 6, "--mud-palette-secondary-text", 1, "--bs-secondary-bg-subtle" },
                    { 7, "--mud-palette-tertiary", 1, "--bs-tertiary-color" },
                    { 8, "--mud-palette-tertiary-text", 1, "--bs-tertiary-bg" },
                    { 9, "--mud-palette-info", 1, "--bs-info" },
                    { 10, "--mud-palette-info-text", 1, "--bs-info-bg-subtle" },
                    { 11, "--mud-palette-success", 1, "--bs-success" },
                    { 12, "--mud-palette-success-text", 1, "--bs-success-bg-subtle" },
                    { 13, "--mud-palette-warning", 1, "--bs-warning" },
                    { 14, "--mud-palette-warning-text", 1, "--bs-warning-bg-subtle" },
                    { 15, "--mud-palette-error", 1, "--bs-error" },
                    { 16, "--mud-palette-error-text", 1, "--bs-error-bg-subtle" },
                    { 17, "--mud-palette-dark", 1, "--bs-dark" },
                    { 18, "--mud-palette-dark-text", 1, "--bs-dark-bg-subtle" },
                    { 19, "--mud-palette-text-primary", 1, "--bs-primary-text-emphasis" },
                    { 20, "--mud-palette-text-secondary", 1, "--bs-secondary-text-emphasis" },
                    { 21, "--mud-palette-primary-darken", 1, "--bs-primary-text-emphasis" },
                    { 22, "--mud-palette-primary-lighten", 1, "--bs-primary-bg-subtle" },
                    { 23, "--mud-palette-secondary-darken", 1, "--bs-secondary-text-emphasis" },
                    { 24, "--mud-palette-secondary-lighten", 1, "--bs-secondary-bg-subtle" },
                    { 25, "--mud-palette-tertiary-darken", 1, "--bs-tertiary-color" },
                    { 26, "--mud-palette-tertiary-lighten", 1, "--bs-tertiary-color" },
                    { 27, "--mud-palette-info-darken", 1, "--bs-info-text-emphasis" },
                    { 28, "--mud-palette-info-lighten", 1, "--bs-info-bg-subtle" },
                    { 29, "--mud-palette-success-darken", 1, "--bs-success-text-emphasis" },
                    { 30, "--mud-palette-success-lighten", 1, "--bs-success-bg-subtle" },
                    { 31, "--mud-palette-warning-darken", 1, "--bs-warning-text-emphasis" },
                    { 32, "--mud-palette-warning-lighten", 1, "--bs-warning-bg-subtle" },
                    { 33, "--mud-palette-error-darken", 1, "--bs-error-text-emphasis" },
                    { 34, "--mud-palette-error-lighten", 1, "--bs-error-bg-subtle" },
                    { 35, "--mud-palette-appbar-text", 1, "--bs-primary" },
                    { 36, "--mud-palette-appbar-background", 1, "--bs-primary-bg-subtle" },
                    { 37, "--mud-palette-drawer-text", 1, "--bs-secondary" },
                    { 38, "--mud-palette-drawer-background", 1, "--bs-secondary-bg-subtle" },
                    { 39, "--mud-palette-drawer-icon", 1, "--bs-secondary" },
                    { 40, "--mud-typography-body1-size", 1, "--bs-body-font-size" },
                    { 41, "--mud-typography-body1-weight", 1, "--bs-body-font-weight" },
                    { 42, "--mud-typography-body1-lineheight", 1, "--bs-body-line-height" },
                    { 43, "--mud-typography-button-weight", 1, "--bs-btn-font-weight" },
                    { 44, "--mud-typography-button-size", 1, "--bs-btn-font-size" },
                    { 45, "--mud-typography-button-lineheight", 1, "--bs-btn-line-height" }
                });

            migrationBuilder.InsertData(
                table: "MappedThemes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bootstrap to MudBlazor" });

            migrationBuilder.InsertData(
                table: "ThemeOptions",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Shadows" },
                    { 2, true, "Layout Properties" },
                    { 3, true, "Typography" },
                    { 4, true, "ZIndex" }
                });

            migrationBuilder.InsertData(
                table: "ThemePalettes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Palette Light" },
                    { 2, "Palette Dark" }
                });

            migrationBuilder.InsertData(
                table: "ThemeSelections",
                columns: new[] { "Id", "CssVariable", "CustomThemeId", "DarkValue", "LightValue", "OrderPriority", "ThemeName", "ThemeOptionId", "ThemeType" },
                values: new object[,]
                {
                    { 1, "--mud-palette-black", 1, "rgba(39,39,47,1)", "rgba(89,74,226,1)", 99, "Black", null, "MudColor" },
                    { 2, "--mud-palette-white", 1, null, "rgba(255,255,255,1)", 99, "White", null, "MudColor" },
                    { 3, "--mud-palette-primary", 1, "rgba(119,107,231,1)", "rgba(89,74,226,1)", 1, "Primary", null, "MudColor" },
                    { 4, "--mud-palette-primary-text", 1, null, "rgba(255,255,255,1)", 1, "PrimaryContrastText", null, "MudColor" },
                    { 5, "--mud-palette-secondary", 1, null, "rgba(255,64,129,1)", 2, "Secondary", null, "MudColor" },
                    { 6, "--mud-palette-secondary-text", 1, null, "rgba(255,255,255,1)", 2, "SecondaryContrastText", null, "MudColor" },
                    { 7, "--mud-palette-tertiary", 1, null, "rgba(30,200,165,1)", 3, "Tertiary", null, "MudColor" },
                    { 8, "--mud-palette-tertiary-text", 1, null, "rgba(255,255,255,1)", 3, "TertiaryContrastText", null, "MudColor" },
                    { 9, "--mud-palette-info", 1, "rgba(50,153,255,1)", "rgba(33,150,243,1)", 4, "Info", null, "MudColor" },
                    { 10, "--mud-palette-info-text", 1, null, "rgba(255,255,255,1)", 4, "InfoContrastText", null, "MudColor" },
                    { 11, "--mud-palette-success", 1, "rgba(11,186,131,1)", "rgba(0,200,83,1)", 5, "Success", null, "MudColor" },
                    { 12, "--mud-palette-success-text", 1, null, "rgba(255,255,255,1)", 5, "SuccessContrastText", null, "MudColor" },
                    { 13, "--mud-palette-warning", 1, "rgba(255,168,0,1)", "rgba(255,152,0,1)", 6, "Warning", null, "MudColor" },
                    { 14, "--mud-palette-warning-text", 1, null, "rgba(255,255,255,1)", 6, "WarningContrastText", null, "MudColor" },
                    { 15, "--mud-palette-error", 1, "rgba(246,78,98,1)", "rgba(244,67,54,1)", 7, "Error", null, "MudColor" },
                    { 16, "--mud-palette-error-text", 1, null, "rgba(255,255,255,1)", 7, "ErrorContrastText", null, "MudColor" },
                    { 17, "--mud-palette-dark", 1, "rgba(39,39,47,1)", "rgba(66,66,66,1)", 8, "Dark", null, "MudColor" },
                    { 18, "--mud-palette-dark-text", 1, null, "rgba(255,255,255,1)", 8, "DarkContrastText", null, "MudColor" },
                    { 19, "--mud-palette-text-primary", 1, "rgba(255,255,255,0.6980392156862745)", "rgba(66,66,66,1)", 1, "TextPrimary", null, "MudColor" },
                    { 20, "--mud-palette-text-secondary", 1, "rgba(255,255,255,0.4980392156862745)", "rgba(0,0,0,0.5372549019607843)", 2, "TextSecondary", null, "MudColor" },
                    { 21, "--mud-palette-text-disabled", 1, "rgba(255,255,255,0.2)", "rgba(0,0,0,0.3764705882352941)", 9, "TextDisabled", null, "MudColor" },
                    { 22, "--mud-palette-action-default", 1, "rgba(173,173,177,1)", "rgba(0,0,0,0.5372549019607843)", 99, "ActionDefault", null, "MudColor" },
                    { 23, "--mud-palette-action-disabled", 1, "rgba(255,255,255,0.25882352941176473)", "rgba(0,0,0,0.25882352941176473)", 99, "ActionDisabled", null, "MudColor" },
                    { 24, "--mud-palette-action-disabled-background", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(0,0,0,0.11764705882352941)", 99, "ActionDisabledBackground", null, "MudColor" },
                    { 25, "--mud-palette-background", 1, "rgba(50,51,61,1)", "rgba(255,255,255,1)", 11, "Background", null, "MudColor" },
                    { 26, "--mud-palette-background-gray", 1, "rgba(39,39,47,1)", "rgba(245,245,245,1)", 11, "BackgroundGray", null, "MudColor" },
                    { 27, "--mud-palette-surface", 1, "rgba(55,55,64,1)", "rgba(255,255,255,1)", 10, "Surface", null, "MudColor" },
                    { 28, "--mud-palette-drawer-background", 1, "rgba(39,39,47,1)", "rgba(255,255,255,1)", 12, "DrawerBackground", null, "MudColor" },
                    { 29, "--mud-palette-drawer-text", 1, "rgba(255,255,255,0.4980392156862745)", "rgba(66,66,66,1)", 12, "DrawerText", null, "MudColor" },
                    { 30, "--mud-palette-drawer-icon", 1, "rgba(255,255,255,0.4980392156862745)", "rgba(97,97,97,1)", 12, "DrawerIcon", null, "MudColor" },
                    { 31, "--mud-palette-appbar-background", 1, "rgba(39,39,47,1)", "rgba(89,74,226,1)", 13, "AppbarBackground", null, "MudColor" },
                    { 32, "--mud-palette-appbar-text", 1, "rgba(255,255,255,0.6980392156862745)", "rgba(255,255,255,1)", 13, "AppbarText", null, "MudColor" },
                    { 33, "--mud-palette-lines-default", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(0,0,0,0.11764705882352941)", 99, "LinesDefault", null, "MudColor" },
                    { 34, "--mud-palette-lines-inputs", 1, "rgba(255,255,255,0.2980392156862745)", "rgba(189,189,189,1)", 99, "LinesInputs", null, "MudColor" },
                    { 35, "--mud-palette-table-lines", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(224,224,224,1)", 99, "TableLines", null, "MudColor" },
                    { 36, "--mud-palette-table-striped", 1, "rgba(255,255,255,0.2)", "rgba(0,0,0,0.0196078431372549)", 99, "TableStriped", null, "MudColor" },
                    { 37, "--mud-palette-table-hover", 1, null, "rgba(0,0,0,0.0392156862745098)", 99, "TableHover", null, "MudColor" },
                    { 38, "--mud-palette-divider", 1, "rgba(255,255,255,0.11764705882352941)", "rgba(224,224,224,1)", 99, "Divider", null, "MudColor" },
                    { 39, "--mud-palette-divider-light", 1, "rgba(255,255,255,0.058823529411764705)", "rgba(0,0,0,0.8)", 99, "DividerLight", null, "MudColor" },
                    { 40, "--mud-palette-primary-darken", 1, "rgb(90,75,226)", "rgb(62,44,221)", 1, "PrimaryDarken", null, "MudColor" },
                    { 41, "--mud-palette-primary-lighten", 1, "rgb(151,141,236)", "rgb(118,106,231)", 1, "PrimaryLighten", null, "MudColor" },
                    { 42, "--mud-palette-secondary-darken", 1, null, "rgb(255,31,105)", 2, "SecondaryDarken", null, "MudColor" },
                    { 43, "--mud-palette-secondary-lighten", 1, null, "rgb(255,102,153)", 2, "SecondaryLighten", null, "MudColor" },
                    { 44, "--mud-palette-tertiary-darken", 1, null, "rgb(25,169,140)", 3, "TertiaryDarken", null, "MudColor" },
                    { 45, "--mud-palette-tertiary-lighten", 1, null, "rgb(42,223,187)", 3, "TertiaryLighten", null, "MudColor" },
                    { 46, "--mud-palette-info-darken", 1, "rgb(10,133,255)", "rgb(12,128,223)", 4, "InfoDarken", null, "MudColor" },
                    { 47, "--mud-palette-info-lighten", 1, "rgb(92,173,255)", "rgb(71,167,245)", 4, "InfoLighten", null, "MudColor" },
                    { 48, "--mud-palette-success-darken", 1, "rgb(9,154,108)", "rgb(0,163,68)", 5, "SuccessDarken", null, "MudColor" },
                    { 49, "--mud-palette-success-lighten", 1, "rgb(13,222,156)", "rgb(0,235,98)", 5, "SuccessLighten", null, "MudColor" },
                    { 50, "--mud-palette-warning-darken", 1, "rgb(214,143,0)", "rgb(214,129,0)", 6, "WarningDarken", null, "MudColor" },
                    { 51, "--mud-palette-warning-lighten", 1, "rgb(255,182,36)", "rgb(255,167,36)", 6, "WarningLighten", null, "MudColor" },
                    { 52, "--mud-palette-error-darken", 1, "rgb(244,47,70)", "rgb(242,28,13)", 7, "ErrorDarken", null, "MudColor" },
                    { 53, "--mud-palette-error-lighten", 1, "rgb(248,119,134)", "rgb(246,96,85)", 7, "ErrorLighten", null, "MudColor" },
                    { 54, "--mud-palette-dark-darken", 1, "rgb(23,23,28)", "rgb(46,46,46)", 8, "DarkDarken", null, "MudColor" },
                    { 55, "--mud-palette-dark-lighten", 1, "rgb(56,56,67)", "rgb(87,87,87)", 8, "DarkLighten", null, "MudColor" },
                    { 56, "--mud-palette-hover-opacity", 1, null, "0.06", 99, "HoverOpacity", null, "Double" },
                    { 57, "--mud-palette-ripple-opacity", 1, null, "0.1", 99, "RippleOpacity", null, "Double" },
                    { 58, "--mud-palette-ripple-opacity-secondary", 1, null, "0.2", 99, "RippleOpacitySecondary", null, "Double" },
                    { 59, "--mud-palette-gray-default", 1, null, "#9E9E9E", 99, "GrayDefault", null, "MudColor" },
                    { 60, "--mud-palette-gray-light", 1, null, "#BDBDBD", 99, "GrayLight", null, "MudColor" },
                    { 61, "--mud-palette-gray-lighter", 1, null, "#E0E0E0", 99, "GrayLighter", null, "MudColor" },
                    { 62, "--mud-palette-gray-dark", 1, null, "#757575", 99, "GrayDark", null, "MudColor" },
                    { 63, "--mud-palette-gray-darker", 1, null, "#616161", 99, "GrayDarker", null, "MudColor" },
                    { 64, "--mud-palette-overlay-dark", 1, null, "rgba(33,33,33,0.4980392156862745)", 99, "OverlayDark", null, "MudColor" },
                    { 65, "--mud-palette-overlay-light", 1, null, "rgba(255,255,255,0.4980392156862745)", 99, "OverlayLight", null, "MudColor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomLayoutProperties_CssVariable",
                table: "CustomLayoutProperties",
                column: "CssVariable");

            migrationBuilder.CreateIndex(
                name: "IX_CustomLayoutProperties_CustomThemeId",
                table: "CustomLayoutProperties",
                column: "CustomThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomShadows_CssVariable",
                table: "CustomShadows",
                column: "CssVariable");

            migrationBuilder.CreateIndex(
                name: "IX_CustomShadows_CustomThemeId",
                table: "CustomShadows",
                column: "CustomThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomTypographies_CssVariable",
                table: "CustomTypographies",
                column: "CssVariable");

            migrationBuilder.CreateIndex(
                name: "IX_CustomTypographies_CustomThemeId",
                table: "CustomTypographies",
                column: "CustomThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomZIndexes_CssVariable",
                table: "CustomZIndexes",
                column: "CssVariable");

            migrationBuilder.CreateIndex(
                name: "IX_CustomZIndexes_CustomThemeId",
                table: "CustomZIndexes",
                column: "CustomThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeSelections_CssVariable",
                table: "ThemeSelections",
                column: "CssVariable");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeSelections_CustomThemeId",
                table: "ThemeSelections",
                column: "CustomThemeId");
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
                name: "MappedCssVariables");

            migrationBuilder.DropTable(
                name: "MappedThemes");

            migrationBuilder.DropTable(
                name: "ThemeOptions");

            migrationBuilder.DropTable(
                name: "ThemePalettes");

            migrationBuilder.DropTable(
                name: "ThemeSelections");
        }
    }
}
