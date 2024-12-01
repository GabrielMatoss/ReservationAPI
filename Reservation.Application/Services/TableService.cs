using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;
using Reservation.Domain.Interfaces.Services;

namespace Reservation.Application.Services;

public class TableService : ServiceBase<Table>, ITableService
{
    public TableService(IRepositoryBase<Table> repositoryBase) : base(repositoryBase)
    { }
}