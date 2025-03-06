using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartParkingLot.Api;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Interfaces.Repo;
using SmartParkingLot.Api.Repository.EF;

namespace SmartParkingLot.Test.Mocks;

public class TestWebFactory: WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove actual
            var spotDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IRepository<Spot>));
            if (spotDescriptor != null)
            {
                services.Remove(spotDescriptor);
            }

            var deviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IRepository<Device>));
            if (deviceDescriptor != null)
            {
                services.Remove(deviceDescriptor);
            }

           
            var appDbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(AppDbContext));
            if (appDbContextDescriptor != null)
            {
                services.Remove(appDbContextDescriptor);
            }

            
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDb")
             ); 

            
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.SaveChanges();
                
            }

            services.AddScoped<DbContext, AppDbContext>();

            services.AddScoped<IRepository<Spot>, MockSpotRepository>();
            services.AddScoped<IRepository<Device>, MockDeviceRepository>();

        });
    }
}
