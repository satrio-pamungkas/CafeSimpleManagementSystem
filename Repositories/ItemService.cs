using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CafeSimpleManagementSystem.Repositories;

public class ItemRepository
{
    private readonly DataContext? _context;
    public ItemRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Item> GetAll()
    {
        return _context!.Items.AsNoTracking().ToList();
    }

    public Item? GetById(int id)
    {
        return _context!.Items
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Item Create(Item item)
    {
        _context!.Items.Add(item);
        _context!.SaveChanges();

        return item;
    }

    public void Update(Item item, int id)
    {
        var itemToUpdate = _context!.Items.Find(id);

        if (itemToUpdate is null)
        {
            throw new InvalidOperationException("Item does not exist");
        }

        _context.Items.Update(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var itemToDelete = _context!.Items.Find(id);
        if (itemToDelete is not null)
        {
            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();
        }
    }
}