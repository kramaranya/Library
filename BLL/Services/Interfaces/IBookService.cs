using BLL.DTOs;

namespace BLL.Services.Interfaces;

public interface IBookService
{
    IEnumerable<BookDTO> GetBooksByGenreId(int genreId);

    IEnumerable<BookDTO> GetBooksByAuthorId(int authorId);
    
    IEnumerable<UserDTO> GetBookUsers(int bookId);
    
    Task<IEnumerable<BookDTO>> GetBooksAsync();

    Task<BookDTO> GetBookByIdAsync(int id);
    
    IEnumerable<BookDTO> GetBookByName(string name);

    Task<BookDTO> AddBookAsync(BookDTO bookDto);

    void UpdateBook(BookDTO bookDto);

    void RemoveBook(int id);
}