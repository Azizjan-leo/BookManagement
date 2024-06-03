using AutoMapper;
using BookManagement.DAL.Repositories;
using BookManagement.Model.Entities;
using BookManagement.Model;
using BookManagement.BLL.Services.Interfaces;
using BookManagement.Infrastructure.Models;

namespace BookManagement.BLL.Services;
public sealed class BookService(BookRepository _bookRepository, IMapper _mapper) 
    : IBookService
{
    public async Task<OperationResult> AddBookAsync(PutBookModel bookModel)
    {
        var book = _mapper.Map<Book>(bookModel);

        await _bookRepository.CreateAsync(book);

        var result = new OperationResult
        {
            IsSucceed = true,
            Message = "New book has been added.",
            Value = _mapper.Map<BookModel>(book)
        };
        
        return result;
    }

    public async Task<OperationResult> DeleteBookAsync(Guid id)
    {
        var book = await _bookRepository.DeleteAsync(id);

        return new OperationResult { IsSucceed = true, Message = "The book has been removed" };
    }

    public async Task<List<BookModel>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();

        var models = _mapper.Map<List<BookModel>>(books);

        return models;
    }

    public async Task<BookModel?> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetAsync(id);

        var bookModel = _mapper.Map<BookModel>(book);

        return bookModel;
    }

    public async Task<OperationResult> UpdateBookAsync(PutBookModel bookModel)
    {
        var book = _mapper.Map<Book>(bookModel);

        await _bookRepository.UpdateAsync(book);
        
        bookModel = _mapper.Map<PutBookModel>(book);

        var result = new OperationResult 
        { 
            IsSucceed = true, 
            Value = bookModel,  
            Message = "The book has been updated"
        }; 

        return result;
    }
}
