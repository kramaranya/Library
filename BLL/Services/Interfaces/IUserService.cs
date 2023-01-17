using BLL.DTOs;

namespace BLL.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetUsersAsync();
    
    IEnumerable<BookDTO> GetUserBooks(int id);
    
    IEnumerable<BookDTO> GetUsernameBooks(string username);

    Task<UserDTO> GetUserByIdAsync(int id);

    Task<UserDTO> AddUserAsync(UserDTO userDto);
    
    Task<UserDTO> AddBookAsync(int userId, int bookId);
    
    Task<UserDTO> AddBookNameAsync(string username, int bookId);
    
    public bool RegisterUser(UserDTO userDto);
    
    public bool LoginUser(string username, string password);

    void UpdateUser(UserDTO userDto);

    void RemoveUser(int id);
    
    Task<UserDTO> RemoveUserBook(int userId, int bookId);
    
    Task<UserDTO> RemoveUsernameBook(string username, int bookId);
    
    Task<UserDTO> GetUserByName(string username);
}