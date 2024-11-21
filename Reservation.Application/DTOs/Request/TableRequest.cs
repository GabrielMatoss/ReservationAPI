using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Request;

public class TableRequest
{
    public int Capacity {get; set;}
    
    public int ReservationId {get; set;}

    public TableRequest(int capacity, int reservationId)
    {
        Capacity = capacity;
        ReservationId = reservationId;
    }

    public static Table ConvertToEntity(TableRequest request)
    {
     return new Table(request.Capacity, request.ReservationId);   
    }
}