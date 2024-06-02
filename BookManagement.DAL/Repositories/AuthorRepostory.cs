using BookManagement.Model.Entities;

namespace BookManagement.DAL.Repositories;
public sealed class AuthorRepository(ApplicationDbContext context) : BaseRepository<Author>(context)
{
}
