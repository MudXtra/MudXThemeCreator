using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorThemes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UploadedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "CustomThemes",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomThemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedBy",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "CustomThemes");
        }
    }
}
