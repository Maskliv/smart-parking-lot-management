using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.ComponentModel.DataAnnotations;

namespace SmartParkingLot.Api.Domain.Entities;

public class Device
{
    [Key]
    public required Guid DeviceId { get; set; }
    
}
