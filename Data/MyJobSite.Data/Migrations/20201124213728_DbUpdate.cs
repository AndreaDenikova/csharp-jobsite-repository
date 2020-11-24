using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesInfo_Companies_CompanyId",
                table: "CompaniesInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Companies_CompanyId",
                table: "JobPostings");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_CompanyId",
                table: "JobPostings");

            migrationBuilder.DropIndex(
                name: "IX_CompaniesInfo_CompanyId",
                table: "CompaniesInfo");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CompaniesInfo");

            migrationBuilder.AddColumn<string>(
                name: "CompanyInfoId",
                table: "JobPostings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "CompaniesInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CompaniesInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "CompaniesInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CompaniesInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CompaniesInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_CompanyInfoId",
                table: "JobPostings",
                column: "CompanyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesInfo_UserId",
                table: "CompaniesInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesInfo_AspNetUsers_UserId",
                table: "CompaniesInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_CompaniesInfo_CompanyInfoId",
                table: "JobPostings",
                column: "CompanyInfoId",
                principalTable: "CompaniesInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesInfo_AspNetUsers_UserId",
                table: "CompaniesInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_CompaniesInfo_CompanyInfoId",
                table: "JobPostings");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_CompanyInfoId",
                table: "JobPostings");

            migrationBuilder.DropIndex(
                name: "IX_CompaniesInfo_UserId",
                table: "CompaniesInfo");

            migrationBuilder.DropColumn(
                name: "CompanyInfoId",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CompaniesInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CompaniesInfo");

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "JobPostings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "CompaniesInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CompaniesInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "CompaniesInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "CompaniesInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_CompanyId",
                table: "JobPostings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesInfo_CompanyId",
                table: "CompaniesInfo",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IsDeleted",
                table: "Companies",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesInfo_Companies_CompanyId",
                table: "CompaniesInfo",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Companies_CompanyId",
                table: "JobPostings",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
