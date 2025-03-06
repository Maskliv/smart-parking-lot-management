using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkingLot.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    SpotId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Zone = table.Column<string>(type: "TEXT", nullable: false),
                    PositionId = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DeviceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.SpotId);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId");
                });

            migrationBuilder.InsertData(
                table: "Devices",
                column: "DeviceId",
                values: new object[]
                {
                    new Guid("14c62319-a6ac-44e9-a342-b7f816f77dd3"),
                    new Guid("2c6e8dd4-64f9-41aa-b63b-6eb0f254dcb4"),
                    new Guid("4d066444-c081-4199-b2e9-9bf694b2835e"),
                    new Guid("cc735e4b-6a0d-4bd1-bdf6-7a2beb00099a"),
                    new Guid("e3dbf447-569c-4200-afec-fc99eabbcab2")
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_DeviceId",
                table: "ParkingSpots",
                column: "DeviceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
