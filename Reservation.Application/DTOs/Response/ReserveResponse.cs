using Reservation.Application.DTOs.Request;
using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Response;

public class ReserveResponse
{
    public DateTime DateReserve { get; set; }
    public TimeSpan TimeReserve { get; set; }
    public int TableId { get; set; }
    public IEnumerable<GuestResponse> Guests { get; set; }
    public ReserveResponse(DateTime dateReserve, TimeSpan timeReserve, int tableId, IEnumerable<GuestResponse> guests)
    {
        DateReserve = dateReserve;
        TimeReserve = timeReserve;
        TableId = tableId;
        Guests = guests ?? [];
    }
    public static ReserveResponse ConvertToResponse(Reserve reserve)
    {
        return new ReserveResponse(
            reserve.DateReserve,
            reserve.TimeReserve,
            reserve.TableId,
            reserve.Guests.Select(g =>
            new GuestResponse(g?.Name, g?.LastName, g!.ReservationId)));
    }
}
