using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Book> Books { get; }

    IRepository<User> Users { get; }

    IRepository<Author> Authors { get; }
    
    IRepository<Genre> Genres { get; }

    Task<bool> SaveChangesAsync();
    
    public void Save();
}