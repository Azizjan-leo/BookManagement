using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using BookManagement.Model.Entities;

namespace BookManagement.DAL;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Deleted, Entity: BaseEntity entity}) continue;
            entry.State = EntityState.Modified;
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
        }
        return result;
    }
}