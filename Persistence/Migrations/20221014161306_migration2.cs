using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Brood assortiment");

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsEighteen", "Name", "PickUpBy", "PickUpTime" },
                values: new object[] { false, "Warme maaltijd", new DateTime(2022, 11, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 11, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "PickUpBy", "PickUpTime" },
                values: new object[] { "Frisdrank arrangement", new DateTime(2022, 11, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 17, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "PickUpBy", "PickUpTime" },
                values: new object[] { "Diverse mixdrankjes", new DateTime(2022, 11, 22, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Gezonde maaltijd box");

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsEighteen", "Name", "PickUpBy", "PickUpTime" },
                values: new object[] { true, "Zaterdagmiddag", new DateTime(2022, 11, 7, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "PickUpBy", "PickUpTime" },
                values: new object[] { "Panini box", new DateTime(2022, 11, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "PickUpBy", "PickUpTime" },
                values: new object[] { "18+'ers box", new DateTime(2022, 11, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
