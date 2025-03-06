using SmartParkingLot.Api.Domain.Variables;

namespace SmartParkingLot.Api.AppStartup;

internal static class CorsConfig
{
    private const string ALLDEVICES_POLICY = "AllowAllDevices";
    internal static IServiceCollection AddCorsDocumentation(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(ALLDEVICES_POLICY, builder => {
                builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

            });
        });
        return services;
    }

    internal static IApplicationBuilder UseCorsDocumentation(this IApplicationBuilder app)
    {
        app.UseCors(ALLDEVICES_POLICY);
        return app;
    }
}