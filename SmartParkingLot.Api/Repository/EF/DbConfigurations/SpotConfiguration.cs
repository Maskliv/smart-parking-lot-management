using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Enums;

namespace SmartParkingLot.Api.Repository.EF.DbConfigurations;

public class SpotConfiguration: IEntityTypeConfiguration<Spot>
{
    public void Configure(EntityTypeBuilder<Spot> builder)
    {
        builder.ToTable("ParkingSpots");

        builder.HasKey(x => x.SpotId);

        builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<string>();

        builder.HasData(
            
            new
            {
                SpotId = 2L,
                Zone = "A",
                PositionId = "A-102",
                Status = SpotStatus.Occupied,
            },
            new
            {
                SpotId = 3L,
                Zone = "B",
                PositionId = "B-201",
                Status = SpotStatus.Occupied,
            },
            new
            {
                SpotId = 4L,
                Zone = "C",
                PositionId = "C-305",
                Status = SpotStatus.Free,
            },
            
            new
            {
                SpotId = 6L,
                Zone = "B",
                PositionId = "B-202",
                Status = SpotStatus.Free,
            },
            new
            {
                SpotId = 7L,
                Zone = "C",
                PositionId = "C-306",
                Status = SpotStatus.Occupied,
            }
            );
    }
}
