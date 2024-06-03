using BookManagement.Infrastructure.Models;
using BookManagement.Model;

namespace BookManagement.BLL.Services.Interfaces;

public interface IAuthorService
{
    Task<OperationResult> AddAuthorAsync(AuthorModel author);

    Task<OperationResult> UpdateAuthorAsync(AuthorModel author);

    Task<List<AuthorModel>> GetAllAuthorsAsync();

    Task<AuthorModel?> GetAuthorByIdAsync(Guid id);
    Task<OperationResult> DeleteAuthorAsync(Guid id);
}
