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
            migrationBuilder.AddColumn<bool>(
                name: "IsWarmMeal",
                table: "MealBox",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsWarmMeal",
                value: false);

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsWarmMeal", "MealType" },
                values: new object[] { true, "Warm eten" });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsWarmMeal",
                value: false);

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsWarmMeal",
                value: false);

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsWarmMeal",
                value: false);

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsWarmMeal", "MealType" },
                values: new object[] { true, "Warm eten" });

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsWarmMeal",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWarmMeal",
                table: "MealBox");

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 2,
                column: "MealType",
                value: "Warme maaltijd box");

            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 6,
                column: "MealType",
                value: "Warme maaltijd");
        }
    }
}
