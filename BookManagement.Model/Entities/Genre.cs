using System.ComponentModel.DataAnnotations;

namespace BookManagement.Model.Entities;
public sealed class Genre : BaseEntity
{
    [StringLength(20, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100, MinimumLength = 25)]
    public string Description { get; set; } = string.Empty;
}
