using SmartParkingLot.Api.Domain.Dto;
using SmartParkingLot.Api.Domain.Entities;

namespace SmartParkingLot.Api.BL;

public class Mapper
{
    public static List<SpotDto> SpotToDto(IEnumerable<Spot> targets)
    {
        return [.. targets.Select(SpotToDto)];
    }

    public static SpotDto SpotToDto(Spot target)
    {
        
        var spotDto = new SpotDto
        {
            
            SpotId = target.SpotId,
            Zone = target.Zone,
            PositionId = target.PositionId,
            Status = target.Status
        };
        
        return spotDto;
    }

    public static List<Spot> DtoToSpot(IEnumerable<SpotDto> targets)
    {
        return [.. targets.Select(DtoToSpot)];
    }

    public static Spot DtoToSpot(SpotDto target)
    {

        var spot = new Spot
        {
            SpotId = target.SpotId,
            Zone = target.Zone,
            PositionId = target.PositionId,
            Status = target.Status
        };

        return spot;
    }

    //Devices

    public static List<DeviceDto> DeviceToDto(IEnumerable<Device> targets)
    {
        return [.. targets.Select(DeviceToDto)];
    }

    public static DeviceDto DeviceToDto(Device target)
    {

        var deviceDto = new DeviceDto
        {

            DeviceId = target.DeviceId
        };

        return deviceDto;
    }

    public static List<Device> DtoToDevice(IEnumerable<DeviceDto> targets)
    {
        return [.. targets.Select(DtoToDevice)];
    }

    public static Device DtoToDevice(DeviceDto target)
    {

        var device = new Device
        {

            DeviceId = target.DeviceId
        };

        return device;
    }
}
