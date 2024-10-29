using Microsoft.AspNetCore.Mvc;
using Reservation.Data.Context;
using Reservation.Domain.Entities;

namespace Reservation.API.Controllers;
[ApiController]
[Route("api/tables")]
public class TableController : ControllerBase
{
    private readonly DataContext _context;
    public TableController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult SelectAllTables()
    {
        return Ok("Funcionou!!");
    }

    [HttpPost]
    public IActionResult CreateTable(int number)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult ReserveCreation(DateTime dateReserve, TimeSpan timeReserve, IEnumerable<Guest>? guests = null)
    {
        return Ok("Sei la mano");
    }
}
