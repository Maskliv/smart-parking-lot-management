﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartParkingLot.Api.Repository.EF;

#nullable disable

namespace SmartParkingLot.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250304201309_SpotsData")]
    partial class SpotsData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.13");

            modelBuilder.Entity("SmartParkingLot.Api.Domain.Dto.Device", b =>
                {
                    b.Property<Guid>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices", (string)null);

                    b.HasData(
                        new
                        {
                            DeviceId = new Guid("e3dbf447-569c-4200-afec-fc99eabbcab2")
                        },
                        new
                        {
                            DeviceId = new Guid("2c6e8dd4-64f9-41aa-b63b-6eb0f254dcb4")
                        },
                        new
                        {
                            DeviceId = new Guid("14c62319-a6ac-44e9-a342-b7f816f77dd3")
                        },
                        new
                        {
                            DeviceId = new Guid("4d066444-c081-4199-b2e9-9bf694b2835e")
                        },
                        new
                        {
                            DeviceId = new Guid("cc735e4b-6a0d-4bd1-bdf6-7a2beb00099a")
                        });
                });

            modelBuilder.Entity("SmartParkingLot.Api.Domain.Dto.Spot", b =>
                {
                    b.Property<long>("SpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("DeviceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SpotId");

                    b.HasIndex("DeviceId")
                        .IsUnique();

                    b.ToTable("ParkingSpots", (string)null);

                    b.HasData(
                        new
                        {
                            SpotId = 1L,
                            PositionId = "A-101",
                            Status = "Free",
                            Zone = "A"
                        },
                        new
                        {
                            SpotId = 2L,
                            DeviceId = new Guid("cc735e4b-6a0d-4bd1-bdf6-7a2beb00099a"),
                            PositionId = "A-102",
                            Status = "Occupied",
                            Zone = "A"
                        },
                        new
                        {
                            SpotId = 3L,
                            DeviceId = new Guid("4d066444-c081-4199-b2e9-9bf694b2835e"),
                            PositionId = "B-201",
                            Status = "Occupied",
                            Zone = "B"
                        },
                        new
                        {
                            SpotId = 4L,
                            DeviceId = new Guid("14c62319-a6ac-44e9-a342-b7f816f77dd3"),
                            PositionId = "C-305",
                            Status = "Free",
                            Zone = "C"
                        },
                        new
                        {
                            SpotId = 5L,
                            PositionId = "A-103",
                            Status = "Free",
                            Zone = "A"
                        },
                        new
                        {
                            SpotId = 6L,
                            DeviceId = new Guid("2c6e8dd4-64f9-41aa-b63b-6eb0f254dcb4"),
                            PositionId = "B-202",
                            Status = "Free",
                            Zone = "B"
                        },
                        new
                        {
                            SpotId = 7L,
                            DeviceId = new Guid("e3dbf447-569c-4200-afec-fc99eabbcab2"),
                            PositionId = "C-306",
                            Status = "Occupied",
                            Zone = "C"
                        },
                        new
                        {
                            SpotId = 8L,
                            PositionId = "A-104",
                            Status = "Free",
                            Zone = "A"
                        },
                        new
                        {
                            SpotId = 9L,
                            PositionId = "B-203",
                            Status = "Free",
                            Zone = "B"
                        },
                        new
                        {
                            SpotId = 10L,
                            PositionId = "C-307",
                            Status = "Free",
                            Zone = "C"
                        });
                });

            modelBuilder.Entity("SmartParkingLot.Api.Domain.Dto.Spot", b =>
                {
                    b.HasOne("SmartParkingLot.Api.Domain.Dto.Device", "Device")
                        .WithOne("ParkingSpot")
                        .HasForeignKey("SmartParkingLot.Api.Domain.Dto.Spot", "DeviceId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("SmartParkingLot.Api.Domain.Dto.Device", b =>
                {
                    b.Navigation("ParkingSpot");
                });
#pragma warning restore 612, 618
        }
    }
}
