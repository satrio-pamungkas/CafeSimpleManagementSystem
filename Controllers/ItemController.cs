using Microsoft.AspNetCore.Mvc;
using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Repositories;
using CafeSimpleManagementSystem.Helpers;
using CafeSimpleManagementSystem.Wrappers;

namespace CafeSimpleManagementSystem.Controllers;

[Authorize]
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
    public IActionResult GetAll()
    {
        var payload = new Response<IEnumerable<Item>>()
        {
            Status = 200,
            Message = "Success",
            Data = _itemRepository!.GetAll()
        };

        return Ok(payload);
    }

    [HttpGet("{id}")]
    public ActionResult<Response<Item>> Get(int id)
    {
        var item = _itemRepository!.GetById(id);

        if (item is null)
        {
            return NotFound();
        }

        var payload = new Response<Item>()
        {
            Status = 200,
            Message = "Success",
            Data = item
        };

        return payload;
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
