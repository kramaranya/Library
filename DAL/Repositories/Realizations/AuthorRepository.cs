using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Realizations;

public class AuthorRepository : Repository<Author>, IRepository<Author>
{
    public AuthorRepository(LibraryContext context) : base(context)
    {
    }
}