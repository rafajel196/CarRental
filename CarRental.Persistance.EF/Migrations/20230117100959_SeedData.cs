using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Persistance.EF.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarAddresses",
                columns: new[] { "Id", "City", "Street" },
                values: new object[,]
                {
                    { 1, "Rzeszów", "Architektów 4" },
                    { 2, "Kraków", "Rostafińskiego 9" },
                    { 3, "Wrocław", "Witelona 25" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarAddressId", "FuelConsumption", "Mark", "Model", "RegNumber" },
                values: new object[,]
                {
                    { 1, 1, 11.5m, "Peugeot", "406 Coupe", "RLE20095" },
                    { 2, 2, 14.2m, "BMW", "760Li", "RZ30571" },
                    { 3, 3, 12.8m, "Audi", "R8", "KR87937" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarAddresses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
