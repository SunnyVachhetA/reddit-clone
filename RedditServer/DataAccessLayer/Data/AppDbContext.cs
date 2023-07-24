using Common.Utils;
using Entities.Abstract;
using Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace DataAccessLayer.Data;

public class AppDbContext : DbContext
{
    #region Constructor

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public virtual DbSet<User> Users { get; set; }

    #endregion Constructor

    #region Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => IsAuditEntity(e.Entity.GetType()) &&
                (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entryEntity in entries)
        {
            var baseEntity = (dynamic)entryEntity.Entity;
            baseEntity.UpdatedOn = DateUtil.UtcNow;

            if (entryEntity.State == EntityState.Added)
            {
                baseEntity.CreatedOn = DateUtil.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    private bool IsAuditEntity(Type entityType)
    {
        var baseType = entityType.BaseType;
        while (baseType != null)
        {
            if (baseType.IsGenericType &&
                baseType.GetGenericTypeDefinition() == typeof(AuditableEntity<>))
            {
                return true;
            }
            baseType = baseType.BaseType;
        }
        return false;
    }

    #endregion
}