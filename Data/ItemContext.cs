using Microsoft.EntityFrameworkCore;
using CafeSimpleManagementSystem.Models;

namespace CafeSimpleManagementSystem.Data;

public class DataContext : DbContext
{
    public DataContext (DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Item> Items => Set<Item>();
}