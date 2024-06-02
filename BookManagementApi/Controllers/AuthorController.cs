using BookManagement.BLL.Services.Interfaces;
using BookManagement.Model;
using Microsoft.AspNetCore.Http;
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

    [HttpPut]
    public async Task<OperationResult> Put(AuthorModel authorModel)
    {
        try
        {
            var res = await _authorService.AddAuthor(authorModel);
            return res;
        }
        catch (Exception ex)
        {
            return new OperationResult { IsSucceed = false, Message = ResponseMessages.UnexpectedError };            
        }
    }
}
