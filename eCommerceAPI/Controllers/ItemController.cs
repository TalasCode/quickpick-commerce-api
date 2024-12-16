using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using eCommerceAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ItemController(IItemService itemService , IMapper mapper)  : Controller
    {
        [HttpGet("getAll")]

        public async Task<ActionResult> Get()
        {
            var items = await itemService.GetAllItems();
            return Ok(items);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Item?>> CreateItem(ItemRequest itemRequest)
        {
            if (itemRequest == null || string.IsNullOrEmpty(itemRequest.Name))
            {
                return BadRequest("Please provide a valid Item.");
            }
            

            var newItem = mapper.Map<Item>(itemRequest);
            await itemService.AddItem(newItem);

            return Ok(newItem);
        }
        [HttpDelete("delete/{id}")]

        public async Task<bool> RemoveItem(int id)
        {
            var item = await itemService.GetItemById(id);
            if (item == null)
            {
                BadRequest($"Item Id: {id} not Found");
                return false;
            }
            else
            {
                await itemService.DeleteItem(id);
                return true;
            }
        }

        [HttpPut("update/{id}")]

        public async Task<ActionResult<Item>> UpdateItem(int id, ItemRequest itemRequest)
        {

            if (itemRequest.Name != null)
            {
                var item = mapper.Map<Item>(itemRequest);
                item.Id = id;
                var updatedItem = await itemService.UpdateItem(item);
                if (updatedItem != null)
                {
                    return Ok(updatedItem);
                }
                else
                {
                    return NotFound("Item not found");
                }
            }
            else
            {
                return BadRequest("Item is required");
            }
        }
    }
}
