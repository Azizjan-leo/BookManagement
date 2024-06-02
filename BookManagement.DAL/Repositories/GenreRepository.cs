using BookManagement.Model.Entities;

namespace BookManagement.DAL.Repositories;
public sealed class GenreRepository(ApplicationDbContext context) : BaseRepository<Genre>(context)
{
}
