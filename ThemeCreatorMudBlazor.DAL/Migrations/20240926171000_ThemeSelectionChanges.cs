using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ThemeSelectionChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThemePaletteId",
                table: "ThemeSelections");

            migrationBuilder.AddColumn<int>(
                name: "OrderPriority",
                table: "ThemeSelections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 9, 26, 12, 9, 59, 199, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderPriority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderPriority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderPriority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderPriority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderPriority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 8,
                column: "OrderPriority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 9,
                column: "OrderPriority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderPriority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderPriority",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderPriority",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderPriority",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 14,
                column: "OrderPriority",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 15,
                column: "OrderPriority",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 16,
                column: "OrderPriority",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 17,
                column: "OrderPriority",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 18,
                column: "OrderPriority",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 19,
                column: "OrderPriority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 20,
                column: "OrderPriority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 21,
                column: "OrderPriority",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 22,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 23,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 24,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 25,
                column: "OrderPriority",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 26,
                column: "OrderPriority",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 27,
                column: "OrderPriority",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 28,
                column: "OrderPriority",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 29,
                column: "OrderPriority",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 30,
                column: "OrderPriority",
                value: 12);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderPriority",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderPriority",
                value: 13);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 35,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 36,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 37,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 38,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 39,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 40,
                column: "OrderPriority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 41,
                column: "OrderPriority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 42,
                column: "OrderPriority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 43,
                column: "OrderPriority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 44,
                column: "OrderPriority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 45,
                column: "OrderPriority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 46,
                column: "OrderPriority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 47,
                column: "OrderPriority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 48,
                column: "OrderPriority",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 49,
                column: "OrderPriority",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 50,
                column: "OrderPriority",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 51,
                column: "OrderPriority",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 52,
                column: "OrderPriority",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 53,
                column: "OrderPriority",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 54,
                column: "OrderPriority",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 55,
                column: "OrderPriority",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 56,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 57,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 58,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 59,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 60,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 61,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 62,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 63,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 64,
                column: "OrderPriority",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 65,
                column: "OrderPriority",
                value: 99);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPriority",
                table: "ThemeSelections");

            migrationBuilder.AddColumn<int>(
                name: "ThemePaletteId",
                table: "ThemeSelections",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 9, 25, 22, 50, 5, 210, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 8,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 9,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 10,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 11,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 12,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 13,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 14,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 15,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 16,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 17,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 18,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 19,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 20,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 21,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 22,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 23,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 24,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 25,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 26,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 27,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 28,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 29,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 30,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 31,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 32,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 33,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 34,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 35,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 36,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 37,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 38,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 39,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 40,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 41,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 42,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 43,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 44,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 45,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 46,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 47,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 48,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 49,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 50,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 51,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 52,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 53,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 54,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 55,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 56,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 57,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 58,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 59,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 60,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 61,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 62,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 63,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 64,
                column: "ThemePaletteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ThemeSelections",
                keyColumn: "Id",
                keyValue: 65,
                column: "ThemePaletteId",
                value: 1);
        }
    }
}
