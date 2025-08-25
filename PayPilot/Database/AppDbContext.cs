using Microsoft.EntityFrameworkCore;
using PayPilot.Core.Domain;

namespace PayPilot.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<PayRule> PayRules => Set<PayRule>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Foreign keys
        foreach (var t in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(Auditable).IsAssignableFrom(t.ClrType)) continue;

            modelBuilder.Entity(t.ClrType)
                .HasOne(typeof(User), nameof(Auditable.CreatedByUser)).WithMany()
                .HasForeignKey(nameof(Auditable.CreatedBy))
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity(t.ClrType)
                .HasOne(typeof(User), nameof(Auditable.UpdatedByUser)).WithMany()
                .HasForeignKey(nameof(Auditable.UpdatedBy))
                .OnDelete(DeleteBehavior.Restrict);
        }

        modelBuilder.Entity<Shift>()
            .HasOne(e => e.Job).WithMany()
            .HasForeignKey(e => e.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PayRule>()
            .HasOne(e => e.Job).WithMany()
            .HasForeignKey(e => e.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Job>()
            .HasOne(e => e.User).WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Temporal indexes (fast access)
        modelBuilder.Entity<PayRule>()
            .HasIndex(e => new { e.JobId, e.FromUtc, e.ToUtc });

        // Value converters
        modelBuilder.Entity<PayRule>()
            .Property(e => e.Money)
            .HasConversion(MoneyConverter.MoneyToString)
            .HasColumnType("TEXT");
    }
}