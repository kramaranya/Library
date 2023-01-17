using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Realizations;

namespace DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private LibraryContext _db;
    public IRepository<Book> Books { get; }
    public IRepository<User> Users { get; }
    public IRepository<Author> Authors { get; }
    public IRepository<Genre> Genres { get; }
    
    public UnitOfWork(LibraryContext db)
    {
        _db = db;
        Books = new BookRepository(_db);
        Users = new UserRepository(_db);
        Authors = new AuthorRepository(_db);
        Genres = new GenreRepository(_db);
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return (await _db.SaveChangesAsync() > 0);
    }
    public void Save()
    {
        _db.SaveChanges();
    }

    private bool _disposed;
    
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}