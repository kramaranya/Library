using BLL.DTOs;

namespace BLL.Services.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDTO>> GetAuthorsAsync();

    Task<AuthorDTO> GetAuthorByIdAsync(int id);
    
    IEnumerable<AuthorDTO> GetAuthorByName(string name);

    Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDto);

    void UpdateAuthor(AuthorDTO authorDto);

    void RemoveAuthor(int id);
}