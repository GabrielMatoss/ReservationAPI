namespace Reservation.Domain.Entities;

public class Reserve : EntityBase
{
    public DateTime DateTimeReserve { get; set; } = DateTime.Now;
    public int TableNumber { get; set; }
    public int TableId { get; set; }
    public string UserId { get; set; } = null!;
    public List<Guest> Guests { get; set; } = [];

    public Reserve() { }
    public Reserve(DateTime dateTimeReserve, int tableNumber, List<Guest> guests, string userId)
    {
        TableNumber = tableNumber;
        DateTimeReserve = dateTimeReserve;
        Guests = guests;
        UserId = userId;
    }
}