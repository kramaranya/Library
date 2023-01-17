using BLL.DTOs;
using BLL.Services.Interfaces;
using AutoMapper;
using BLL.Exceptions;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Realizations;

public class AuthorService : IAuthorService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private IMapper _rmapper;

    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = new MapperConfiguration(x => x.CreateMap<Author, AuthorDTO>()).CreateMapper();
        _rmapper = new MapperConfiguration(x => x.CreateMap<AuthorDTO, Author>()).CreateMapper();
    }

    public async Task<IEnumerable<AuthorDTO>> GetAuthorsAsync()
    {
        return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(await _unitOfWork.Authors.GetAllAsync());
    }

    public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);

        if (author == null)
            throw new ResultException("No such author exists");

        return _mapper.Map<Author, AuthorDTO>(author);
    }
    
    public IEnumerable<AuthorDTO> GetAuthorByName(string name)
    {
        var author = _unitOfWork.Authors.GetAll().Where(x => x.Name.Contains(name) || x.Surname.Contains(name));

        if (author == null)
            throw new ResultException("No such author exists");

        return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(author);
    }

    public async Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDto)
    {
        var author = _rmapper.Map<AuthorDTO, Author>(authorDto);

        await _unitOfWork.Authors.AddAsync(author);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this author");

        return _mapper.Map<Author, AuthorDTO>(author);
    }

    public void UpdateAuthor(AuthorDTO authorDto)
    {
        var author = _unitOfWork.Authors.GetByIdAsync(authorDto.Id).Result;

        if (author == null)
            throw new ResultException("No such author exists");

        author = _rmapper.Map<AuthorDTO, Author>(authorDto);
            
        _unitOfWork.Authors.Update(author);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot update this author");
    }

    public void RemoveAuthor(int id)
    {
        var author = _unitOfWork.Authors.GetByIdAsync(id).Result;

        if (author == null)
            throw new ResultException("No such author exists");

        _unitOfWork.Authors.Remove(author);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot remove this author");
    }
}