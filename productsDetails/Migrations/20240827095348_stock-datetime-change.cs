using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace productsDetails.Migrations
{
    /// <inheritdoc />
    public partial class stockdatetimechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "stockReceiveDate",
                table: "Stocks",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "stockReceiveDate",
                table: "Stocks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
