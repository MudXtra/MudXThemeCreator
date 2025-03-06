using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorThemes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "MudBlazor Default Theme");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Default Theme");
        }
    }
}
