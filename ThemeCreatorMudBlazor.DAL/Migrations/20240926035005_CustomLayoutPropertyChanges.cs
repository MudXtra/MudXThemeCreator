using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CustomLayoutPropertyChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Default",
                table: "CustomLayoutProperties",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "CustomLayoutProperties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Min",
                table: "CustomLayoutProperties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Default", "Max", "Min" },
                values: new object[] { 4, 10, 0 });

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Default", "Max", "Min" },
                values: new object[] { 56, 100, 0 });

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Default", "Max", "Min" },
                values: new object[] { 56, 100, 0 });

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Default", "Max", "Min" },
                values: new object[] { 240, 500, 0 });

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Default", "Max", "Min" },
                values: new object[] { 240, 500, 0 });

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Default", "Max", "Min" },
                values: new object[] { 64, 200, 0 });

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 9, 25, 22, 50, 5, 210, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "ThemeOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Layout Properties");

            migrationBuilder.UpdateData(
                table: "ThemePalettes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Palette Light");

            migrationBuilder.UpdateData(
                table: "ThemePalettes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Palette Dark");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Max",
                table: "CustomLayoutProperties");

            migrationBuilder.DropColumn(
                name: "Min",
                table: "CustomLayoutProperties");

            migrationBuilder.AlterColumn<string>(
                name: "Default",
                table: "CustomLayoutProperties",
                type: "TEXT",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Default",
                value: "4px");

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Default",
                value: "56px");

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Default",
                value: "56px");

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Default",
                value: "2404px");

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 5,
                column: "Default",
                value: "240px");

            migrationBuilder.UpdateData(
                table: "CustomLayoutProperties",
                keyColumn: "Id",
                keyValue: 6,
                column: "Default",
                value: "64px");

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 9, 23, 9, 49, 48, 136, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "ThemeOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "LayoutProperties");

            migrationBuilder.UpdateData(
                table: "ThemePalettes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "PaletteLight");

            migrationBuilder.UpdateData(
                table: "ThemePalettes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "PaletteDark");
        }
    }
}
