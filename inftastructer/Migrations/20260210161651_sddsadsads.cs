using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inftastructer.Migrations
{
    /// <inheritdoc />
    public partial class sddsadsads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "iamgename", "productId" },
                values: new object[] { 1, "image1.jpg", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
