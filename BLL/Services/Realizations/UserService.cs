using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Realizations;

public class UserService : IUserService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private IMapper _rmapper;
    private const int MaxNumberOfBooks = 10;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = new MapperConfiguration(x => x.CreateMap<User, UserDTO>()).CreateMapper();
        _rmapper = new MapperConfiguration(x => x.CreateMap<UserDTO, User>()).CreateMapper();
    }
    
    public async Task<IEnumerable<UserDTO>> GetUsersAsync()
    {
        return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await _unitOfWork.Users.GetAllAsync());
    }

    public IEnumerable<BookDTO> GetUserBooks(int id)
    {
        //var user = _unitOfWork.Users.GetByIdAsync(id).Result;
        var user = _unitOfWork.Users.GetAllAsync().Result.FirstOrDefault(u => u.Id.Equals(id));
        if (user is null)
        {
            throw new ResultException("Cannot find any books for this user");
        }
        var books = user.Books;

        if (books == null)
            throw new ResultException("Cannot find any books for this user");
        
        _mapper = new MapperConfiguration(x => x.CreateMap<Book, BookDTO>()).CreateMapper();

        return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
    }
    
    public IEnumerable<BookDTO> GetUsernameBooks(string username)
    {
        //var user = _unitOfWork.Users.GetByIdAsync(id).Result;
        var user = _unitOfWork.Users.GetAllAsync().Result.FirstOrDefault(u => u.Username.Equals(username));
        if (user is null)
        {
            throw new ResultException("Cannot find any books for this user");
        }
        var books = user.Books;

        /*if (books == null)
            throw new ResultException("Cannot find any books for this user");*/
        
        _mapper = new MapperConfiguration(x => x.CreateMap<Book, BookDTO>()).CreateMapper();

        return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user == null)
            throw new ResultException("No such user exists");

        return _mapper.Map<User, UserDTO>(user);
    }

    public async Task<UserDTO> AddUserAsync(UserDTO userDto)
    {
        var user = _rmapper.Map<UserDTO, User>(userDto);

        await _unitOfWork.Users.AddAsync(user);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this user");

        return _mapper.Map<User, UserDTO>(user);
    }
    public async Task<UserDTO> AddBookNameAsync(string username, int bookId)
    {
        //var user = await _unitOfWork.Users.GetByIdAsync(userId);
        var user =  _unitOfWork.Users.GetAllAsync().Result.FirstOrDefault(u => u.Username.Equals(username));
        
        if (user == null)
            throw new ResultException("No such user exists");
        
        //var book = await _unitOfWork.Books.GetByIdAsync(bookId);
        var book =  _unitOfWork.Books.GetAllAsync().Result.FirstOrDefault(b => b.Id.Equals(bookId));
        
        if (book == null)
            throw new ResultException("No such book exists");
        
        if (book.Quantity == 0)
            throw new ResultException("This book is not available");
        
        if (user.Books.Contains(book))
            throw new ResultException("You already have such book in your list");

        if (user.Books.Count >= MaxNumberOfBooks)
            throw new ResultException($"You cannot add more than {MaxNumberOfBooks} books");
        
        try
        {
            user.Books.Add(book);
            book.Quantity--;
        }
        catch (ResultException)
        {
            throw new ResultException("Cannot add this book to the list");
        }

        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this book to your list");
        //_unitOfWork.Save();
        
        return _mapper.Map<User, UserDTO>(user);
    }
    public async Task<UserDTO> AddBookAsync(int userId, int bookId)
    {
        //var user = await _unitOfWork.Users.GetByIdAsync(userId);
        var user =  _unitOfWork.Users.GetAllAsync().Result.FirstOrDefault(u => u.Id.Equals(userId));
        
        if (user == null)
            throw new ResultException("No such user exists");
        
        //var book = await _unitOfWork.Books.GetByIdAsync(bookId);
        var book =  _unitOfWork.Books.GetAllAsync().Result.FirstOrDefault(b => b.Id.Equals(bookId));
        
        if (book == null)
            throw new ResultException("No such book exists");
        
        if (book.Quantity == 0)
            throw new ResultException("This book is not available");
        
        if (user.Books.Contains(book))
            throw new ResultException("You already have such book in your list");

        if (user.Books.Count >= MaxNumberOfBooks)
            throw new ResultException($"You cannot add more than {MaxNumberOfBooks} books");
        
        try
        {
            user.Books.Add(book);
            book.Quantity--;
        }
        catch (ResultException)
        {
            throw new ResultException("Cannot add this book to the list");
        }

        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this book to your list");
        //_unitOfWork.Save();
        
        return _mapper.Map<User, UserDTO>(user);
    }

    public bool RegisterUser(UserDTO userDto)
    {
        var user = _unitOfWork.Users.GetAll().FirstOrDefault(x => x.Username == userDto.Username);

        if (user is not null)
            throw new ResultException("This user already exists");

        _unitOfWork.Users.AddAsync(_rmapper.Map<UserDTO, User>(userDto));

        /*if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot register this user");*/
        _unitOfWork.Save();

        return true;
    }

    public Task<UserDTO> GetUserByName(string username)
    {
        var user = _unitOfWork.Users.GetAll().FirstOrDefault(u => u.Username.Equals(username));

        if (user == null)
            throw new ResultException("No such user exists");

        return Task.FromResult(_mapper.Map<User, UserDTO>(user));
    }

    public bool LoginUser(string username, string password)
    {
        var user = _unitOfWork.Users.GetAll().FirstOrDefault(x => x.Username == username);
        
        if (user is null)
            throw new ResultException("This user does not exist");

        if (!user.Password.Equals(password))
            throw new ResultException("This password is wrong");
        
        /*if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot login this user");*/
        _unitOfWork.Save();

        return true;
    }

    public void UpdateUser(UserDTO userDto)
    {
        var user = _unitOfWork.Users.GetAll().FirstOrDefault(x => x.Username == userDto.Username);

        if (user == null)
            throw new ResultException("No such user exists");

        user = _rmapper.Map<UserDTO, User>(userDto);

        _unitOfWork.Users.Update(user);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot update this user");
        //_unitOfWork.Save();
    }

    public void RemoveUser(int id)
    {
        var user = _unitOfWork.Users.GetByIdAsync(id).Result;

        if (user == null)
            throw new ResultException("No such user exists");

        _unitOfWork.Users.Remove(user);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot remove this user");
        //_unitOfWork.Save();
    }

    public Task<UserDTO> RemoveUserBook(int userId, int bookId)
    {
        //var user = _unitOfWork.Users.GetByIdAsync(userId).Result;
        var user = _unitOfWork.Users.GetAllAsync().Result.FirstOrDefault(u => u.Id.Equals(userId));
        
        if (user == null)
            throw new ResultException("No such user exists");

        //var book = _unitOfWork.Books.GetByIdAsync(bookId).Result;
        var book = _unitOfWork.Books.GetAllAsync().Result.FirstOrDefault(b => b.Id.Equals(bookId));
        
        if (book == null)
            throw new ResultException("No such book exists");

        if (!user.Books.Contains(book))
            throw new ResultException("You do not have such book in your list");

        try
        {
            user.Books.Remove(book);
            book.Quantity++;
        }
        catch (ResultException)
        {
            throw new ResultException("Cannot remove this book from list");
        }
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this genre");
        
        return Task.FromResult(_mapper.Map<User, UserDTO>(user));
    }
    
    public Task<UserDTO> RemoveUsernameBook(string username, int bookId)
    {
        //var user = _unitOfWork.Users.GetByIdAsync(userId).Result;
        var user = _unitOfWork.Users.GetAllAsync().Result.FirstOrDefault(u => u.Username.Equals(username));
        
        if (user == null)
            throw new ResultException("No such user exists");

        //var book = _unitOfWork.Books.GetByIdAsync(bookId).Result;
        var book = _unitOfWork.Books.GetAllAsync().Result.FirstOrDefault(b => b.Id.Equals(bookId));
        
        if (book == null)
            throw new ResultException("No such book exists");

        if (!user.Books.Contains(book))
            throw new ResultException("You do not have such book in your list");

        try
        {
            user.Books.Remove(book);
            book.Quantity++;
        }
        catch (ResultException)
        {
            throw new ResultException("Cannot remove this book from list");
        }
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this genre");
        
        return Task.FromResult(_mapper.Map<User, UserDTO>(user));
    }
}