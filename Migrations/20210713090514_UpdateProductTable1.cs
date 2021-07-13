using Microsoft.EntityFrameworkCore.Migrations;

namespace TalabatApi.Migrations
{
    public partial class UpdateProductTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestuarantName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestuarantName",
                table: "Products");
        }
    }
}
