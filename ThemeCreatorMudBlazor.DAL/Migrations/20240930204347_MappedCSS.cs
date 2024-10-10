using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MappedCSS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 9, 30, 15, 43, 46, 829, DateTimeKind.Local).AddTicks(3086));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 9, 26, 12, 9, 59, 199, DateTimeKind.Local).AddTicks(9540));
        }
    }
}
