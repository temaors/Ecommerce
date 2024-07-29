using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Database.Migrations
{
    /// <inheritdoc />
    public partial class Changed_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sellers",
                newName: "ManufacturerName");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ManufacturerName",
                table: "Sellers",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Products",
                type: "integer",
                nullable: true);
        }
    }
}
