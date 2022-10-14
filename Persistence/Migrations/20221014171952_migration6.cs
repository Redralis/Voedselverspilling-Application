using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct");

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MealBoxProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MealBoxProduct_MealBoxId",
                table: "MealBoxProduct",
                column: "MealBoxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct");

            migrationBuilder.DropIndex(
                name: "IX_MealBoxProduct_MealBoxId",
                table: "MealBoxProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MealBoxProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" });

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 6, 11 },
                    { 6, 12 }
                });
        }
    }
}
