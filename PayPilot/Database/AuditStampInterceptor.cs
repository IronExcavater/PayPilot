using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PayPilot.Core.Domain;
using PayPilot.Core.Services;

namespace PayPilot.Database;

public class AuditStampInterceptor(IUserContext ctx) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var db = eventData.Context!;
        var now = DateTime.UtcNow;
        var userId = ctx.RequiredUserId;

        foreach (var entry in db.ChangeTracker.Entries<Auditable>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedUtc = now;
                entry.Entity.CreatedBy = userId;

                entry.Property("CreatedUtc").IsModified = false;
                entry.Property("CreatedBy").IsModified = false;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedUtc = now;
                entry.Entity.UpdatedBy = userId;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}