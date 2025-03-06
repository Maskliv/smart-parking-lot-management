using Microsoft.EntityFrameworkCore;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Repository.EF.DbConfigurations;


namespace SmartParkingLot.Test.Mocks.EF;

public class MockAppDbContext: DbContext
{
    public DbSet<Spot> Spots { get; set; }
    public DbSet<Device> Devices { get; set; }

    public MockAppDbContext(DbContextOptions options) : base(options) 
    {
        Database.EnsureCreated();
    }

    public MockAppDbContext() { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=:memory:;Cache=Shared");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new SpotConfiguration());
        modelBuilder.ApplyConfiguration(new DeviceConfiguration());
    }

   

}
