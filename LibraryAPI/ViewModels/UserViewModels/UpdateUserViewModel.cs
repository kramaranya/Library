namespace LibraryAPI.ViewModels.UserViewModels;

public class UpdateUserViewModel
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
}