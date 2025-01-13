using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Request;
using Reservation.Application.DTOs.Response;
using Reservation.Domain.Interfaces.Services;
using Reservation.Identity.Configurations;

namespace Reservation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;
    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }
    
    [Authorize]
    [ProducesResponseType(typeof(IEnumerable<TableResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableResponse>>> SelectAllTables()
    {
        var tables = await _tableService.GetAllAsync();
        var tablesResponse = tables?.Select(TableResponse.ConvertToResponse);

        if (tablesResponse == null)
            return NotFound();
        
        return Ok(tablesResponse);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<TableResponse>> SelectById(int id)
    {
        var table = await _tableService.GetByIdAsync(id);
        if (table == null) 
            NotFound("Table not found");
        
        var tableResponse = TableResponse.ConvertToResponse(table!);
        return Ok(tableResponse);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost]
    public async Task<ActionResult<TableResponse>> AddNewTable(TableRequest tableRequest)
    {
        var table = TableRequest.ConvertToEntity(tableRequest);

        if (table == null)
            return BadRequest("Convert to Entity is not possible");

        var id = (int)await _tableService.AddAsync(table);

        return CreatedAtAction(nameof(SelectById), new { id }, id);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTableById(int id)
    {
        var table = await _tableService.GetByIdAsync(id);
        if (table == null)
            NotFound("Table not found");

        await _tableService.DeleteByIdAsync(id);

        return Ok("Table deleted!");
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut]
    public async Task<ActionResult> UpdateTable(int id, TableRequest tableRequest)
    {
        var trackedTable = await _tableService.GetByIdAsync(id);

        if (trackedTable == null)
            NotFound("Table not founded");
        
        var table = TableRequest.ConvertToEntity(tableRequest);
        
        trackedTable!.TableNumber = table.TableNumber;
        trackedTable.Reserves = table.Reserves;
        trackedTable.Capacity = table.Capacity;

        await _tableService.UpdateAsync(id, trackedTable);

        return Ok("Table updated!");
    }
}
