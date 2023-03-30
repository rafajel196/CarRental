using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistance.EF.Migrations
{
    /// <inheritdoc />
    public partial class john : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullName",
                value: "Jacek Placek");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullName",
                value: "Janusz Placek");
        }
    }
}
