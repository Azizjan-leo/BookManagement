namespace BookManagement.Model;

public sealed record BookModel
{
    public string Title { get; set; }
    public AuthorModel Author { get; set; }
    public int Year { get; set; }
    public GenreModel Genre { get; set; }
}
