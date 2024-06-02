using BookManagement.Model.Entities;

namespace BookManagement.DAL.Repositories;
public sealed class BookRepository(ApplicationDbContext context) : BaseRepository<Book>(context)
{
}
