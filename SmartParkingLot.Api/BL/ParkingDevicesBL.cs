using Microsoft.EntityFrameworkCore;
using SmartParkingLot.Api.Domain.Dto;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Enums;
using SmartParkingLot.Api.Domain.Exceptions;
using SmartParkingLot.Api.Domain.Extensions;
using SmartParkingLot.Api.Domain.Interfaces.Repo;

namespace SmartParkingLot.Api.BL;

public class ParkingDevicesBL(IRepository<Device> _devicesRepo)
{
    
    public async Task<IEnumerable<DeviceDto>> Get(Tuple<int,int> offset, string? orderBy = null)
    {
        Func<IQueryable<Device>, IOrderedQueryable<Device>>? orderByFunc = null;

        if (!string.IsNullOrEmpty(orderBy))
        {
            orderByFunc = q => q.OrderBy(e => EF.Property<object>(e, orderBy));
        }

        var entities =  await _devicesRepo.Get(offset:offset, orderBy: orderByFunc);

        return Mapper.DeviceToDto(entities);

    }

    public async Task<DeviceDto> GetById(Guid id)
    {
        var device = await _devicesRepo.GetById(id) ?? throw new NotFoundException($"Parking device with id: {id} does not exist");
        return Mapper.DeviceToDto(device);
    }

    public async Task<DeviceDto> AddDevice(DeviceDto newDevice)
    {
        Device deviceCreated;
        try
        {
            deviceCreated = await _devicesRepo.Insert(Mapper.DtoToDevice(newDevice));
        }catch(DbUpdateException ex)
        {
            var message = ex.Message + ex.InnerException?.Message ?? string.Empty;
            if (!message.ToLower().Contains("UNIQUE")) 
                throw new BadRequestException("Another Device has the same Guid");
            throw;
        }
        return Mapper.DeviceToDto(deviceCreated);

    }


}
