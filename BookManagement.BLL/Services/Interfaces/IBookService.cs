﻿using BookManagement.Infrastructure.Models;
using BookManagement.Model;

namespace BookManagement.BLL.Services.Interfaces;

public interface IBookService
{
    Task<OperationResult> AddBookAsync(PutBookModel genreModel);

    Task<OperationResult> UpdateBookAsync(PutBookModel genreModel);

    Task<List<BookModel>> GetAllBooksAsync();

    Task<BookModel?> GetBookByIdAsync(Guid id);

    Task<OperationResult> DeleteBookAsync(Guid id);
}
