using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColumnTypesAndIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Providers",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Orders",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "timestamp(7) with time zone",
                precision: 7,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "OrderItems",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "OrderItems",
                type: "numeric(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderItems",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Number_ProviderId",
                table: "Orders",
                columns: new[] { "Number", "ProviderId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_Number_ProviderId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Providers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(7) with time zone",
                oldPrecision: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "OrderItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "OrderItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }
    }
}
