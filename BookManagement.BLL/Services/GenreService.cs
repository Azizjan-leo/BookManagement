using AutoMapper;
using BookManagement.DAL.Repositories;
using BookManagement.Model.Entities;
using BookManagement.Model;
using BookManagement.BLL.Services.Interfaces;

namespace BookManagement.BLL.Services;
public sealed class GenreService(GenreRepository _genreRepository, IMapper _mapper) 
    : IGenreService
{
    public async Task<OperationResult> AddGenreAsync(GenreModel genreModel)
    {
        var genre = _mapper.Map<Genre>(genreModel);

        await _genreRepository.CreateAsync(genre);

        var result = new OperationResult
        {
            IsSucceed = true,
            Message = "New genre has been added.",
            Value = _mapper.Map<GenreModel>(genre)
        };
        
        return result;
    }

    public async Task<OperationResult> DeleteGenreAsync(Guid id)
    {
        var author = await _genreRepository.DeleteAsync(id);

        return new OperationResult { IsSucceed = true, Message = "The genre has been removed" };
    }

    public async Task<List<GenreModel>> GetAllGenresAsync()
    {
        var authors = await _genreRepository.GetValuesAsync();

        var models = _mapper.Map<List<GenreModel>>(authors);

        return models;
    }

    public async Task<GenreModel?> GetGenreByIdAsync(Guid id)
    {
        var genre = await _genreRepository.GetAsync(id);

        var genreModel = _mapper.Map<GenreModel>(genre);

        return genreModel;
    }

    public async Task<OperationResult> UpdateGenreAsync(GenreModel genreModel)
    {
        var genre = _mapper.Map<Genre>(genreModel);

        await _genreRepository.UpdateAsync(genre);

        genreModel = _mapper.Map<GenreModel>(genre);

        var result = new OperationResult 
        { 
            IsSucceed = true, 
            Value = genreModel,  
            Message = "Author has been updated"
        }; 

        return result;
    }
}
