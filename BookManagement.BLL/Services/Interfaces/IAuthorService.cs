using BookManagement.Model;

namespace BookManagement.BLL.Services.Interfaces;

public interface IAuthorService
{
    public Task<OperationResult> AddAuthor(AuthorModel author);

    public Task<OperationResult> UpdateAuthor(AuthorModel author);

    public Task<List<AuthorModel>> GetAllAuthors();
}
