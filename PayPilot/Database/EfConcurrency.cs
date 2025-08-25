using Microsoft.EntityFrameworkCore;

namespace PayPilot.Database;

public static class EfConcurrency
{
    public static async Task SaveChangesWithRetryAsync<TEntity>(
        this DbContext db,
        TEntity entity,
        object clientToken,
        string tokenProperty,
        Func<TEntity, Task> applyAsync,
        CancellationToken ct = default,
        int maxRetries = 3)
        where TEntity : class
    {
        var entry = db.Entry(entity);
        var tokenProp = entry.Property(tokenProperty);

        var success = false;
        var attempt = -1;
        var currentToken = clientToken;

        do
        {
            attempt++;

            await applyAsync(entity);
            tokenProp.OriginalValue = currentToken;
            tokenProp.IsModified = false;

            try
            {
                await db.SaveChangesAsync(ct);
                success = true;
            }
            catch (DbUpdateConcurrencyException) when (attempt < maxRetries)
            {
                await entry.ReloadAsync(ct);
                currentToken = tokenProp.CurrentValue!;
            }
        } while (!success && attempt < maxRetries);

        if (!success)
            throw new DbUpdateConcurrencyException($"Concurrency conflict could not be resolved after {maxRetries} attempts.");
    }

    public static async Task DeleteWithRetryAsync<TEntity>(
        this DbContext db,
        TEntity entity,
        object clientToken,
        string tokenProperty,
        CancellationToken ct = default,
        int maxRetries = 3)
        where TEntity : class
    {
        var entry = db.Entry(entity);
        var tokenProp = entry.Property(tokenProperty);

        var attempt = -1;
        var currentToken = clientToken;

        while (true)
        {
            entry.State = EntityState.Deleted;

            tokenProp.OriginalValue = currentToken;
            tokenProp.IsModified = false;

            try
            {
                await db.SaveChangesAsync(ct);
                return;
            }
            catch (DbUpdateConcurrencyException) when (attempt++ < maxRetries)
            {
                await entry.ReloadAsync(ct);
                currentToken = tokenProp.CurrentValue!;
            }
        }
    }
}