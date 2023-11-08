using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixedPointOfDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PointOfDeliveries_PointOfDeliveryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PointOfDeliveryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PointOfDeliveryId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointOfDeliveryId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PointOfDeliveryId",
                table: "Users",
                column: "PointOfDeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PointOfDeliveries_PointOfDeliveryId",
                table: "Users",
                column: "PointOfDeliveryId",
                principalTable: "PointOfDeliveries",
                principalColumn: "Id");
        }
    }
}
