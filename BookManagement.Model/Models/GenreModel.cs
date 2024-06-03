namespace BookManagement.Infrastructure.Models;

public sealed record GenreModel
{
    public Guid? Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }
}
