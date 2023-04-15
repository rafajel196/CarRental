using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Persistance.EF.Migrations
{
    public partial class PriceCategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceCategoryId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PriceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Multiplier = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PriceCategories",
                columns: new[] { "Id", "Category", "Multiplier" },
                values: new object[,]
                {
                    { 1, "Basic", 1m },
                    { 2, "Standard", 1.3m },
                    { 3, "Medium", 1.6m },
                    { 4, "Premium", 2m }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriceCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriceCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "PriceCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "PriceCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "PriceCategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceCategoryId",
                table: "Cars",
                column: "PriceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_PriceCategories_PriceCategoryId",
                table: "Cars",
                column: "PriceCategoryId",
                principalTable: "PriceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_PriceCategories_PriceCategoryId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "PriceCategories");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PriceCategoryId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PriceCategoryId",
                table: "Cars");
        }
    }
}
