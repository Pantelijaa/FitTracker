using Microsoft.EntityFrameworkCore;
using FitTracker.BuildingBlocks.Core.Domain;
using FitTracker.BuildingBlocks.Core.UseCases;

namespace FitTracker.BuildingBlocks.Infrastrucutre.Database;

public class CrudDatabaseRepository<TEntity, TDbContext> : ICrudRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
{
    protected readonly TDbContext DbContext;
    private readonly DbSet<TEntity> _dbSet;

    public CrudDatabaseRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
        _dbSet = DbContext.Set<TEntity>();
    }

    public TEntity? Get(int id)
    {
        return _dbSet.Find(id);
    }

    public List<TEntity> GetMany(List<int> ids)
    {
        return _dbSet.Where(e => ids.Contains(e.Id)).ToList();
    }

    public PagedResult<TEntity> GetPaged(int page, int pageSize)
    {
        var task = _dbSet.GetPagedById(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public TEntity Create(TEntity entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public List<TEntity> CreateMany(List<TEntity> entities)
    {
        _dbSet.AddRange(entities);
        return entities;
    }

    public TEntity Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public TEntity UpdateWithAssociatedEntities(TEntity entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        DbContext.SaveChanges();
        return entity;
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}
