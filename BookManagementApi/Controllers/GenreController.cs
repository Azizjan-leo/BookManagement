using BookManagement.BLL.Services.Interfaces;
using BookManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public sealed class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService authorService)
    {
        _genreService=authorService;
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(Guid id)
    {
        var result = await _genreService.DeleteGenreAsync(id);

        return result;
    }

    [HttpGet]
    public async Task<List<GenreModel>> Get()
    {
        var genres = await _genreService.GetAllGenresAsync();

        return genres;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var genreModel = await _genreService.GetGenreByIdAsync(id);

        if (genreModel is null)
            return NotFound();

        return Ok(genreModel);
    }

    [HttpPut]
    public async Task<OperationResult> Put(GenreModel genreModel)
    {
        try
        {
            var result = new OperationResult() { IsSucceed = false };

            if(genreModel.Id is null)
                result = await _genreService.AddGenreAsync(genreModel);

            else
                result = await _genreService.UpdateGenreAsync(genreModel);

            return result;
        }
        catch (Exception ex)
        {
            return new OperationResult { IsSucceed = false, Message = ResponseMessages.UnexpectedError };            
        }
    }
}
