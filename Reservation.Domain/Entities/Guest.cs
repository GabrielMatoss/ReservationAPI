namespace Reservation.Domain.Entities;

public class Guest
{
    public string? Name { get; set; } 
    public string? LastName { get; set; }
    public Reserve Reserve { get; set; } = null!;
    public int ReservationId { get; set; } 
    public string UserId { get; set; } = null!;
}