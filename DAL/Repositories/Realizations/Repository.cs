using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations;

public class Repository<T> : IRepository<T> where T : class
{
    internal protected LibraryContext context;
    internal protected DbSet<T> dbSet;
    
    public Repository(LibraryContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }
    
    public IEnumerable<T> GetAll()
    {
        return dbSet.ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }
    
    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Remove(T entity)
    {
        if (context.Entry(entity).State == EntityState.Detached)
        {
            dbSet.Attach(entity);
        }

        dbSet.Remove(entity);
    }

    public void Remove(int id)
    {
        T entity = dbSet.Find(id);
        if (entity != null) Remove(entity);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }
}