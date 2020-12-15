using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class DbUpdate13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "JobPostings",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "JobPostings");
        }
    }
}
