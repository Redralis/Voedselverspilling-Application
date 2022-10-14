using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpBy", "PickUpTime" },
                values: new object[] { new DateTime(2022, 11, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 11, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpBy", "PickUpTime" },
                values: new object[] { new DateTime(2022, 11, 7, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickUpBy", "PickUpTime" },
                values: new object[] { new DateTime(2022, 11, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PickUpBy", "PickUpTime" },
                values: new object[] { new DateTime(2022, 11, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 11, 15, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
