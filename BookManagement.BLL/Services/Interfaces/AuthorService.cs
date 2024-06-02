using AutoMapper;
using BookManagement.DAL.Repositories;
using BookManagement.Model;
using BookManagement.Model.Entities;

namespace BookManagement.BLL.Services.Interfaces;
public sealed class AuthorService(AuthorRepository _authorRepository, IMapper _mapper)
{
    public async Task<OperationResult> AddAuthor(AuthorModel authorModel)
    {
        ArgumentNullException.ThrowIfNull(authorModel);

        var author = _mapper.Map<Author>(authorModel);

        _authorRepository.Create(author);

        await _authorRepository.SaveChangesAsync();

        return new OperationResult{ IsSucceed = false };
    }
}
