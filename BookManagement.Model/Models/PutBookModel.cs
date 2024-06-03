namespace BookManagement.Infrastructure.Models;

public sealed record PutBookModel
{
    public Guid? Id { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }

    public required Guid AuthorId { get; set; }
    public required Guid GenreId { get; set; }
}
