using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThemeCreatorMudBlazor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBorderRadius : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE CustomLayoutProperties " +
                "SET CssVariable = '--mud-default-borderradius' " +
                "WHERE Name = 'DefaultBorderRadius'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE CustomLayoutProperties " +
                "SET CssVariable = '--mud-default-border-radius' " +
                "WHERE Name = 'DefaultBorderRadius'");

        }
    }
}
