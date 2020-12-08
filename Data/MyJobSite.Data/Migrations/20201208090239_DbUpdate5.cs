using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class DbUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UsersInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UsersInfo");
        }
    }
}
