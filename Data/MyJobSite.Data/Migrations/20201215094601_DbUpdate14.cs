using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class DbUpdate14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "JobPostings");

            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "JobPostings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cities",
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
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_CityId",
                table: "JobPostings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IsDeleted",
                table: "Cities",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Cities_CityId",
                table: "JobPostings",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Cities_CityId",
                table: "JobPostings");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_CityId",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "JobPostings");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "JobPostings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
