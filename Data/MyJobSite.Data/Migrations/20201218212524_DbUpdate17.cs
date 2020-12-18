namespace MyJobSite.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DbUpdate17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Candidates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Candidates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Candidates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_IsDeleted",
                table: "Candidates",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Candidates_IsDeleted",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Candidates");
        }
    }
}
