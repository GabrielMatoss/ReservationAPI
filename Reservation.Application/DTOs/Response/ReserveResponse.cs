using Reservation.Application.DTOs.Request;
using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Response;

public class ReserveResponse
{
    public DateTime DateTimeReserve { get; set; }
    public int TableId { get; set; }
    public ReserveResponse(DateTime dateTimeReserve, int tableId)
    {
        DateTimeReserve = dateTimeReserve;
        TableId = tableId;
    }
    public static ReserveResponse ConvertToResponse(Reserve reserve)
    {
        return new ReserveResponse(
            reserve.DateTimeReserve,
            reserve.TableId
        );
    }
}
