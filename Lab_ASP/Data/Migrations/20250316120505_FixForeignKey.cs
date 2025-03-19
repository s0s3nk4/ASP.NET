using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab_ASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EquipmentsType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EquipmentsType",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EquipmentsType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bike" },
                    { 2, "Scooter" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "EquipmentTypeId", "ImageURL", "Make", "Model", "RentalPointId", "Year" },
                values: new object[,]
                {
                    { 1, "Mountain bike", 1, "images/bike.jpg", "Giant", "Trance 3", 1, 2021 },
                    { 2, "Super scooter", 1, "images/scooter.jpg", "Xiaomi", "SC2", 1, 2023 }
                });
        }
    }
}
