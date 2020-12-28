using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class DbUpdate20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportedProfiles");

            migrationBuilder.CreateTable(
                name: "ReportedCandidateProfiles",
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
                    table.PrimaryKey("PK_ReportedCandidateProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedCandidateProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportedCompanyProfiles",
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
                    table.PrimaryKey("PK_ReportedCompanyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedCompanyProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportedCandidateProfiles_IsDeleted",
                table: "ReportedCandidateProfiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedCandidateProfiles_UserId",
                table: "ReportedCandidateProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedCompanyProfiles_IsDeleted",
                table: "ReportedCompanyProfiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedCompanyProfiles_UserId",
                table: "ReportedCompanyProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportedCandidateProfiles");

            migrationBuilder.DropTable(
                name: "ReportedCompanyProfiles");

            migrationBuilder.CreateTable(
                name: "ReportedProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "IX_ReportedProfiles_IsDeleted",
                table: "ReportedProfiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedProfiles_UserId",
                table: "ReportedProfiles",
                column: "UserId");
        }
    }
}
