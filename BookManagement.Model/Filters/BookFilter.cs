namespace BookManagement.Infrastructure.Filters;

public sealed record BookFilter
{
    public string? Author { get; set; }
    public string? Title { get; set; }
    public Guid? GenreId { get; set; }

    public bool SortByYear { get; set; }
    public bool SortByAuthor { get; set; }
    public bool SortByTitle { get; set; }
}
