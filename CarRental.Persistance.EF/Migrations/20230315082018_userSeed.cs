using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Persistance.EF.Migrations
{
    /// <inheritdoc />
    public partial class userSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "FullName", "LicenceDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafajel196@gmail.com", "Rafał Krupa", new DateTime(2016, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2005, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "jplacek@wp.pl", "Janusz Placek", new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1977, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "adaśleć@gmail.com", "Adam Małysz", new DateTime(1996, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
