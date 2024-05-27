using AutoMapper;
using DS.DriveShare.Domain.Models;
using DS.DriveShare.Domain.Services;
using DS.DriveShare.Domain.Services.Communication;
using DS.DriveShare.Resources;
using DS.Share.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DS.DriveShare.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ParkingControllers:ControllerBase
{
    private readonly IParkingService _parkingService;
    private readonly IMapper _mapper;

    public ParkingControllers(IParkingService parkingService, IMapper mapper)
    {
        _parkingService = parkingService;
        _mapper = mapper;
    }
    
    /// <summary>
    ///  Get all Parkings 
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<ParkingResource>> GetAllAsync()
    {
        var parking = await _parkingService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Parking>, IEnumerable<ParkingResource>>(parking);

        return resources;
    }
    // POST: api/Parking
    /// <summary>
    /// Create a new Parking.
    /// </summary>
    /// <response code="200">Returns newly created Parking.</response>
    /// <response code="400">If the Parking is null or the required fields are empty</response>
    /// <response code="500">Unexpected error, maybe database is down</response>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveParkingResource  resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var parking = _mapper.Map<SaveParkingResource, Parking>(resource);

        var results = await _parkingService.SaveAsync(parking);

        if (!results.Success)
        {
            return BadRequest(results.Message);
        }

        var parkingResource = _mapper.Map<Parking, ParkingResource>(results.Resource);

        return Ok(parkingResource);
    }
    /// <summary>
    ///  Put Parking with id
    /// </summary>
    
    [HttpPut("{parkingId}")]
    public async Task<ActionResult<ParkingResponse>> UpdateParkingTask(int parkingId,
        [FromBody] SaveParkingResource parking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var parkings = _mapper.Map<SaveParkingResource, Parking>(parking);
        var result = await _parkingService.UpdateAsync(parkingId, parkings);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var parkingResource = _mapper.Map<Parking, ParkingResource>(result.Resource);

        return Ok(parkingResource);
    }
    
    /// <summary>
    ///  Delete all Category with id 
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _parkingService.DeleteAsync(id);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var parkingResource = _mapper.Map<Parking, ParkingResource>(result.Resource);

        return Ok(parkingResource);
    }

    
}