using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SmartParkingLot.Api.AppStartup;

public class DeviceHeaderFilter: IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Device-Id",
            In = ParameterLocation.Header,
            Required = false, 
            Schema = new OpenApiSchema { Type = "string" },
            Description = "Unique ID of the device sending the request"
        });
    }
}
