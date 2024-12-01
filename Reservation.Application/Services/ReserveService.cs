using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;
using Reservation.Domain.Interfaces.Services;

namespace Reservation.Application.Services;

public class ReserveService : ServiceBase<Reserve>, IReserveService
{
    public ReserveService(IRepositoryBase<Reserve> repositoryBase) : base(repositoryBase)
    { }
}