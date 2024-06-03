using BookManagement.BLL.Services.Interfaces;
using BookManagement.Infrastructure.Models;
using BookManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public sealed class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService=bookService;
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(Guid id)
    {
        var result = await _bookService.DeleteBookAsync(id);

        return result;
    }

    [HttpGet]
    public async Task<List<BookModel>> Get()
    {
        var books = await _bookService.GetAllBooksAsync();

        return books;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var bookModel = await _bookService.GetBookByIdAsync(id);

        if (bookModel is null)
            return NotFound();

        return Ok(bookModel);
    }

    [HttpPut]
    public async Task<OperationResult> Put(PutBookModel bookModel)
    {
        try
        {
            var result = new OperationResult() { IsSucceed = false };

            if(bookModel.Id is null)
                result = await _bookService.AddBookAsync(bookModel);

            else
                result = await _bookService.UpdateBookAsync(bookModel);

            return result;
        }
        catch (Exception ex)
        {
            return new OperationResult { IsSucceed = false, Message = ResponseMessages.UnexpectedError };            
        }
    }
}
