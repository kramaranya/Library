using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations;

public class UserRepository : Repository<User>, IRepository<User>
{
    public UserRepository(LibraryContext context) : base(context)
    {
        dbSet = context.Set<User>();
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await dbSet.Include(b => b.Books).ThenInclude(b => b.Author).ToListAsync();
    } 
}