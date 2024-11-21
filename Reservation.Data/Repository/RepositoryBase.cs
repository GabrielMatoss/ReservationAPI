using Microsoft.EntityFrameworkCore;
using Reservation.Data.Context;
using Reservation.Domain.Entities;
using Reservation.Domain.Interfaces.Repository;

namespace Reservation.Data.Repository;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    private readonly DataContext _context;

    public RepositoryBase(DataContext dataContext)
    {
        _context = dataContext;
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
       return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<object> AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public virtual async Task UpdateASync(TEntity entity)
    {
       _context.Entry(entity).State = EntityState.Modified;
       await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
       _context.Set<TEntity>().Remove(entity);
       await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }
        throw new Exception("Registro não encontrado!");
    }
}