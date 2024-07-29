using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserFavouritesList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UsersFavourites_UsersFavouritesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UsersFavouritesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UsersFavouritesId",
                table: "Products");

            migrationBuilder.AddColumn<List<int>>(
                name: "Products",
                table: "UsersFavourites",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Products",
                table: "UsersFavourites");

            migrationBuilder.AddColumn<int>(
                name: "UsersFavouritesId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsersFavouritesId",
                table: "Products",
                column: "UsersFavouritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UsersFavourites_UsersFavouritesId",
                table: "Products",
                column: "UsersFavouritesId",
                principalTable: "UsersFavourites",
                principalColumn: "Id");
        }
    }
}
