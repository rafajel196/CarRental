using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistance.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarAddress_CarAddressId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarAddress",
                table: "CarAddress");

            migrationBuilder.RenameTable(
                name: "CarAddress",
                newName: "CarAddresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarAddresses",
                table: "CarAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarAddresses_CarAddressId",
                table: "Cars",
                column: "CarAddressId",
                principalTable: "CarAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarAddresses_CarAddressId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarAddresses",
                table: "CarAddresses");

            migrationBuilder.RenameTable(
                name: "CarAddresses",
                newName: "CarAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarAddress",
                table: "CarAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarAddress_CarAddressId",
                table: "Cars",
                column: "CarAddressId",
                principalTable: "CarAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
