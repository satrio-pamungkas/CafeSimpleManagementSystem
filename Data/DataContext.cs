using Microsoft.EntityFrameworkCore;
using CafeSimpleManagementSystem.Models;

namespace CafeSimpleManagementSystem.Data;

public class DataContext : DbContext
{
    public DataContext (DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<User>? Users { get; set; }
    public DbSet<RefreshToken>? RefreshToken { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .Property(e => e.Id)
            .HasDefaultValue(Guid.NewGuid());
        modelBuilder
            .Entity<RefreshToken>()
            .Property(e => e.Id)
            .HasDefaultValue(Guid.NewGuid());
        modelBuilder
            .Entity<User>()
            .Property(e => e.CreatedDate)
            .HasDefaultValueSql("now()");
        modelBuilder
            .Entity<Item>()
            .Property(e => e.CreatedDate)
            .HasDefaultValueSql("now()");
        modelBuilder
            .Entity<RefreshToken>()
            .Property(e => e.CreatedDate)
            .HasDefaultValueSql("now()");
    }
}