using CafeSimpleManagementSystem.Models;

namespace CafeSimpleManagementSystem.Data;

public static class DbInitializer
{
    public static void Initialize(DataContext dataContext)
    {
        if (dataContext.Items.Any())
        {
            return;
        }

        var items = new Item[]
        {
            new Item
            {
                Name = "Doughnut",
                Type = "Food",
                Quantity = 10,
                Price = 15000
            },
            new Item 
            {
                Name = "Latte",
                Type = "Beverage",
                Quantity = 5,
                Price = 5000
            }
        };

        dataContext.Items.AddRange(items);
        dataContext.SaveChanges();
    }
}