using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Database.Migrations
{
    /// <inheritdoc />
    public partial class wegdfsg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Products");
        }
    }
}
