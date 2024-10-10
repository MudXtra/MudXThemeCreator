using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MappedCSSChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 10, 1, 9, 5, 16, 539, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 35,
                column: "NativeCssVariable",
                value: "--bs-primary");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 36,
                column: "NativeCssVariable",
                value: "--bs-primary-bg-subtle");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 37,
                column: "NativeCssVariable",
                value: "--bs-secondary");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 38,
                column: "NativeCssVariable",
                value: "--bs-secondary-bg-subtle");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 39,
                column: "NativeCssVariable",
                value: "--bs-secondary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 10, 1, 8, 30, 4, 194, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 35,
                column: "NativeCssVariable",
                value: "--bs-nav-pills-link-active-color");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 36,
                column: "NativeCssVariable",
                value: "--bs-nav-pills-link-active-bg");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 37,
                column: "NativeCssVariable",
                value: "--bs-emphasis-color");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 38,
                column: "NativeCssVariable",
                value: "--bs-body-bg");

            migrationBuilder.UpdateData(
                table: "MappedCssVariables",
                keyColumn: "Id",
                keyValue: 39,
                column: "NativeCssVariable",
                value: "--bs-emphasis-color");
        }
    }
}
