using BookManagement.BLL.Services.Interfaces;
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

    [HttpGet]
    public async Task<List<AuthorModel>> Get()
    {
        var authors = await _authorService.GetAllAuthors();

        return authors;
    }

    [HttpPut]
    public async Task<OperationResult> Put(AuthorModel authorModel)
    {
        try
        {
            var result = new OperationResult() { IsSucceed = false };

            if(authorModel.Id is null)
                result = await _authorService.AddAuthor(authorModel);

            else
                result = await _authorService.UpdateAuthor(authorModel);

            return result;
        }
        catch (Exception ex)
        {
            return new OperationResult { IsSucceed = false, Message = ResponseMessages.UnexpectedError };            
        }
    }
}
