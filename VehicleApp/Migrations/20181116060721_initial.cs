using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    VehicleMakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    VehicleModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Abrv = table.Column<string>(maxLength: 10, nullable: true),
                    VehicleMakeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.VehicleModelId);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleMakes_VehicleMakeID",
                        column: x => x.VehicleMakeID,
                        principalTable: "VehicleMakes",
                        principalColumn: "VehicleMakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "VehicleMakeId", "Abrv", "Name" },
                values: new object[] { 1, "Zst", "Zastava" });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "VehicleMakeId", "Abrv", "Name" },
                values: new object[] { 2, "Rnt", "Renault" });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "VehicleMakeId", "Abrv", "Name" },
                values: new object[] { 3, "Trb", "Trabant" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "VehicleModelId", "Abrv", "Name", "VehicleMakeID" },
                values: new object[,]
                {
                    { 1, "Y", "Yugo45", 1 },
                    { 2, "F", "750", 1 },
                    { 3, "4", "4", 2 },
                    { 4, "C", "Clio", 2 },
                    { 5, "6", "601", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleMakeID",
                table: "VehicleModels",
                column: "VehicleMakeID");
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
