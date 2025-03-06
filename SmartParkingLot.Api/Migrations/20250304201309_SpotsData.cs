using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartParkingLot.Api.Migrations
{
    /// <inheritdoc />
    public partial class SpotsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "SpotId", "DeviceId", "PositionId", "Status", "Zone" },
                values: new object[,]
                {
                    { 1L, null, "A-101", "Free", "A" },
                    { 2L, new Guid("cc735e4b-6a0d-4bd1-bdf6-7a2beb00099a"), "A-102", "Occupied", "A" },
                    { 3L, new Guid("4d066444-c081-4199-b2e9-9bf694b2835e"), "B-201", "Occupied", "B" },
                    { 4L, new Guid("14c62319-a6ac-44e9-a342-b7f816f77dd3"), "C-305", "Free", "C" },
                    { 5L, null, "A-103", "Free", "A" },
                    { 6L, new Guid("2c6e8dd4-64f9-41aa-b63b-6eb0f254dcb4"), "B-202", "Free", "B" },
                    { 7L, new Guid("e3dbf447-569c-4200-afec-fc99eabbcab2"), "C-306", "Occupied", "C" },
                    { 8L, null, "A-104", "Free", "A" },
                    { 9L, null, "B-203", "Free", "B" },
                    { 10L, null, "C-307", "Free", "C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "SpotId",
                keyValue: 10L);
        }
    }
}
