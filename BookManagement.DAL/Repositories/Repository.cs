using BookManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repositories;

public class BaseRepository<T> where T : BaseEntity, new()
{
    protected readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<T>> GetValuesAsync()
    {
        var query = _dbContext.Set<T>().AsQueryable();

        return await query.ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        var entry = _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var entry = _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public T Delete(Guid id)
    {
        var entity = new T { Id = id };
        var entry = _dbContext.Set<T>().Remove(entity);
        return entry.Entity;
    }

    public Task SaveChangesAsync(CancellationToken cancellation = default)
    {
        return _dbContext.SaveChangesAsync(cancellation);
    }
}
