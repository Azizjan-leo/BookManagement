using BookManagement.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Infrastructure.Models;

public sealed record AuthorModel
{
    public Guid? Id { get; set; }
    
    public required string Name { get; set; } 

    public required string Bio { get; set; }
}
