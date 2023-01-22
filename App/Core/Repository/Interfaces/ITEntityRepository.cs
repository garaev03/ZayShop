using System.Linq.Expressions;

namespace Zay.Core.Repository.Interfaces;

public interface ITEntityRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp);
    Task<TEntity> GetByIdAsync(int id);
    Task Create(TEntity entity);
    //void Update(TEntity entity);
    Task SaveChangesAsync();
}
