using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Realizations;

public class GenreService : IGenreService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private IMapper _rmapper;

    public GenreService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = new MapperConfiguration(x => x.CreateMap<Genre, GenreDTO>()).CreateMapper();
        _rmapper = new MapperConfiguration(x => x.CreateMap<GenreDTO, Genre>()).CreateMapper();
    }
    
    public async Task<IEnumerable<GenreDTO>> GetGenresAsync()
    {
        return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(await _unitOfWork.Genres.GetAllAsync());
    }

    public async Task<GenreDTO> GetGenreByIdAsync(int id)
    {
        var genre = await _unitOfWork.Genres.GetByIdAsync(id);

        if (genre == null)
            throw new ResultException("No such genre exists");

        return _mapper.Map<Genre, GenreDTO>(genre);
    }

    public async Task<GenreDTO> AddGenreAsync(GenreDTO genreDto)
    {
        var genre = _rmapper.Map<GenreDTO, Genre>(genreDto);

        await _unitOfWork.Genres.AddAsync(genre);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot add this genre");

        return _mapper.Map<Genre, GenreDTO>(genre);
    }

    public void UpdateGenre(GenreDTO genreDto)
    {
        var genre = _unitOfWork.Genres.GetByIdAsync(genreDto.Id).Result;

        if (genre == null)
            throw new ResultException("No such genre exists");

        genre = _rmapper.Map<GenreDTO, Genre>(genreDto);

        _unitOfWork.Genres.Update(genre);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot update this genre");
    }
    
    public IEnumerable<GenreDTO> GetGenreByName(string name)
    {
        var genre = _unitOfWork.Genres.GetAll().Where(x => x.Name.Contains(name));

        if (genre == null)
            throw new ResultException("No such genre exists");

        return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(genre);
    }

    public void RemoveGenre(int id)
    {
        var genre = _unitOfWork.Genres.GetByIdAsync(id).Result;

        if (genre == null)
            throw new ResultException("No such genre exists");

        _unitOfWork.Genres.Remove(genre);
        
        if (!_unitOfWork.SaveChangesAsync().Result)
            throw new ResultException("Cannot remove this genre");
    }
}