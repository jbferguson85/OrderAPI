using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderAccessors.Migrations
{
    public partial class EntityColumnDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_line_items_orders_order_entity_id",
                schema: "order_api",
                table: "line_items");

            migrationBuilder.DropIndex(
                name: "ix_line_items_order_entity_id",
                schema: "order_api",
                table: "line_items");

            migrationBuilder.DropColumn(
                name: "order_entity_id",
                schema: "order_api",
                table: "line_items");

            migrationBuilder.AddForeignKey(
                name: "fk_line_items_orders_order_entity_id",
                schema: "order_api",
                table: "line_items",
                column: "order_id",
                principalSchema: "order_api",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_line_items_orders_order_entity_id",
                schema: "order_api",
                table: "line_items");

            migrationBuilder.AddColumn<int>(
                name: "order_entity_id",
                schema: "order_api",
                table: "line_items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_line_items_order_entity_id",
                schema: "order_api",
                table: "line_items",
                column: "order_entity_id");

            migrationBuilder.AddForeignKey(
                name: "fk_line_items_orders_order_entity_id",
                schema: "order_api",
                table: "line_items",
                column: "order_entity_id",
                principalSchema: "order_api",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
