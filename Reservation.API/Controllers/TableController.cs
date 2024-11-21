using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Response;
using Reservation.Domain.Interfaces.Repository;

namespace Reservation.API.Controllers;
[ApiController]
[Route("api/tables")]
public class TableController : ControllerBase
{
    private readonly ITableRepository _tableRepository; 
    public TableController(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }
    
    [ProducesResponseType(typeof(IEnumerable<TableResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableResponse>>> SelectAllTables()
    {
        var tables = await _tableRepository.GetAllAsync();
        var tablesResponse = tables?.Select(TableResponse.ConvertToResponse);

        if (tablesResponse == null)
        {
            return NotFound();
        }
        return Ok(tablesResponse);
    }
}
