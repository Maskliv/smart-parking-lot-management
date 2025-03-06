using SmartParkingLot.Api.BL;
using SmartParkingLot.Api.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using SmartParkingLot.Api.Domain.Enums;
using SmartParkingLot.Api.Filters;
using Microsoft.Extensions.Primitives;
using SmartParkingLot.Api.Domain.Exceptions;

namespace SmartParkingLot.Api.Controllers;

[ApiController]
[Route("api/parking-spots")]
public class ParkingSpotsController(ParkingSpotsBL _parkingSpotsBl) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? orderBy = null)
    {
        var offset = Tuple.Create(page, pageSize);
        var res = await _parkingSpotsBl.Get(offset:offset, orderBy:orderBy);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _parkingSpotsBl.GetById(id);
        return Ok(res);
    }

    [DeviceAuthorization]
    [HttpPost("{id}/{status}")]
    public async Task<IActionResult> UpdateSpotStatus(long id, string status)
    {
        await _parkingSpotsBl.UpdateSpotStatus(id, status);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AddSpot([FromBody] SpotDto newSpot)
    {
        var spotCreated = await _parkingSpotsBl.AddSpot(newSpot);
        return CreatedAtAction(nameof(GetById), new {id=spotCreated.SpotId}, spotCreated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpot(long id)
    {
        await _parkingSpotsBl.DeleteSpot(id);
        return NoContent();
    }
}
