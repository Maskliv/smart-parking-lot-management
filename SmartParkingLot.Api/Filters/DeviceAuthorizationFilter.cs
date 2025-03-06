using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Exceptions;
using SmartParkingLot.Api.Domain.Interfaces.Repo;

namespace SmartParkingLot.Api.Filters;

public class DeviceAuthorizationFilter(IRepository<Device> _deviceRepo): IAsyncActionFilter
{
    

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("Device-Id", out var deviceId))
        {
            throw new UnauthorizedException("'Device-Id' header is missing and required");
        }

        if (!Guid.TryParse(deviceId, out Guid deviceIdGuid)) throw new UnauthorizedException($"Device-Id: {deviceId} is not authorized");

        bool exists = (await _deviceRepo.GetById(deviceIdGuid)) != null;
        if (!exists)
        {
            context.Result = new UnauthorizedObjectResult($"Device-Id: {deviceId} is not authorized");
            return;
        }

        context.HttpContext.Items["DeviceId"] = deviceIdGuid;

        await next();
    }
}
