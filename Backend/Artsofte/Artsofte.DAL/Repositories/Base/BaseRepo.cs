using Artsofte.DAL.Context;
using Artsofte.DAL.Entities.Base;
using Artsofte.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.DAL.Repositories.Base;

public abstract class BaseRepo<T> : IRepo<T> where T : BaseEntity, new()
{
    protected ApplicationDbContext Context { get; }
    public DbSet<T> Table { get; }

    public BaseRepo(ApplicationDbContext context)
    {
        Context = context;
        Table = Context.Set<T>();
    }

    public BaseRepo(DbContextOptions<ApplicationDbContext> options) : this(new ApplicationDbContext(options)) { }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await Table.ToListAsync();

    public virtual async Task<T?> FindAsync(int id) => await Table.FindAsync(id);

    public virtual async Task<T?> FindAsNoTrackingAsync(int id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public virtual async Task<int> AddAsync(T entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> UpdateAsync(T entity, bool persist = true)
    {
        Table.Update(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> DeleteAsync(T entity, bool persist = true)
    {
        Table.Remove(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public async Task<bool> Contains(int id) => await FindAsNoTrackingAsync(id) != null;
    
    public void Dispose()
    {
        Context.Dispose();
    }
}