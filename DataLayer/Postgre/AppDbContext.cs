using DataLayer.Postgre.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Postgre;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Follower> Follower { get; set; } = null!;

    public DbSet<List> Lists { get; set; } = null!;

    public DbSet<ListItem> ListItems { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(
                "PostGreSql",
                b => b.MigrationsAssembly("DataLayer"));
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditFields()
    {
        var entries = ChangeTracker.Entries()
           .Where(e => e.Entity is IAuditFields &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var auditable = (IAuditFields)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                auditable.CreatedDate = DateTime.UtcNow;
                auditable.CreatedBy = Guid.Parse("00000000-0000-0000-0000-000000000000");
            }

            auditable.UpdatedDate = DateTime.UtcNow;
            auditable.UpdatedBy = Guid.Parse("00000000-0000-0000-0000-000000000000");
        }
    }
}
