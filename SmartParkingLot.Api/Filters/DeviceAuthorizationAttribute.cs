using Microsoft.AspNetCore.Mvc;

namespace SmartParkingLot.Api.Filters;

public class DeviceAuthorizationAttribute: TypeFilterAttribute
{
    public DeviceAuthorizationAttribute() : base(typeof(DeviceAuthorizationFilter)) { }
}
