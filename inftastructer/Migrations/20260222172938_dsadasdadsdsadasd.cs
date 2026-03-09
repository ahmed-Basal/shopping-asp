using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inftastructer.Migrations
{
    /// <inheritdoc />
    public partial class dsadasdadsdsadasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_orders_ordersId",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_deliveryMethods_deliveryMethodId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "subtotal",
                table: "orders",
                newName: "Subtotal");

            migrationBuilder.RenameColumn(
                name: "orderDate",
                table: "orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "deliveryMethodId",
                table: "orders",
                newName: "DeliveryMethodId");

            migrationBuilder.RenameColumn(
                name: "buyeremail",
                table: "orders",
                newName: "BuyerEmail");

            migrationBuilder.RenameColumn(
                name: "address_ZipCode",
                table: "orders",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "address_Street",
                table: "orders",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "address_State",
                table: "orders",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "address_LastName",
                table: "orders",
                newName: "Address_LastName");

            migrationBuilder.RenameColumn(
                name: "address_Id",
                table: "orders",
                newName: "Address_Id");

            migrationBuilder.RenameColumn(
                name: "address_FirstName",
                table: "orders",
                newName: "Address_FirstName");

            migrationBuilder.RenameColumn(
                name: "address_City",
                table: "orders",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "statues",
                table: "orders",
                newName: "Status");

            migrationBuilder.RenameIndex(
                name: "IX_orders_deliveryMethodId",
                table: "orders",
                newName: "IX_orders_DeliveryMethodId");

            migrationBuilder.RenameColumn(
                name: "ordersId",
                table: "orderItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_ordersId",
                table: "orderItems",
                newName: "IX_orderItems_OrderId");

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_orders_OrderId",
                table: "orderItems",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_deliveryMethods_DeliveryMethodId",
                table: "orders",
                column: "DeliveryMethodId",
                principalTable: "deliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_orders_OrderId",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_deliveryMethods_DeliveryMethodId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Subtotal",
                table: "orders",
                newName: "subtotal");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "orders",
                newName: "orderDate");

            migrationBuilder.RenameColumn(
                name: "DeliveryMethodId",
                table: "orders",
                newName: "deliveryMethodId");

            migrationBuilder.RenameColumn(
                name: "BuyerEmail",
                table: "orders",
                newName: "buyeremail");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "orders",
                newName: "address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "orders",
                newName: "address_Street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "orders",
                newName: "address_State");

            migrationBuilder.RenameColumn(
                name: "Address_LastName",
                table: "orders",
                newName: "address_LastName");

            migrationBuilder.RenameColumn(
                name: "Address_Id",
                table: "orders",
                newName: "address_Id");

            migrationBuilder.RenameColumn(
                name: "Address_FirstName",
                table: "orders",
                newName: "address_FirstName");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "orders",
                newName: "address_City");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "orders",
                newName: "statues");

            migrationBuilder.RenameIndex(
                name: "IX_orders_DeliveryMethodId",
                table: "orders",
                newName: "IX_orders_deliveryMethodId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "orderItems",
                newName: "ordersId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                newName: "IX_orderItems_ordersId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_orders_ordersId",
                table: "orderItems",
                column: "ordersId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_deliveryMethods_deliveryMethodId",
                table: "orders",
                column: "deliveryMethodId",
                principalTable: "deliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
