using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canteen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServesWarmMeals = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canteen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAlcoholic = table.Column<bool>(type: "bit", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.CheckConstraint("CK_DateOfBirth_NotInFuture", "DateOfBirth <= GetDate()");
                    table.CheckConstraint("CK_DateOfBirth_NotUnder16", "DateOfBirth <= DATEADD(yyyy,-16,getdate())");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanteenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Canteen_CanteenId",
                        column: x => x.CanteenId,
                        principalTable: "Canteen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealBox",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickUpBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEighteen = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CanteenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealBox_Canteen_CanteenId",
                        column: x => x.CanteenId,
                        principalTable: "Canteen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealBox_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealBoxProduct",
                columns: table => new
                {
                    MealBoxId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealBoxProduct", x => new { x.MealBoxId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_MealBoxProduct_MealBox_MealBoxId",
                        column: x => x.MealBoxId,
                        principalTable: "MealBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealBoxProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Canteen",
                columns: new[] { "Id", "Address", "City", "ServesWarmMeals" },
                values: new object[,]
                {
                    { 1, "Lovensdijkstraat 61", "Breda", true },
                    { 2, "Lovensdijkstraat 63", "Breda", true }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "IsAlcoholic", "Name", "Photo" },
                values: new object[,]
                {
                    { 1, false, "Hot dog", "Picture of a hot dog" },
                    { 2, true, "Beer", "Picture of a beer glass" },
                    { 3, false, "Sandwich", "Picture of a sandwich" },
                    { 4, false, "Water", "Picture of a bottle of water" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "City", "DateOfBirth", "Email", "Name", "PhoneNr", "StudentNr" },
                values: new object[,]
                {
                    { 1, "Dordrecht", "2003-01-27", "lucas@email.com", "Lucas", "0692837263", "2191372" },
                    { 2, "Dordrecht", "2002-01-19", "jaron@email.com", "Jaron", "0682731928", "2194746" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CanteenId", "Email", "EmployeeNr", "Name" },
                values: new object[,]
                {
                    { 1, 1, "quinn@email.com", "2187362", "Quinn" },
                    { 2, 2, "hansgerard@email.com", "2193726", "Hans Gerard" }
                });

            migrationBuilder.InsertData(
                table: "MealBox",
                columns: new[] { "Id", "CanteenId", "City", "IsEighteen", "MealType", "Name", "PickUpBy", "PickUpTime", "Price", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, "Breda", false, "Box", "Gezonde maaltijd box", new DateTime(2022, 11, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), 22.50m, 1 },
                    { 2, 2, "Breda", true, "Box", "Zaterdagmiddag", new DateTime(2022, 11, 7, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), 5.25m, null },
                    { 3, 2, "Breda", false, "Box", "Panini box", new DateTime(2022, 11, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), 15.50m, null },
                    { 4, 1, "Breda", true, "Box", "18+'ers box", new DateTime(2022, 11, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), 30.00m, null }
                });

            migrationBuilder.InsertData(
                table: "MealBoxProduct",
                columns: new[] { "MealBoxId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CanteenId",
                table: "Employee",
                column: "CanteenId");

            migrationBuilder.CreateIndex(
                name: "IX_MealBox_CanteenId",
                table: "MealBox",
                column: "CanteenId");

            migrationBuilder.CreateIndex(
                name: "IX_MealBox_StudentId",
                table: "MealBox",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MealBoxProduct_ProductId",
                table: "MealBoxProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "MealBoxProduct");

            migrationBuilder.DropTable(
                name: "MealBox");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Canteen");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
