using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PickUpBy", "PickUpTime" },
                values: new object[] { new DateTime(2022, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 20, 18, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 7,
                column: "PickUpBy",
                value: new DateTime(2022, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PickUpBy", "PickUpTime" },
                values: new object[] { new DateTime(2022, 11, 22, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 7,
                column: "PickUpBy",
                value: new DateTime(2022, 11, 22, 18, 30, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
