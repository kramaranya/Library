using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return !books.Any() ? Ok("No book was found") : Ok(books);
    }
    
    [HttpGet("Genre")]
    public IActionResult GetBooksByGenreId(int id)
    {
        try
        {
            var books = _bookService.GetBooksByGenreId(id);
            return Ok(books);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("Author")]
    public IActionResult GetBooksByAuthorId(int id)
    {
        try
        {
            var books = _bookService.GetBooksByAuthorId(id);
            return Ok(books);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("Id")]
    public async Task<IActionResult> GetBookById(int id)
    {
        try
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("Name")]
    public IActionResult GetBookByName(string name)
    {
        try
        {
            var book = _bookService.GetBookByName(name);
            return Ok(book);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    /*[HttpGet("Users")]
    public IActionResult GetUsersForBook(int bookId)
    {
        try
        {
            var user = _bookService.GetBookUsers(bookId);
            
            return !user.Any() ? Ok("No users has this book") : Ok(user);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }*/
}