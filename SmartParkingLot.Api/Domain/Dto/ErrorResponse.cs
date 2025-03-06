using Newtonsoft.Json;

namespace SmartParkingLot.Api.Domain.Dto;

public class ErrorResponse(string description)
{
    
    public string Error { get; set; } = description;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}