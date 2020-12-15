namespace MyJobSite.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DbUpdate15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "UsersInfo");

            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "UsersInfo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_CityId",
                table: "UsersInfo",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_Cities_CityId",
                table: "UsersInfo",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_Cities_CityId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_CityId",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UsersInfo");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
