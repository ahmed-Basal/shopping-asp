using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inftastructer.Migrations
{
    /// <inheritdoc />
    public partial class taddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainImage",
                table: "orderItems",
                newName: "image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "orderItems",
                newName: "MainImage");
        }
    }
}
