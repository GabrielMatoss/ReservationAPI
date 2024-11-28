using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Request;

public class ReserveRequest
{
    public DateTime DateReserve { get; set; }
    public TimeSpan TimeReserve { get; set; }
    public int TableId { get; set; }
    //public List<GuestRequest?> Guests { get; set; }

    public ReserveRequest(DateTime dateReserve, TimeSpan timeReserve, int tableId)
    {
        DateReserve = dateReserve.Date;
        TimeReserve = timeReserve;
        TableId = tableId;
    }

    public static Reserve ConvertToEntity(ReserveRequest request)
    {
        return new Reserve(
            request.DateReserve,
            request.TimeReserve,
            request.TableId);
    }
}
