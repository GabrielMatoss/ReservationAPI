using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Response;

public class TableResponse
{
    public int Capacity {get; set;}
    
    public int ReservationId {get; set;}
    
    public TableResponse(int capacity, int reservationId)
    {
        Capacity = capacity;
        ReservationId = reservationId;
    }

    public static TableResponse ConvertToResponse(Table table)
    {
        return new TableResponse(table.Id, table.Capacity);
    }
}