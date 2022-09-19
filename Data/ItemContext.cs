using Microsoft.EntityFrameworkCore;
using CafeSimpleManagementSystem.Models;

namespace CafeSimpleManagementSystem.Data;

public class ItemContext : DbContext
{
    public ItemContext (DbContextOptions<ItemContext> options) : base(options)
    {

    }

    public DbSet<Item> Items => Set<Item>();
}