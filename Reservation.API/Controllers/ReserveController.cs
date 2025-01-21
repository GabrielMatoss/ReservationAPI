using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Request;
using Reservation.Application.DTOs.Response;
using Reservation.Domain.Interfaces.Services;
using Reservation.Identity.Configurations;
using System.Security.Claims;

namespace Reservation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReserveController : ControllerBase
{
    private readonly IReserveService _reserveService;
    private readonly ITableService _tableService;

    public ReserveController (IReserveService reserveService, ITableService tableService)
    {
        _reserveService = reserveService;
        _tableService = tableService;
    }

    [ProducesResponseType(typeof(ReserveResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = Roles.User)]
    [HttpPost]
    public async Task<ActionResult<ReserveResponse>> RegisterReserve(ReserveRequest reserveRequest)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var table = await _tableService.GetByIdAsync(reserveRequest.Tableid);

        if (table == null)
            return NotFound("Table not found");

        if (table.IsReserved != false)
            return BadRequest("Table is already Reserved, please change your opition");
        
        table.IsReserved = true;

        var reserve = ReserveRequest.ConvertToEntity(reserveRequest, userId);
        
        if (reserve == null)
            return BadRequest("Convert to Entity is not possible");
        
        await _reserveService.AddAsync(reserve);
        return CreatedAtAction(nameof(SelectById), new { reserve.Id }, reserve.Id);
    }

    [ProducesResponseType(typeof(ReserveResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = Roles.Admin)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ReserveResponse>> SelectById(int id)
    {
        var reserve = await _reserveService.GetByIdAsync(id);
        if (reserve == null) 
            NotFound("Reserve not found");
        
        var reserveResponse = ReserveResponse.ConvertToResponse(reserve!);
        return Ok(reserveResponse);
    }

    [ProducesResponseType(typeof(ReserveResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    public async Task<IEnumerable<ReserveResponse>> SelectAllReserves()
    {
        var reserves = await _reserveService.GetAllAsync();
        if (reserves == null)
            throw new Exception("Reserves not found");

        var reservesResponse = reserves.Select(ReserveResponse.ConvertToResponse);
        return reservesResponse;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReserveById(int id)
    {
        var reserve = await _reserveService.GetByIdAsync(id);
        if (reserve == null)
            NotFound("Reserve not found");

        await _reserveService.DeleteAsync(reserve!);
        return Ok("Reserve deleted!");
    }


    [ProducesResponseType(typeof(ReserveResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = Roles.Admin)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ReserveResponse>> UpdateReserve(int id, ReserveRequest reserveRequest)
    {
        var reserve = await _reserveService.GetByIdAsync(id);
        if (reserve == null)
            return NotFound("Reserve not found");

        reserve.DateTimeReserve = reserveRequest.DateTimeReserve;
        reserve.TableId = reserveRequest.Tableid;

        var table = await _tableService.GetByIdAsync(reserveRequest.Tableid);
        if (table == null)
            return BadRequest("Invalid TableId");

        await _reserveService.UpdateAsync(id, reserve);

        return Ok("Reserve updated!");
    }
}
