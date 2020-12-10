namespace MyJobSite.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DbUpdate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Responsibilities",
                table: "JobPostings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "JobPostings",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsibilities",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "JobPostings");
        }
    }
}
