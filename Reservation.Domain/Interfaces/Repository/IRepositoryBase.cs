using Reservation.Domain.Entities;

namespace Reservation.Domain.Interfaces.Repository;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<object> AddAsync(TEntity entity);
    Task UpdateASync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteByIdAsync(int id);
}