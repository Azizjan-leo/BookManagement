namespace BookManagement.Model.Entities;
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public void Undo()
    {
        DeletedAt = IsDeleted ? null : DateTime.UtcNow;
        IsDeleted = !IsDeleted;
    }
}
