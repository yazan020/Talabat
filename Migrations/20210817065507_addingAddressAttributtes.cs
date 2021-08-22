using Microsoft.EntityFrameworkCore.Migrations;

namespace TalabatApi.Migrations
{
    public partial class addingAddressAttributtes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UsersData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "UsersData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "UsersData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "UsersData");
        }
    }
}
