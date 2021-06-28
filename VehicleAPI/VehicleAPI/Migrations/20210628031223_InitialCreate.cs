using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    VehicleMaker = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InspectorName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    InspectionLocation = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    InspectionStatus = table.Column<bool>(type: "bit", nullable: false),
                    InspectionNotes = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.VIN);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMakers",
                columns: table => new
                {
                    Maker_ID = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Maker_Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakers", x => x.Maker_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "VehicleMakers");
        }
    }
}
