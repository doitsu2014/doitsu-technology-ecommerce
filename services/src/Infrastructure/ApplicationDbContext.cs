using Domain.Interfaces.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    private static void UpdateImported(object sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is IImported entityWithImported)
        {
            switch (e.Entry.State)
            {
                case EntityState.Modified:
                    entityWithImported.Imported = DateTimeOffset.UtcNow;
                    break;
                case EntityState.Added:
                    entityWithImported.Imported = DateTimeOffset.UtcNow;
                    break;
            }
        }
    }
}