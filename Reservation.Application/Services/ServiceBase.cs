using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;
using Reservation.Domain.Interfaces.Services;

public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
{
    private readonly IRepositoryBase<TEntity> _repositoryBase;

    protected ServiceBase(IRepositoryBase<TEntity> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _repositoryBase.GetAllAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _repositoryBase.GetByIdAsync(id);
    }

    public virtual async Task<object> AddAsync(TEntity entity)
    {
        return await _repositoryBase.AddAsync(entity);
    }

    public virtual async Task UpdateAsync(int id, TEntity entity)
    {
        await _repositoryBase.UpdateAsync(id, entity);
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        await _repositoryBase.DeleteAsync(entity);
    }

    public virtual async Task DeleteByIdAsync(int id)
    {
        await _repositoryBase.DeleteByIdAsync(id);
    }
}