using BookManagement.Model;

namespace BookManagement.BLL.Services.Interfaces;

public interface IAuthorService
{
    public Task<OperationResult> AddAuthorAsync(AuthorModel author);

    public Task<OperationResult> UpdateAuthorAsync(AuthorModel author);

    public Task<List<AuthorModel>> GetAllAuthorsAsync();

    public Task<AuthorModel?> GetAuthorByIdAsync(Guid id);
}
