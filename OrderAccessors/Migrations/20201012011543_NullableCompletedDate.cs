using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderAccessors.Migrations
{
    public partial class NullableCompletedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orders_customers_customer_id",
                schema: "order_api",
                table: "orders");

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                schema: "order_api",
                table: "orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "completed_date",
                schema: "order_api",
                table: "orders",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddForeignKey(
                name: "fk_orders_customers_customer_id",
                schema: "order_api",
                table: "orders",
                column: "customer_id",
                principalSchema: "order_api",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orders_customers_customer_id",
                schema: "order_api",
                table: "orders");

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                schema: "order_api",
                table: "orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "completed_date",
                schema: "order_api",
                table: "orders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_customers_customer_id",
                schema: "order_api",
                table: "orders",
                column: "customer_id",
                principalSchema: "order_api",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
