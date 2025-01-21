
using Reservation.Data.Context;
using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;

namespace Reservation.Data.Repository;

public class TableRepository : RepositoryBase<Table>, ITableRepository
{
    public TableRepository(DataContext dataContext) : base(dataContext)
    {}
    /*
    //funciona pq meu GetByIdAsync � um numero
    public async Task<Table?> GetTableByNumberAsync(int tableNumber)
    {
        return await base.GetByIdAsync(tableNumber);
    }
    */
    /*
    //Eu não preciso disso pelo fato de que o GetByIdAsync já faz isso
    public async Task<Table?> GetTableByNumberAsync(int tableNumber)
    {
        return await base.GetByIdAsync(tableNumber);
    }
    */
}