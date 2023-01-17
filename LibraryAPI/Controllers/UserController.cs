using BLL.Exceptions;
using BLL.Services.Interfaces;
using LibraryAPI.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BLL.DTOs;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var user = await _userService.GetUsersAsync();
        return !user.Any() ? Ok("No book was found") : Ok(user);
    }
    
    [HttpPost("Login")]
    [ProducesResponseType(201)]
    public IActionResult Login([FromForm] LoginUserViewModel user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            return BadRequest("Cannot login because of empty fields");

        try
        {
            _userService.LoginUser(user.Username, user.Password);   
        }
        catch (ResultException exception)
        {
            return BadRequest(exception.Message);
        }

        return Ok(user);
    }
    
    [HttpPost("Register")]
    [ProducesResponseType(201)]
    public IActionResult Register([FromForm] UpdateUserViewModel user)
    {
        if (string.IsNullOrEmpty(user.Name) 
            || string.IsNullOrEmpty(user.Surname)
            || string.IsNullOrEmpty(user.Username) 
            || string.IsNullOrEmpty(user.Password)
            || string.IsNullOrEmpty(user.PhoneNumber))
            return BadRequest("Cannot register because of empty fields");

        var mapper = new MapperConfiguration(
            x => x.CreateMap<UpdateUserViewModel, UserDTO>()).CreateMapper();

        try
        {
            _userService.RegisterUser(mapper.Map<UpdateUserViewModel, UserDTO>(user));   
        }
        catch (ResultException exception)
        {
            return BadRequest(exception.Message);
        }

        return Ok(user);
    }
    
    [HttpGet("Info")]
    public async Task<IActionResult> GetUserById(string username)
    {
        try
        {
            var user = await _userService.GetUserByName(username);
            return Ok(user);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("Books")]
    public IActionResult GetUsersBooks(string username)
    {
        try
        {
            var books = _userService.GetUsernameBooks(username);
            return !books.Any() ? Ok("This user has no book") : Ok(books);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut()]
    [ProducesResponseType(204)]
    public IActionResult Update([FromForm] UpdateUserViewModel user)
    {
        if (string.IsNullOrEmpty(user.Name) 
            || string.IsNullOrEmpty(user.Surname)
            || string.IsNullOrEmpty(user.Username) 
            || string.IsNullOrEmpty(user.Password)
            || string.IsNullOrEmpty(user.PhoneNumber))
            return BadRequest("Cannot update because of empty fields");
        
        var mapper = new MapperConfiguration(
            x => x.CreateMap<UpdateUserViewModel, UserDTO>()).CreateMapper();
        
        try
        {
            _userService.UpdateUser(mapper.Map<UpdateUserViewModel, UserDTO>(user));   
        }
        catch (ResultException exception)
        {
            return BadRequest(exception.Message);
        }

        return Ok(user);
    }
    
    [HttpPut("Book")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> AddBookToUser(string username, int bookId)
    {
        try
        {
            var user = await _userService.AddBookNameAsync(username, bookId);
            return Ok(user);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete()]
    [ProducesResponseType(204)]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            _userService.RemoveUser(id);
            return NoContent();
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("Book")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> DeleteUsernameBook(string username, int bookId)
    {
        try
        {
            var user = await _userService.RemoveUsernameBook(username, bookId);
            return Ok(user);
        }
        catch (ResultException e)
        {
            return NotFound(e.Message);
        }
    }
}