namespace MyJobSite.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DbUpdate8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaxSalary",
                table: "JobPostings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinSalary",
                table: "JobPostings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxSalary",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "MinSalary",
                table: "JobPostings");
        }
    }
}
