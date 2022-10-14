using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MealBoxProduct",
                keyColumns: new[] { "MealBoxId", "ProductId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Canteen",
                columns: new[] { "Id", "Address", "City", "ServesWarmMeals" },
                values: new object[] { 3, "Professor Cobbenhagenlaan 13", "Tilburg", true });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudentId",
                value: null);

            migrationBuilder.InsertData(
                table: "MealBox",
                columns: new[] { "Id", "CanteenId", "City", "IsEighteen", "MealType", "Name", "PickUpBy", "PickUpTime", "Price", "StudentId" },
                values: new object[] { 5, 1, "Breda", false, "Box", "Dessert mix", new DateTime(2022, 11, 23, 14, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 22, 14, 20, 0, 0, DateTimeKind.Unspecified), 17.50m, 1 });

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "IsAlcoholic", "Name", "Photo" },
                values: new object[,]
                {
                    { 9, false, "IJs", "https://images.pexels.com/photos/1294943/pexels-photo-1294943.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1" },
                    { 10, false, "Macarons", "https://images.pexels.com/photos/239578/pexels-photo-239578.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1" },
                    { 11, false, "Popcorn", "https://images.pexels.com/photos/33129/popcorn-movie-party-entertainment.jpg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1" },
                    { 12, false, "Chips", "https://images.pexels.com/photos/568805/pexels-photo-568805.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1" }
                });

            migrationBuilder.InsertData(
                table: "MealBox",
                columns: new[] { "Id", "CanteenId", "City", "IsEighteen", "MealType", "Name", "PickUpBy", "PickUpTime", "Price", "StudentId" },
                values: new object[] { 6, 3, "Tilburg", false, "Box", "Snacks", new DateTime(2022, 11, 27, 16, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 26, 16, 15, 0, 0, DateTimeKind.Unspecified), 7.50m, null });

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 5, 9 },
                    { 5, 10 },
                    { 6, 11 },
                    { 6, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Canteen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudentId",
                value: 1);

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 }
                });
        }
    }
}
