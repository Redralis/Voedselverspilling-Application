using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 7,
                column: "MealType",
                value: "Snoep");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 7,
                column: "MealType",
                value: "Warme maaltijd");
        }
    }
}
