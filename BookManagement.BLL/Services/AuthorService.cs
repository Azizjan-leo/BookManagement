using AutoMapper;
using BookManagement.DAL.Repositories;
using BookManagement.Model.Entities;
using BookManagement.Model;
using BookManagement.BLL.Services.Interfaces;

namespace BookManagement.BLL.Services;
public sealed class AuthorService(AuthorRepository _authorRepository, IMapper _mapper) : IAuthorService
{
    public async Task<OperationResult> AddAuthor(AuthorModel authorModel)
    {
        ArgumentNullException.ThrowIfNull(authorModel);

        var author = _mapper.Map<Author>(authorModel);

        _authorRepository.Create(author);

        await _authorRepository.SaveChangesAsync();

        return new OperationResult { IsSucceed = true, Message = "New author has been added." };
    }
}
