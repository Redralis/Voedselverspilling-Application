using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Jesse Pinkman Meth Deluxe Snoep");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Blauw Kristalsnoep");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "Photo" },
                values: new object[] { "Normaal Kristalsnoep", "https://cdn11.bigcommerce.com/s-1b75a/images/stencil/500w/products/138/3144/DSCN1797__13248.1652210117.JPG?c=2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealBox",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Jesse Pinkman Meth Deluxe");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Blauw Kristal");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "Photo" },
                values: new object[] { "Normaal Kristal", "https://americanaddictioncenters.org/wp-content/uploads/2015/10/Methamphetamine-also-known-as-85084955.jpg" });
        }
    }
}
