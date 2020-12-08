using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class DbUpdate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UsersInfo",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "UsersInfo");
        }
    }
}
