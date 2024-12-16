using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using eCommerceAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CartController(ICartService cartService , IMapper mapper):Controller
    {
        [HttpGet("getAll")]
       
        public async Task<ActionResult> Get()
        {
            var carts = await cartService.GetAllCarts();

            return Ok(carts);
        }

        [HttpPost("add")]
     
        public async Task<ActionResult<Cart?>> CreateCartItem(CartRequest cartRequest)
        {
            if ( cartRequest == null || cartRequest.ItemId == 0)
            {
                return BadRequest("Please provide a valid name.");
            }
            var existingCart = await cartService.GetCartItemsByUser(cartRequest.UserId);
            var cart = mapper.Map<Cart>(cartRequest);
            
            if (existingCart != null && existingCart.Contains(cart))

            {
                return BadRequest(" this item is already exist in this cart");
            }

            var newCart = mapper.Map<Cart>(cartRequest);
            await cartService.AddCart(newCart);

            return Ok(newCart);
        }
        [HttpDelete("delete/{id}")]
       
        public async Task<bool> RemoveCartItem(int id)
        {
            var cart = await cartService.GetCartById(id);
            if (cart == null)
            {
                BadRequest($"Cart Id: {id} not Found");
                return false;
            }
            else
            {
                await cartService.DeleteItemCart(id);
                return true;
            }
        }

        [HttpPut("update/{id}")]
     
        public async Task<ActionResult<Cart>> UpdateCart(int id, CartRequest cartRequest)
        {

            if (cartRequest.ItemId != 0)
            {
                var cart = mapper.Map<Cart>(cartRequest);
                cart.Id = id;
                var updatedCart = await cartService.UpdateCart(cart);
                if (updatedCart != null)
                {
                    return Ok(updatedCart);
                }
                else
                {
                    return NotFound("cart not found");
                }
            }
            else
            {
                return BadRequest("cart is required");
            }
        }
        [HttpGet("getById/{id}")]

        public async Task<ActionResult> getById(int id)
        {
            var carts =  await cartService.GetCartItemsByUser(id);
            return Ok(carts);
        }

    }
}
