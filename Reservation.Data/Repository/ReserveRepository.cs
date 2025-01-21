using Reservation.Data.Context;
using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;

namespace Reservation.Data.Repository;

public class ReserveRepository : RepositoryBase<Reserve>, IReserveRepository
{
    public ReserveRepository(DataContext dataContext) : base(dataContext)
    { }
}