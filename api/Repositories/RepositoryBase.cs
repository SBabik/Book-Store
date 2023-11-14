using book_store.DBContext;
using Microsoft.EntityFrameworkCore;

namespace book_store.Repositories;

public class RepositoryBase<T> where T : class
{
    private readonly BookContext dbContext;
    protected readonly DbSet<T> table;

    public RepositoryBase(BookContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public async Task<T> Add(T entity)
    {
        await table.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }
}
