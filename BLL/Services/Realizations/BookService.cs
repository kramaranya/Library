using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Realizations;

public class BookService : IBookService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private IMapper _rmapper;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = new MapperConfiguration(x => x.CreateMap<Book, BookDTO>()).CreateMapper();
        _rmapper = new MapperConfiguration(x => x.CreateMap<BookDTO, Book>()).CreateMapper();
    }


    public IEnumerable<BookDTO> GetBooksByGenreId(int genreId)
    {
        var book = _unitOfWork.Books.GetAll().Where(x => x.GenreId == genreId);

        if (book == null)
            throw new ResultException("No such book exist with this genre");

        return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(book);
    }

    public IEnumerable<BookDTO> GetBooksByAuthorId(int authorId)
    {
        var book = _unitOfWork.Books.GetAll().Where(x => x.AuthorId == authorId);

        if (book == null)
            throw new ResultException("Db query result to books is null");

        return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(book);
    }

    public IEnumerable<UserDTO> GetBookUsers(int bookId)
    {
        var book = _unitOfWork.Books.GetByIdAsync(bookId).Result;
        var users = book.Users;

        if (users == null)
            throw new ResultException("Cannot find any users for this book");

        return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
    }
    
    public IEnumerable<BookDTO> GetBookByName(string name)
    {
        var book = _unitOfWork.Books.GetAll().Where(x => x.Title.Contains(name));

        if (book == null)
            throw new ResultException("No such book exists");

        return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(book);
    }

    public async Task<IEnumerable<BookDTO>> GetBooksAsync()
    {
        return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(await _unitOfWork.Books.GetAllAsync());
    }

    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);

        if (book == null)
            throw new ResultException("No such book exists");

        return _mapper.Map<Book, BookDTO>(book);
    }

    public async Task<BookDTO> AddBookAsync(BookDTO bookDto)
    {
        var book = _rmapper.Map<BookDTO, Book>(bookDto);

        await _unitOfWork.Books.AddAsync(book);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this book");

        return _mapper.Map<Book, BookDTO>(book);
    }

    public void UpdateBook(BookDTO bookDto)
    {
        var book = _unitOfWork.Books.GetByIdAsync(bookDto.Id).Result;

        if (book == null)
            throw new ResultException("No such book exists");

        book = _rmapper.Map<BookDTO, Book>(bookDto);
            
        _unitOfWork.Books.Update(book);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot update this book");
    }

    public void RemoveBook(int id)
    {
        var book = _unitOfWork.Books.GetByIdAsync(id).Result;

        if (book == null)
            throw new ResultException("No such book exists");

        _unitOfWork.Books.Remove(book);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot remove this book");
    }
}