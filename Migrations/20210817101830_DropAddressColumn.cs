using Microsoft.EntityFrameworkCore.Migrations;

namespace TalabatApi.Migrations
{
    public partial class DropAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "UsersData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "UsersData",
                type: "text",
                nullable: true);
        }
    }
}
