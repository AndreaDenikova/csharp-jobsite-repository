using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobSite.Data.Migrations
{
    public partial class InitialSetUp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserersInfo",
                table: "UserersInfo");

            migrationBuilder.RenameTable(
                name: "UserersInfo",
                newName: "UsersInfo");

            migrationBuilder.RenameIndex(
                name: "IX_UserersInfo_IsDeleted",
                table: "UsersInfo",
                newName: "IX_UsersInfo_IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "CompaniesInfo",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInfo",
                table: "UsersInfo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesInfo_CompanyId",
                table: "CompaniesInfo",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserId",
                table: "UsersInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesInfo_Companies_CompanyId",
                table: "CompaniesInfo",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_AspNetUsers_UserId",
                table: "UsersInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesInfo_Companies_CompanyId",
                table: "CompaniesInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_AspNetUsers_UserId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_CompaniesInfo_CompanyId",
                table: "CompaniesInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInfo",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_UserId",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CompaniesInfo");

            migrationBuilder.RenameTable(
                name: "UsersInfo",
                newName: "UserersInfo");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInfo_IsDeleted",
                table: "UserersInfo",
                newName: "IX_UserersInfo_IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserersInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserersInfo",
                table: "UserersInfo",
                column: "Id");
        }
    }
}
