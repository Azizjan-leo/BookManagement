namespace BookManagement.Model;

public sealed record GenreModel
{
    public Guid? Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
