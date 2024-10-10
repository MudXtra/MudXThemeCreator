using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CustomThemeOtherText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherText",
                table: "CustomThemes",
                type: "TEXT",
                maxLength: 199,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedWhen", "OtherText" },
                values: new object[] { new DateTime(2024, 10, 4, 22, 54, 22, 736, DateTimeKind.Local).AddTicks(8164), "The Default Theme for MudBlazor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherText",
                table: "CustomThemes");

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedWhen",
                value: new DateTime(2024, 10, 1, 9, 5, 16, 539, DateTimeKind.Local).AddTicks(5616));
        }
    }
}
