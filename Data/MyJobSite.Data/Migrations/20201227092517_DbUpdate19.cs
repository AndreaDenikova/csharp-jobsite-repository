namespace MyJobSite.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DbUpdate19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportedJobPostings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    JobPostingId = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedJobPostings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedJobPostings_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportedProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportedJobPostings_IsDeleted",
                table: "ReportedJobPostings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedJobPostings_JobPostingId",
                table: "ReportedJobPostings",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedProfiles_IsDeleted",
                table: "ReportedProfiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedProfiles_UserId",
                table: "ReportedProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportedJobPostings");

            migrationBuilder.DropTable(
                name: "ReportedProfiles");
        }
    }
}
