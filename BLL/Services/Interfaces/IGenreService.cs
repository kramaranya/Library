using BLL.DTOs;

namespace BLL.Services.Interfaces;

public interface IGenreService
{
    Task<IEnumerable<GenreDTO>> GetGenresAsync();

    Task<GenreDTO> GetGenreByIdAsync(int id);
    
    IEnumerable<GenreDTO> GetGenreByName(string name);

    Task<GenreDTO> AddGenreAsync(GenreDTO genreDto);

    void UpdateGenre(GenreDTO genreDto);

    void RemoveGenre(int id);
}