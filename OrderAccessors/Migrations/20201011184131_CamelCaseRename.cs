using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderAccessors.Migrations
{
    public partial class CamelCaseRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_OrderEntityId",
                schema: "Order",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                schema: "Order",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                schema: "Order",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineItems",
                schema: "Order",
                table: "LineItems");

            migrationBuilder.EnsureSchema(
                name: "order_api");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Order",
                newName: "products",
                newSchema: "order_api");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "Order",
                newName: "orders",
                newSchema: "order_api");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "Order",
                newName: "customers",
                newSchema: "order_api");

            migrationBuilder.RenameTable(
                name: "LineItems",
                schema: "Order",
                newName: "line_items",
                newSchema: "order_api");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "order_api",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "order_api",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "order_api",
                table: "products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "order_api",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                schema: "order_api",
                table: "products",
                newName: "item_code");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "order_api",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                schema: "order_api",
                table: "orders",
                newName: "order_status");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                schema: "order_api",
                table: "orders",
                newName: "order_number");

            migrationBuilder.RenameColumn(
                name: "OrderName",
                schema: "order_api",
                table: "orders",
                newName: "order_name");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "order_api",
                table: "orders",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "order_api",
                table: "orders",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CompletedDate",
                schema: "order_api",
                table: "orders",
                newName: "completed_date");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                schema: "order_api",
                table: "orders",
                newName: "ix_orders_customer_id");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "order_api",
                table: "customers",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "City",
                schema: "order_api",
                table: "customers",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "order_api",
                table: "customers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "order_api",
                table: "customers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                schema: "order_api",
                table: "customers",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "CustomerNumber",
                schema: "order_api",
                table: "customers",
                newName: "customer_number");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                schema: "order_api",
                table: "customers",
                newName: "customer_name");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "order_api",
                table: "line_items",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "order_api",
                table: "line_items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Discount",
                schema: "order_api",
                table: "line_items",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "order_api",
                table: "line_items",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "order_api",
                table: "line_items",
                newName: "total_price");

            migrationBuilder.RenameColumn(
                name: "OrderEntityId",
                schema: "order_api",
                table: "line_items",
                newName: "order_entity_id");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                schema: "order_api",
                table: "line_items",
                newName: "item_code");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "order_api",
                table: "line_items",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                schema: "order_api",
                table: "line_items",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_OrderEntityId",
                schema: "order_api",
                table: "line_items",
                newName: "ix_line_items_order_entity_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_products",
                schema: "order_api",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orders",
                schema: "order_api",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_customers",
                schema: "order_api",
                table: "customers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_line_items",
                schema: "order_api",
                table: "line_items",
                columns: new[] { "order_id", "product_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_line_items_orders_order_entity_id",
                schema: "order_api",
                table: "line_items",
                column: "order_entity_id",
                principalSchema: "order_api",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_line_items_orders_order_entity_id",
                schema: "order_api",
                table: "line_items");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_customers_customer_id",
                schema: "order_api",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_products",
                schema: "order_api",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orders",
                schema: "order_api",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_customers",
                schema: "order_api",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_line_items",
                schema: "order_api",
                table: "line_items");

            migrationBuilder.EnsureSchema(
                name: "Order");

            migrationBuilder.RenameTable(
                name: "products",
                schema: "order_api",
                newName: "Products",
                newSchema: "Order");

            migrationBuilder.RenameTable(
                name: "orders",
                schema: "order_api",
                newName: "Orders",
                newSchema: "Order");

            migrationBuilder.RenameTable(
                name: "customers",
                schema: "order_api",
                newName: "Customers",
                newSchema: "Order");

            migrationBuilder.RenameTable(
                name: "line_items",
                schema: "order_api",
                newName: "LineItems",
                newSchema: "Order");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "Order",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "Order",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "Order",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "Order",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "item_code",
                schema: "Order",
                table: "Products",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "Order",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "order_status",
                schema: "Order",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "order_number",
                schema: "Order",
                table: "Orders",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "order_name",
                schema: "Order",
                table: "Orders",
                newName: "OrderName");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                schema: "Order",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                schema: "Order",
                table: "Orders",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "completed_date",
                schema: "Order",
                table: "Orders",
                newName: "CompletedDate");

            migrationBuilder.RenameIndex(
                name: "ix_orders_customer_id",
                schema: "Order",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "state",
                schema: "Order",
                table: "Customers",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "city",
                schema: "Order",
                table: "Customers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                schema: "Order",
                table: "Customers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "Order",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                schema: "Order",
                table: "Customers",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "customer_number",
                schema: "Order",
                table: "Customers",
                newName: "CustomerNumber");

            migrationBuilder.RenameColumn(
                name: "customer_name",
                schema: "Order",
                table: "Customers",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "quantity",
                schema: "Order",
                table: "LineItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "Order",
                table: "LineItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "discount",
                schema: "Order",
                table: "LineItems",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "Order",
                table: "LineItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "total_price",
                schema: "Order",
                table: "LineItems",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "order_entity_id",
                schema: "Order",
                table: "LineItems",
                newName: "OrderEntityId");

            migrationBuilder.RenameColumn(
                name: "item_code",
                schema: "Order",
                table: "LineItems",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "Order",
                table: "LineItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                schema: "Order",
                table: "LineItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "ix_line_items_order_entity_id",
                schema: "Order",
                table: "LineItems",
                newName: "IX_LineItems_OrderEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                schema: "Order",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "Order",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                schema: "Order",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineItems",
                schema: "Order",
                table: "LineItems",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_OrderEntityId",
                schema: "Order",
                table: "LineItems",
                column: "OrderEntityId",
                principalSchema: "Order",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                schema: "Order",
                table: "Orders",
                column: "CustomerId",
                principalSchema: "Order",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
