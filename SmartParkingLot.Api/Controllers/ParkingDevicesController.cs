using Microsoft.AspNetCore.Mvc;
using SmartParkingLot.Api.BL;
using SmartParkingLot.Api.Domain.Dto;

namespace SmartParkingLot.Api.Controllers;

[ApiController]
[Route("api/parking-devices")]
public class ParkingDevicesController(ParkingDevicesBL _parkingDevicesBl) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? orderBy = null)
    {
        var offset = Tuple.Create(page, pageSize);
        var res = await _parkingDevicesBl.Get(offset:offset, orderBy:orderBy);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var res = await _parkingDevicesBl.GetById(id);
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddDevice([FromBody] DeviceDto newDevice)
    {
        var deviceCreated = await _parkingDevicesBl.AddDevice(newDevice);
        return CreatedAtAction(nameof(GetById), new {id=deviceCreated.DeviceId}, deviceCreated);
    }
}
