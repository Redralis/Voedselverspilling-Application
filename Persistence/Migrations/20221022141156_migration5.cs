using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct");

            migrationBuilder.DropIndex(
                name: "IX_MealBoxProduct_ProductId",
                table: "MealBoxProduct");

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MealBoxProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealBoxProduct",
                table: "MealBoxProduct",
                columns: new[] { "ProductId", "MealBoxId" });

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 5 },
                    { 3, 6 },
                    { 6, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 6, 11 },
                    { 6, 12 },
                    { 7, 13 },
                    { 7, 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { 2, 5 });

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
                keyValues: new object[] { 6, 6 });

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

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 7, 14 });

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

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "Id", "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 5 },
                    { 5, 2, 4 },
                    { 6, 3, 5 },
                    { 7, 3, 6 },
                    { 8, 4, 7 },
                    { 9, 4, 8 },
                    { 10, 5, 9 },
                    { 11, 5, 10 },
                    { 12, 6, 11 },
                    { 13, 6, 12 },
                    { 14, 6, 6 },
                    { 15, 7, 13 },
                    { 16, 7, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealBoxProduct_ProductId",
                table: "MealBoxProduct",
                column: "ProductId");
        }
    }
}
