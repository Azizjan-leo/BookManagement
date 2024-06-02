using AutoMapper;
using BookManagement.DAL.Repositories;
using BookManagement.Model.Entities;
using BookManagement.Model;
using BookManagement.BLL.Services.Interfaces;

namespace BookManagement.BLL.Services;
public sealed class AuthorService(AuthorRepository _authorRepository, IMapper _mapper) : IAuthorService
{
    public async Task<OperationResult> AddAuthorAsync(AuthorModel authorModel)
    {
        ArgumentNullException.ThrowIfNull(authorModel);

        var author = _mapper.Map<Author>(authorModel);

        await _authorRepository.CreateAsync(author);

        return new OperationResult { IsSucceed = true, Message = "New author has been added." };
    }

    public async Task<List<AuthorModel>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetValuesAsync();

        var models = _mapper.Map<List<AuthorModel>>(authors);

        return models;
    }

    public async Task<AuthorModel?> GetAuthorByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetAsync(id);

        var authorModel = _mapper.Map<AuthorModel>(author);

        return authorModel;
    }

    public async Task<OperationResult> UpdateAuthorAsync(AuthorModel authorModel)
    {
        ArgumentNullException.ThrowIfNull(authorModel);

        var author = _mapper.Map<Author>(authorModel);

        await _authorRepository.UpdateAsync(author);

        authorModel = _mapper.Map<AuthorModel>(author);

        var result = new OperationResult 
        { 
            IsSucceed = true, 
            Value = authorModel,  
            Message = "Author has been updated"
        }; 

        return result;
    }
}
