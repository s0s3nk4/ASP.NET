using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_ASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentsType_EquipmentTypeId",
                table: "Equipments");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentsType_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId",
                principalTable: "EquipmentsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentsType_EquipmentTypeId",
                table: "Equipments");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentsType_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId",
                principalTable: "EquipmentsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
