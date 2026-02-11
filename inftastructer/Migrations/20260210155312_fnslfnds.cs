using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inftastructer.Migrations
{
    /// <inheritdoc />
    public partial class fnslfnds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "price",
                value: 20.5m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "price",
                value: 0m);
        }
    }
}
