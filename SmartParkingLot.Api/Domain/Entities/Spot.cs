using SmartParkingLot.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartParkingLot.Api.Domain.Entities;

public class Spot
{    
    [Key]
    public long SpotId { get; set; }
    public required string Zone { get; set; }
    public required string PositionId { get; set; }
    public SpotStatus Status { get; set; }

    
}
