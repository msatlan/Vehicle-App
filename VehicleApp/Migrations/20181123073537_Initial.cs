using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    VehicleMakeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Abrv = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.VehicleMakeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    VehicleModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Abrv = table.Column<string>(maxLength: 10, nullable: true),
                    VehicleMakeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.VehicleModelId);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleMakes_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "VehicleMakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleMakes");
        }
    }
}
