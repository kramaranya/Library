using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Realizations;

public class GenreRepository : Repository<Genre>, IRepository<Genre>
{
    public GenreRepository(LibraryContext context) : base(context)
    {
    }
}