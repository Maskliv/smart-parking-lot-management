using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartParkingLot.Api.Domain.Entities;

namespace SmartParkingLot.Api.Repository.EF.DbConfigurations;

public class DeviceConfiguration: IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable("Devices");

        builder.HasKey(x => x.DeviceId);

        builder.HasData(
            new Device { DeviceId = new Guid("e3dbf447-569c-4200-afec-fc99eabbcab2") },
            new Device { DeviceId = new Guid("2c6e8dd4-64f9-41aa-b63b-6eb0f254dcb4") },
            new Device { DeviceId = new Guid("14c62319-a6ac-44e9-a342-b7f816f77dd3") },
            new Device { DeviceId = new Guid("4d066444-c081-4199-b2e9-9bf694b2835e") },
            new Device { DeviceId = new Guid("cc735e4b-6a0d-4bd1-bdf6-7a2beb00099a") }
        );

    }
}
