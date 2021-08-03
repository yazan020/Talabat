using Microsoft.EntityFrameworkCore.Migrations;

namespace TalabatApi.Migrations
{
    public partial class OrdersDropProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrdersId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrdersId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrdersId",
                table: "Products",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrdersId",
                table: "Products",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
