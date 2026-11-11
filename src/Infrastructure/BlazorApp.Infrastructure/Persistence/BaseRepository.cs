namespace BlazorApp.Infrastructure.Persistence;

/// <summary>
/// Base repository class for data access
/// </summary>
/// <typeparam name="TEntity">The entity type</typeparam>
public abstract class BaseRepository<TEntity> where TEntity : class
{
    protected readonly IServiceProvider ServiceProvider;

    protected BaseRepository(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public virtual Task<TEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public virtual Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
