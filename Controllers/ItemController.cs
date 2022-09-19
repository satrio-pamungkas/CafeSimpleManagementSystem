using Microsoft.AspNetCore.Mvc;
using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Repositories;

namespace CafeSimpleManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ItemRepository? _itemRepository;
    public ItemController(ItemRepository itemRepository) 
    {
        _itemRepository = itemRepository;
    }

    [HttpGet]
    public IEnumerable<Item> GetAll()
    {
        return _itemRepository!.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(int id)
    {
        var item = _itemRepository!.GetById(id);

        if (item is null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        _itemRepository!.Create(item);
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

        var existingItem = _itemRepository!.GetById(id);
        if (existingItem is null)
        {
            return NotFound();
        }

        _itemRepository.Update(item, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _itemRepository!.GetById(id);

        if (item is null)
        {
            return NotFound();
        }

        _itemRepository.Delete(id);
        
        return NoContent();
    }
}
