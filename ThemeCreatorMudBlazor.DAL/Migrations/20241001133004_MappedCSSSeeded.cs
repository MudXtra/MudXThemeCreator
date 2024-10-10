using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MappedCSSSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MappedCssVariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MappedThemeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NativeCssVariable = table.Column<string>(type: "TEXT", nullable: false),
                    MappedCssVariable = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappedCssVariables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MappedThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappedThemes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 10, 1, 8, 30, 4, 194, DateTimeKind.Local).AddTicks(9786));

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
                    { 35, "--mud-palette-appbar-text", 1, "--bs-nav-pills-link-active-color" },
                    { 36, "--mud-palette-appbar-background", 1, "--bs-nav-pills-link-active-bg" },
                    { 37, "--mud-palette-drawer-text", 1, "--bs-emphasis-color" },
                    { 38, "--mud-palette-drawer-background", 1, "--bs-body-bg" },
                    { 39, "--mud-palette-drawer-icon", 1, "--bs-emphasis-color" },
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MappedCssVariables");

            migrationBuilder.DropTable(
                name: "MappedThemes");

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 9, 30, 15, 43, 46, 829, DateTimeKind.Local).AddTicks(3086));
        }
    }
}
