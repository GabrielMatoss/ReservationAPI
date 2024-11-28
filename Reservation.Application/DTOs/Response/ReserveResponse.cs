using Reservation.Application.DTOs.Request;
using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Response;

public class ReserveResponse
{
    public DateTime DateReserve { get; set; }
    public TimeSpan TimeReserve { get; set; }
    public int TableNumber { get; set; }
    public IEnumerable<GuestResponse> Guests { get; set; }
    public ReserveResponse(DateTime dateReserve, TimeSpan timeReserve, int tableNumber, IEnumerable<GuestResponse> guests)
    {
        DateReserve = dateReserve;
        TimeReserve = timeReserve;
        TableNumber = tableNumber;
        Guests = guests ?? [];
    }
    public static ReserveResponse ConvertToResponse(Reserve reserve)
    {
        return new ReserveResponse(
            reserve.DateReserve,
            reserve.TimeReserve,
            reserve.TableNumber,
            reserve.Guests.Select(g =>
            new GuestResponse(g?.Name, g?.LastName)));
    }
}
