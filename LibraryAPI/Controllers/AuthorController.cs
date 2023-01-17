using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _authorService.GetAuthorsAsync();
        
        return !authors.Any() ? Ok("No author was found") : Ok(authors);
    }
    
    [HttpGet("Id")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        try
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return Ok(author);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("Name")]
    public IActionResult GetAuthorByName(string name)
    {
        try
        {
            var author = _authorService.GetAuthorByName(name);
            return Ok(author);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
}