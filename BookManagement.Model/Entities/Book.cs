using System.ComponentModel.DataAnnotations;

namespace BookManagement.Model.Entities;

public sealed class Book : BaseEntity
{
    [StringLength(50, MinimumLength = 3)]
    public string Title { get; set; }
    public Author Author { get; set; }
    public int Year { get; set; }
    public Genre Genre { get; set; }
}