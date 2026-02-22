using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inftastructer.Migrations
{
    /// <inheritdoc />
    public partial class sddsadsasdsasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deliveryMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buyeremail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_Id = table.Column<int>(type: "int", nullable: false),
                    deliveryMethodId = table.Column<int>(type: "int", nullable: false),
                    statues = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_deliveryMethods_deliveryMethodId",
                        column: x => x.deliveryMethodId,
                        principalTable: "deliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ordersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_ordersId",
                        column: x => x.ordersId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ordersId",
                table: "orderItems",
                column: "ordersId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_deliveryMethodId",
                table: "orders",
                column: "deliveryMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "deliveryMethods");
        }
    }
}
