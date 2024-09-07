using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Repository.Migrations
{
    /// <inheritdoc />
    public partial class StockProductUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productStockPrice",
                table: "StockProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productStockQuantity",
                table: "StockProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productStockPrice",
                table: "StockProducts");

            migrationBuilder.DropColumn(
                name: "productStockQuantity",
                table: "StockProducts");
        }
    }
}
