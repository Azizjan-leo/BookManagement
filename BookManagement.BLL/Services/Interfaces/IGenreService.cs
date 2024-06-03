using BookManagement.Infrastructure.Models;
using BookManagement.Model;

namespace BookManagement.BLL.Services.Interfaces;

public interface IGenreService
{
    Task<OperationResult> AddGenreAsync(GenreModel genreModel);

    Task<OperationResult> UpdateGenreAsync(GenreModel genreModel);

    Task<List<GenreModel>> GetAllGenresAsync();

    Task<GenreModel?> GetGenreByIdAsync(Guid id);

    Task<OperationResult> DeleteGenreAsync(Guid id);
}
