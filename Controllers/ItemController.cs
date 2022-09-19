using Microsoft.AspNetCore.Mvc;
using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Services;

namespace CafeSimpleManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    public ItemController() {}

    [HttpGet]
    public ActionResult<List<Item>> GetAll()
    {
        return ItemService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(int id)
    {
        var item = ItemService.Get(id);

        if (item is null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        ItemService.Add(item);
        return CreatedAtAction(nameof(Create), 
            new { id = item.Id }, item
        );
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Item item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        var existingItem = ItemService.Get(id);
        if (existingItem is null)
        {
            return NotFound();
        }

        ItemService.Update(item);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = ItemService.Get(id);

        if (item is null)
        {
            return NotFound();
        }

        ItemService.Delete(id);
        
        return NoContent();
    }
}
