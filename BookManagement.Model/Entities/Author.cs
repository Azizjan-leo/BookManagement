using System.ComponentModel.DataAnnotations;

namespace BookManagement.Model.Entities;
public class Author : BaseEntity
{
    [StringLength(55)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Bio { get; set; } = string.Empty;

    public List<Book> Books { get; set;} = [];
}
