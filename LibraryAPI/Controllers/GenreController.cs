using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;
    
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGenres()
    {
        var genres = await _genreService.GetGenresAsync();
        return !genres.Any() ? Ok("No genre was found") : Ok(genres);
    }
    
    [HttpGet("Id")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        try
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            return Ok(genre);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("Name")]
    public IActionResult GetGenreByName(string name)
    {
        try
        {
            var book = _genreService.GetGenreByName(name);
            return Ok(book);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
}