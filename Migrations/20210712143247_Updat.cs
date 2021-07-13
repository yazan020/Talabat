using Microsoft.EntityFrameworkCore.Migrations;

namespace TalabatApi.Migrations
{
    public partial class Updat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UsersData_UserDataid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserDataid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserDataid",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDataid",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserDataid",
                table: "Products",
                column: "UserDataid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UsersData_UserDataid",
                table: "Products",
                column: "UserDataid",
                principalTable: "UsersData",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
