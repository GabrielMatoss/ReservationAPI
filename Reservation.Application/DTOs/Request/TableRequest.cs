using Reservation.Domain.Entities;

namespace Reservation.Application.DTOs.Request;

public class TableRequest
{
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsReserved { get; set; }

    public TableRequest(int capacity, int tableNumber)
    {
        Capacity = capacity;
        TableNumber = tableNumber;
        IsReserved = false;
    }

    public static Table ConvertToEntity(TableRequest request)
    {
        return new Table(request.TableNumber, request.Capacity, request.IsReserved);   
    }
}