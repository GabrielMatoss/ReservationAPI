namespace Reservation.Domain.Entities;

public class Table : EntityBase
{
    public int Number {get; set;}
    public IEnumerable<Reserve> Reserves {get; set;} //propriedade de navegação
    public int ReservationId {get; set;}
    public int Capacity {get; set;}
    
    public Table()
    {
        Reserves = new List<Reserve>();
        Capacity = 2;
    }

    // Verifica se é possível reservar na data e hora solicitada
    public bool CanReserve(DateTime requestedDateTime)
    {
        // Verificar a janela de 2 meses a partir de hoje
        var twoMonthsFromNow = DateTime.Now.AddMonths(2);
        if (requestedDateTime > twoMonthsFromNow || requestedDateTime < DateTime.Now)
        {
            return false;
        }

        // Verificar se o horário está entre 12:00 e 22:00
        if (requestedDateTime.Hour is < 12 or > 22)
        {
            return false;
        }

        // Verificar se a mesa já está reservada no horário solicitado
        return !Reserves.Any(e => e.DateReserve == requestedDateTime.Date 
                                  && e.DateReserve.TimeOfDay == requestedDateTime.TimeOfDay);
    }
}