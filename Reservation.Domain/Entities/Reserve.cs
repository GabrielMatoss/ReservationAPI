namespace Reservation.Domain.Entities;

public class Reserve : EntityBase
{
    public DateTime DateTimeReserve { get; set; } = DateTime.Now;
    public int TableId { get; set; }
    public string UserId { get; set; } = null!;
    public Reserve() { }
    public Reserve(DateTime dateReserve, int tableId, string userId)
    {
        DateTimeReserve = dateReserve;
        TableId = tableId;
        UserId = userId;
    }
}