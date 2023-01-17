using DAL;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();

var options = optionsBuilder
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=True;")
    .Options;


using (LibraryContext db = new LibraryContext(options))
{
    Author william = new Author { Name = "William", Surname = "Shakespeare" };
    Author aganta = new Author { Name = "Agatha", Surname = "Christie" };
    db.Authors.Add(william);
    db.Authors.Add(aganta);
    db.SaveChanges();
    Console.WriteLine("\nДанные после редактирования:");
    var users = db.Authors.ToList();
    foreach (Author u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Id}");
    }
    var genres = db.Genres.ToList();
    foreach (Genre u in genres)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Id}");
    }
}