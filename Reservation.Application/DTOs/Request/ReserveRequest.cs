using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Request;

public class ReserveRequest
{
    public DateTime DateTimeReserve { get; set; } = DateTime.Now.Date;
    public int Tableid { get; set; }
    public ReserveRequest(DateTime dateTimeReserve, int tableId)
    {
        DateTimeReserve = dateTimeReserve;
        Tableid = tableId;
    }
    
    public static Reserve ConvertToEntity(ReserveRequest request, string userId)
    {
        return new Reserve(
            request.DateTimeReserve,
            request.Tableid,
            userId
        );
    }
    
}