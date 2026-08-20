using FitTracker.BuildingBlocks.Core.Domain;

namespace FitTracker.BuildingBlocks.Core.UseCases;
public interface ICrudRepository<TEntity> where TEntity : Entity
{
    TEntity? Get(int id);
    List<TEntity> GetMany(List<int> ids);
    PagedResult<TEntity> GetPaged(int page, int pageSize);

    TEntity Create(TEntity entity);
    List<TEntity> CreateMany(List<TEntity> entities);

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);
}

