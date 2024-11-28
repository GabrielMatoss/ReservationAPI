using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Response;

public class TableResponse
{
    public int Capacity {get; set;}
    public bool IsReserved { get; set; }
    public int TableNumber { get; set; }

    public TableResponse(int tableNumber, bool isReserved, int capacity = 2)
    {
        Capacity = capacity;
        TableNumber = tableNumber;
        IsReserved = isReserved;
    }

    public static TableResponse ConvertToResponse(Table table)
    {
        return new TableResponse(table.TableNumber, table.IsReserved, table.Capacity);
    }
}