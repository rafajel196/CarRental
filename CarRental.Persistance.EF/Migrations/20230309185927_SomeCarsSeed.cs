using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Persistance.EF.Migrations
{
    /// <inheritdoc />
    public partial class SomeCarsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarAddressId", "FuelConsumption", "Mark", "Model", "RegNumber" },
                values: new object[,]
                {
                    { 4, 1, 8.3m, "BMW", "E46", "RLE30098" },
                    { 5, 1, 11.5m, "Peugeot", "406 Coupe", "RLE21372" },
                    { 6, 2, 12.3m, "Audi", "TT", "KR91392" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
