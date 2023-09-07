using Microsoft.EntityFrameworkCore;
using Unitagram.Domain;
using Unitagram.Domain.Common;
using Unitagram.Domain.Primitives;

namespace Unitagram.Persistence.DatabaseContext;

public class UnitagramDatabaseContext : DbContext
{
    public UnitagramDatabaseContext(DbContextOptions<UnitagramDatabaseContext> options) : base(options)
    {
    }

    protected UnitagramDatabaseContext()
    {
    }
    
    public DbSet<University> University { get; set; }
    public DbSet<UniversityUser> UniversityUser { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnitagramDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<IAuditableEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.ModifiedOnUtc = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOnUtc = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}