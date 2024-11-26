using Reservation.Application.DTOs.Request;
using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Response;

public class GuestResponse
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int ReservationId { get; set; }

    public GuestResponse(string? name, string? lastname, int reservationId = 0)
    {
        Name = name;
        LastName = lastname;
        ReservationId = reservationId;
    }
    public static GuestResponse ConvertToEntity(Guest guest)
    {
        return new GuestResponse(guest.Name, guest.LastName, guest.ReservationId);
    }
}
