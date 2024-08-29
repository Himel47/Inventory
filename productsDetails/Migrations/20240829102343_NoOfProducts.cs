using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace productsDetails.Migrations
{
    /// <inheritdoc />
    public partial class NoOfProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "supplierId",
                table: "Stocks",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "stockTotalCost",
                table: "Stocks",
                newName: "StockTotalCost");

            migrationBuilder.RenameColumn(
                name: "stockStatus",
                table: "Stocks",
                newName: "StockStatus");

            migrationBuilder.RenameColumn(
                name: "stockReceiveDate",
                table: "Stocks",
                newName: "StockReceiveDate");

            migrationBuilder.AddColumn<int>(
                name: "ProductNumber",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductNumber",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Stocks",
                newName: "supplierId");

            migrationBuilder.RenameColumn(
                name: "StockTotalCost",
                table: "Stocks",
                newName: "stockTotalCost");

            migrationBuilder.RenameColumn(
                name: "StockStatus",
                table: "Stocks",
                newName: "stockStatus");

            migrationBuilder.RenameColumn(
                name: "StockReceiveDate",
                table: "Stocks",
                newName: "stockReceiveDate");
        }
    }
}
