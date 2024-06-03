using BookManagement.BLL.Services.Interfaces;
using BookManagement.Infrastructure.Models;
using BookManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public sealed class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService=authorService;
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(Guid id)
    {
        var result = await _authorService.DeleteAuthorAsync(id);

        return result;
    }

    [HttpGet]
    public async Task<List<AuthorModel>> Get()
    {
        var authors = await _authorService.GetAllAuthorsAsync();

        return authors;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var authorModel = await _authorService.GetAuthorByIdAsync(id);

        if (authorModel is null)
            return NotFound();

        return Ok(authorModel);
    }

    [HttpPut]
    public async Task<OperationResult> Put(AuthorModel authorModel)
    {
        try
        {
            var result = new OperationResult() { IsSucceed = false };

            if(authorModel.Id is null)
                result = await _authorService.AddAuthorAsync(authorModel);

            else
                result = await _authorService.UpdateAuthorAsync(authorModel);

            return result;
        }
        catch (Exception ex)
        {
            return new OperationResult { IsSucceed = false, Message = ResponseMessages.UnexpectedError };            
        }
    }
}
