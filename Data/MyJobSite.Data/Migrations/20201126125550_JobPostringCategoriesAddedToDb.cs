using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class JobPostringCategoriesAddedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobPostingCategoryId",
                table: "JobPostings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobPostingCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_JobPostingCategoryId",
                table: "JobPostings",
                column: "JobPostingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingCategories_IsDeleted",
                table: "JobPostingCategories",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_JobPostingCategories_JobPostingCategoryId",
                table: "JobPostings",
                column: "JobPostingCategoryId",
                principalTable: "JobPostingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_JobPostingCategories_JobPostingCategoryId",
                table: "JobPostings");

            migrationBuilder.DropTable(
                name: "JobPostingCategories");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_JobPostingCategoryId",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "JobPostingCategoryId",
                table: "JobPostings");
        }
    }
}
