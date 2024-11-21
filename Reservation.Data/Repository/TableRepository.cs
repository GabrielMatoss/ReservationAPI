
using Reservation.Data.Context;
using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;

namespace Reservation.Data.Repository;

public class TableRepository : RepositoryBase<Table>, ITableRepository
{
    public TableRepository(DataContext dataContext) : base(dataContext)
    {}
}