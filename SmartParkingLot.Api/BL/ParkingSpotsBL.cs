using Microsoft.EntityFrameworkCore;
using SmartParkingLot.Api.Domain.Dto;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Enums;
using SmartParkingLot.Api.Domain.Exceptions;
using SmartParkingLot.Api.Domain.Extensions;
using SmartParkingLot.Api.Domain.Interfaces.Repo;

namespace SmartParkingLot.Api.BL;

public class ParkingSpotsBL(IRepository<Spot> _spotsRepo)
{
    
    public async Task<IEnumerable<SpotDto>> Get(Tuple<int,int> offset, string? orderBy = null)
    {
        Func<IQueryable<Spot>, IOrderedQueryable<Spot>>? orderByFunc = null;

        if (!string.IsNullOrEmpty(orderBy))
        {
            orderByFunc = q => q.OrderBy(e => EF.Property<object>(e, orderBy));
        }

        var entities =  await _spotsRepo.Get(offset:offset, orderBy: orderByFunc);

        return Mapper.SpotToDto(entities);

    }

    public async Task<SpotDto> GetById(long id)
    {
        var spot = await _spotsRepo.GetById(id) ?? throw new NotFoundException($"Parking spot with id: {id} does not exist");
        return Mapper.SpotToDto(spot);
    }

    public async Task<SpotDto> AddSpot(SpotDto newSpot)
    {
        var spotCreated = await _spotsRepo.Insert(Mapper.DtoToSpot(newSpot));
        return Mapper.SpotToDto(spotCreated);

    }

    public async Task UpdateSpotStatus(long id, string strNewStatus)
    {
        if (!Enum.TryParse(strNewStatus.ToTitleCase(), out SpotStatus newStatus)) throw new BadRequestException($"{strNewStatus} is not a valid Parking Spot Status");
        
        var spot = await _spotsRepo.GetById(id) ?? throw new NotFoundException($"Parking spot with id: {id} does not exist");

        if (spot.Status.Equals(newStatus)) throw new BadRequestException($"Parking spot is already {strNewStatus.ToLower()}");

        spot.Status = newStatus;
        await _spotsRepo.Update(spot);

    }

    public async Task DeleteSpot(long spotId)
    {
        await _spotsRepo.Delete(spotId);
    }

}
