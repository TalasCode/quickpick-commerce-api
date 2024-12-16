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
    public class OrderItemController(IOrderItemService orderItemService , IMapper mapper) : Controller
    {
        [HttpGet("getAll")]

        public async Task<ActionResult> Get()
        {
            var orderItems = await orderItemService.GetAllORderItems();

            return Ok(orderItems);
        }

        [HttpPost("add")]

        public async Task<ActionResult<OrderItem?>> CreateOrderItem(OrderItemRequest orderItemRequest)
        {
            if (orderItemRequest == null)
            {
                return BadRequest("Please provide a valid OrderItem.");
            }
            

            var newOrderItem = mapper.Map<OrderItem>(orderItemRequest);
            await orderItemService.AddOrderItem(newOrderItem);

            return Ok(newOrderItem);
        }
        [HttpDelete("delete/{id}")]

        public async Task<bool> RemoveOrderItem(int id)
        {
           
                await orderItemService.DeleteOrderItem(id);
                return true;
            
        }
        [HttpGet("getItemsByOrder/{orderId}")]

        public async Task<ActionResult> GetByOrderId(int orderId)
        {
            var orderItems = await orderItemService.GetAllOrderItem(orderId);

            return Ok(orderItems);
        }


    }
}
