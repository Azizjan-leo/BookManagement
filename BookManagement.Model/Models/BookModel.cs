namespace BookManagement.Infrastructure.Models;

public sealed record BookModel
{
    public Guid? Id { get; set; }
    public required string Title { get; set; }
    public required AuthorModel Author { get; set; }
    public int Year { get; set; }
    public required GenreModel Genre { get; set; }
}
