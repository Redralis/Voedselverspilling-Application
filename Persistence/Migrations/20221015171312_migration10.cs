using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 4, 8 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 5, 10 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductId",
                value: 11);

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "Id", "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 13, 6, 12 },
                    { 14, 6, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 4, 7 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 5, 9 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[] { 6, 11 });

            migrationBuilder.UpdateData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductId",
                value: 12);
        }
    }
}
