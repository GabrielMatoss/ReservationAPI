using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;
using Reservation.Domain.Interfaces.Services;

namespace Reservation.Domain.Services;

public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
{
    private readonly IRepositoryBase<TEntity> _repositoryBase;

    protected ServiceBase(IRepositoryBase<TEntity> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _repositoryBase.GetAllAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _repositoryBase.GetByIdAsync(id);
    }

    public async Task<object> AddAsync(TEntity entity)
    {
        return await _repositoryBase.AddAsync(entity);
    }

    public async Task UpdateASync(TEntity entity)
    {
      await _repositoryBase.UpdateASync(entity);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await _repositoryBase.DeleteAsync(entity);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repositoryBase.DeleteByIdAsync(id);
    }
}