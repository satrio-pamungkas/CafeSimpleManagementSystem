using CafeSimpleManagementSystem.Models;

namespace CafeSimpleManagementSystem.Services;

public static class ItemService
{
    static List<Item> Items { get; }
    static int nextId = 3;
    static ItemService()
    {
        Items = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Waffel",
                Type = "Food",
                Price = 10000,
                Quantity = 10
            },
            new Item
            {
                Id = 2,
                Name = "Latte",
                Type = "Beverage",
                Price = 3000,
                Quantity = 15          
            },
            new Item
            {
                Id = 1,
                Name = "Doughnut",
                Type = "Food",
                Price = 7500,
                Quantity = 5
            }
        };
    }

    public static List<Item> GetAll() => Items;
    public static Item? Get(int Id)
    {
        return Items.FirstOrDefault(p => p.Id == Id);
    }

    public static void Add(Item item)
    {
        item.Id = nextId++;
        Items.Add(item);
    }

    public static void Delete(int Id)
    {
        var item = Get(Id);
        if (item is null)
        {
            return;
        }

        Items.Remove(item);
    }

    public static void Update(Item item)
    {
        var index = Items.FindIndex(p => p.Id == item.Id);
        if (index == -1)
        {
            return;
        }

        Items[index] = item;
    }
}