using SmartParkingLot.Api.BL;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Interfaces.Repo;
using SmartParkingLot.Api.Domain.Variables;
using SmartParkingLot.Api.Repository;
namespace SmartParkingLot.Api.AppStartup;

internal static class DependencyInjectionConfig
{
    internal static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration config)
    {
        #region Repository

        services.AddScoped<IRepository<Spot>, ParkingSpotRepository>();
        services.AddScoped<IRepository<Device>, ParkingDeviceRepository>();
        #endregion

        #region Application BL

        services.AddScoped<ParkingSpotsBL>();
        services.AddScoped<ParkingDevicesBL>();

        #endregion

        


    }
}