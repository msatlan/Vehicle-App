using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleApp.Migrations
{
    public partial class IdChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleModelId",
                table: "VehicleModels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehicleMakeId",
                table: "VehicleMakes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleModels",
                newName: "VehicleModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleMakes",
                newName: "VehicleMakeId");
        }
    }
}
