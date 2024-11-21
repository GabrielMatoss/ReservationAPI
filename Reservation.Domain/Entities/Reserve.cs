namespace Reservation.Domain.Entities;

public class Reserve : EntityBase
{
    public DateTime DateReserve {get; set;} 
    public TimeSpan TimeReserve {get; set;}
    public int TableId {get; set;}
    public string UserId {get; set;} = null!;
    public List<Guest> Guests { get; set; }
   
    public string Status {get; set;}

    public Reserve(DateTime dateReserve, TimeSpan timeReserve, string status = "Pending")
    {
        DateReserve = dateReserve.Date;
        TimeReserve = timeReserve;
        Status = status;
        Guests = new List<Guest>();
    }

    public void ConfirmedReserve() => Status = "Confirmed";
    public void CancelReserve() => Status = "Canceled";
}