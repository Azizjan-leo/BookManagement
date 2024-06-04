using BookManagement.Infrastructure.Filters;
using BookManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repositories;
public sealed class BookRepository(ApplicationDbContext context) : BaseRepository<Book>(context)
{
    public async Task<List<Book>> GetAllBooksAsync(BookFilter filter)
    {
        var booksQuery = _dbContext.Books
            .Include(x => x.Author)
            .Include(x => x.Genre)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Author))
            booksQuery = booksQuery.Where(x => x.Author.Name.Contains(filter.Author));

        if(!string.IsNullOrEmpty(filter.Title))
            booksQuery = booksQuery.Where(x => x.Title.Contains(filter.Title));

        if (filter.GenreId is not null)
            booksQuery = booksQuery.Where(x => x.Genre.Id == filter.GenreId);

        if (filter.SortByAuthor)
            booksQuery = booksQuery.OrderBy(x => x.Author.Name);
        else if (filter.SortByTitle)
            booksQuery = booksQuery.OrderBy(x => x.Title);
        else if (filter.SortByYear)
            booksQuery = booksQuery.OrderBy(x => x.Year);

        var books = await booksQuery.ToListAsync();
        return books;
    }
}
