using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations;

public class BookRepository : Repository<Book>, IRepository<Book>
{
    public BookRepository(LibraryContext context) : base(context)
    {
        dbSet = context.Set<Book>();
    }
    
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await dbSet.Include(b => b.Users).Include(b => b.Author).ToListAsync();
    } 
}