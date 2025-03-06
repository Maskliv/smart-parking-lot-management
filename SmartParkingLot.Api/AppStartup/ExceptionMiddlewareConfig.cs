using SmartParkingLot.Api.Middleware;

namespace SmartParkingLot.Api.AppStartup;

internal static class ExceptionMiddlewareConfig
{
    internal static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        return app.UseMiddleware<ExceptionMiddleware>();

    }
}