using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class DbUpdate11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "JobPostings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_CategoryId",
                table: "JobPostings",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_JobPostingCategories_CategoryId",
                table: "JobPostings",
                column: "CategoryId",
                principalTable: "JobPostingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_JobPostingCategories_CategoryId",
                table: "JobPostings");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_CategoryId",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JobPostings");
        }
    }
}
