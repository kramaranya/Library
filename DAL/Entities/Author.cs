namespace DAL.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public List<Book> Books { get; set; } = new();
}