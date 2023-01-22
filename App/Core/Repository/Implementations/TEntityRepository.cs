using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Zay.Core.Repository.Interfaces;
using Zay.DAL;

namespace Zay.Core.Repository.Implementations;

public class TEntityRepository<TEntity> : ITEntityRepository<TEntity>
    where TEntity : class, new()
{
    private readonly AppDbContext _db;
    public TEntityRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp)
    => await _db.Set<TEntity>().Where(exp).ToListAsync();

    public async Task<TEntity> GetByIdAsync(int id)
    => await _db.Set<TEntity>().FindAsync(id);

    public async Task Create(TEntity entity)
    {
        await _db.Set<TEntity>().AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}
