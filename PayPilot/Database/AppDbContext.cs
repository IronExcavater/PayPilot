using Microsoft.EntityFrameworkCore;
using PayPilot.Core.Domain;

namespace PayPilot.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<PayRule> PayRules => Set<PayRule>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Explicit naming
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Job>().ToTable("Jobs");
        modelBuilder.Entity<Shift>().ToTable("Shifts");
        modelBuilder.Entity<PayRule>().ToTable("PayRules");

        // Primary keys
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<Job>().HasKey(x => x.Id);
        modelBuilder.Entity<Shift>().HasKey(x => x.Id);
        modelBuilder.Entity<PayRule>().HasKey(x => x.Id);

        // Foreign keys
        modelBuilder.Entity<Shift>()
            .HasOne(x => x.Job).WithMany()
            .HasForeignKey(x => x.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PayRule>()
            .HasOne(x => x.Job).WithMany()
            .HasForeignKey(x => x.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Job>()
            .HasOne(x => x.User).WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Temporal indexes (fast access)
        modelBuilder.Entity<PayRule>()
            .HasIndex(x => new { x.JobId, x.EffectiveFrom, x.EffectiveTo });
    }
}