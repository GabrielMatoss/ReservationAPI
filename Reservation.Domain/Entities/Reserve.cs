namespace Reservation.Domain.Entities;

public class Reserve : EntityBase
{
    public DateTime DateReserve {get; set;} //Data Reserva
    public TimeSpan TimeReserve {get; set;} //Horario Reserva
    public int TableId {get; set;}
    public string UserId {get; set;} = null!;//Aqui é a referencia do Identity
    public List<Guest> Guests {get; set;} = [];
   
    //Acredito que seja bom a gente criar uma tabela de convidados. Para administrar melhor.
    public string Status {get; set;}

    public Reserve()
    {
        DateReserve = DateTime.Now.Date;
        TimeReserve = DateTime.Now.TimeOfDay;
        Status = "Pending";
    }

    public void ConfirmedReserve() => Status = "Confirmed";
    public void CancelReserve() => Status = "Canceled";
}