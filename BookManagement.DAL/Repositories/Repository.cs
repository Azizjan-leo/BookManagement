using BookManagement.Model.Entities;

namespace BookManagement.DAL.Repositories;

public class BaseRepository<T> where T : BaseEntity, new()
{
    protected readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public T Create(T entity)
    {
        var entry = _dbContext.Set<T>().Add(entity);
        return entry.Entity;
    }

    public T Update(Action<T> updater)
    {
        var entity = new T();
        updater(entity);
        var entry = _dbContext.Set<T>().Update(entity);
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
