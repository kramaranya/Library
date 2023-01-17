namespace DAL.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime PublicationDate { get; set; }
    public  int Quantity { get; set; }
    
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public int? GenreId { get; set; }
    public Genre? Genre { get; set; }
    
    public List<User> Users { get; set; } = new();
}