using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorThemes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserMaxes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMaxes",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "text", nullable: false),
                    MaxThemes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaxes", x => x.UserName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMaxes");
        }
    }
}
