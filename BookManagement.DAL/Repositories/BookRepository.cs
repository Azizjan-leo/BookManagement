using BookManagement.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repositories;
public sealed class BookRepository(ApplicationDbContext context) : BaseRepository<Book>(context)
{
    public async Task<List<Book>> GetAllBooksAsync()
    {
        var books = await _dbContext.Books
            .Include(x => x.Author)
            .Include(x => x.Genre)
            .ToListAsync();

        return books;
    }
}
