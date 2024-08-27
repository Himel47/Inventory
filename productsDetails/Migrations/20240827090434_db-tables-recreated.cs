using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace productsDetails.Migrations
{
    /// <inheritdoc />
    public partial class dbtablesrecreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productUnitPrice = table.Column<int>(type: "int", nullable: false),
                    productQuantity = table.Column<int>(type: "int", nullable: false),
                    productImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    skuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stockStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stockReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stockTotalCost = table.Column<int>(type: "int", nullable: false),
                    supplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.skuId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
