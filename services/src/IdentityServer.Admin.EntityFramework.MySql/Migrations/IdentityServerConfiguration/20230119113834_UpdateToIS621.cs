#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Admin.EntityFramework.MySql.Migrations.IdentityServerConfiguration
{
    public partial class UpdateToIS621 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CoordinateLifetimeWithUserSession",
                table: "Clients",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinateLifetimeWithUserSession",
                table: "Clients");
        }
    }
}








