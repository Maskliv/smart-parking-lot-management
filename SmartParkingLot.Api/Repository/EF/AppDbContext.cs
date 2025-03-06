using Microsoft.EntityFrameworkCore;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Repository.EF.DbConfigurations;
using System.Reflection;

namespace SmartParkingLot.Api.Repository.EF;

public class AppDbContext : DbContext
{
    static AppDbContext()
    {
        SQLitePCL.Batteries.Init();
    }
    public DbSet<Spot> Spots { get; set; }
    public DbSet<Device> Devices { get; set; }
    

    public AppDbContext(DbContextOptions options) : base(options) { }

    public AppDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Filename=" + "SmartParkingDB.db",
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName
                        );
                });
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SpotConfiguration());
        modelBuilder.ApplyConfiguration(new DeviceConfiguration());

    }
    
}