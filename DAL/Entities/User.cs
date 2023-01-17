namespace DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Username { get; set; } = null!; 
    public string Password { get; set; } = null!; 
    public string PhoneNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public List<Book> Books { get; set; } = new();
}