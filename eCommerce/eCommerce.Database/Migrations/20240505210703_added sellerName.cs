using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eCommerce.Database.Migrations
{
    /// <inheritdoc />
    public partial class addedsellerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "UsersAddressesId",
                table: "Address",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAddresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UsersAddressesId",
                table: "Address",
                column: "UsersAddressesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_UsersAddresses_UsersAddressesId",
                table: "Address",
                column: "UsersAddressesId",
                principalTable: "UsersAddresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_UsersAddresses_UsersAddressesId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "UsersAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Address_UsersAddressesId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "UsersAddressesId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
