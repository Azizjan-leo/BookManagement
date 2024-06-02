namespace BookManagement.Model;

public sealed record AuthorModel
{
    public string Name { get; set; } = string.Empty;

    public string Bio { get; set; } = string.Empty;

    public List<BookModel> Books { get; set; } = [];
}
