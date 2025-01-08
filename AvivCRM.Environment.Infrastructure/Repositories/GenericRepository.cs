//using Microsoft.EntityFrameworkCore;

#region

using AvivCRM.Environment.Domain.Entities.Common;
using AvivCRM.Environment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories;
public abstract class GenericRepository<TEntity>(EnvironmentDbContext _context, DbSet<TEntity> _dbSet)
    where TEntity : class, IEntity
{
    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        // Check if the entity is already being tracked
        var trackedEntity = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);

        if (trackedEntity != null)
        {
            // Detach the tracked entity to avoid conflicts
            _context.Entry(trackedEntity).State = EntityState.Detached;
        }

        // Attach the new entity and mark it as modified
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<bool> IsAvailableByNameAsync(string name)
    {
        var item = await _context.Set<TEntity>().FirstOrDefaultAsync(x => EF.Property<string>(x, "Name") == name);
        return item != null;
    }
}