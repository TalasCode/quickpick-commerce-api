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

    public class OrderController(IOrderService orderService , IMapper mapper) : Controller
    {
        [HttpGet("getAll")]
        public async Task<ActionResult> Get()
        {
            var orders = await orderService.GetAllOrders();

            return Ok(orders);
        }

        [HttpPost("add")]

        public async Task<ActionResult<Order?>> CreateOrder(OrderRequest orderRequest)
        {
            if (orderRequest == null || orderRequest.UserId == 0)
            {
                return BadRequest("Please provide a valid User.");
            }
            

            var newOrder = mapper.Map<Order>(orderRequest);
            await orderService.AddOrder(newOrder);

            return Ok(newOrder);
        }
        [HttpDelete("delete/{id}")]
        public async Task<bool> RemoveOrder(int id)
        {
            var order = await orderService.GetOrderById(id);
            if (order == null)
            {
                BadRequest($"Order Id: {id} not Found");
                return false;
            }
            else
            {
                await orderService.DeleteOrder(id);
                return true;
            }
        }
        [HttpGet("getOrderbyUser/{id}")]
        public async Task<ActionResult> getOrderByUserId(int id)
        {
            var orders = await orderService.GetOrderByUser(id);
            return Ok(orders);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, OrderRequest orderRequest)
        {

            if (orderRequest.UserId != 0)
            {
                var order = mapper.Map<Order>(orderRequest);
                order.Id = id;
                var updatedOrder = await orderService.UpdateOrder(order);
                if (updatedOrder != null)
                {
                    return Ok(updatedOrder);
                }
                else
                {
                    return NotFound("Order not found");
                }
            }
            else
            {
                return BadRequest("Order is required");
            }
        }
    }
}
