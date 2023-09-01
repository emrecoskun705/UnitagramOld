using Microsoft.EntityFrameworkCore;
using Unitagram.Domain;
using Unitagram.Domain.Common;

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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnitagramDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}