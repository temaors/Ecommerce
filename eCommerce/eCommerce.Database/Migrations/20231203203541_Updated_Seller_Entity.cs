using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Database.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Seller_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CashAccount",
                table: "Sellers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashAccount",
                table: "Sellers");
        }
    }
}
