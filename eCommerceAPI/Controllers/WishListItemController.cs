using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListItemController(IWishListItemService wlService, IMapper mapper) : Controller
    {
        [HttpGet("getAll")]
        public async Task<ActionResult> Get()
        {
            var wls = await wlService.GetAllWishList();

            return Ok(wls);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Offer?>> CreateWL(WishListItemRequest wlRequest)
        {
            if (wlRequest == null)
            {
                return BadRequest("Please provide a valid WishListItem.");
            }


            var newWl = mapper.Map<WishlistItem>(wlRequest);
            await wlService.AddWishListItem(newWl);

            return Ok(newWl);
        }
        [HttpDelete("delete/{id}")]
        public async Task<bool> RemoveWL(int id)
        {
            var wl = await wlService.GetWishListById(id);
            if (wl == null)
            {
                BadRequest($"WishListItem Id: {id} not Found");
                return false;
            }
            else
            {
                await wlService.DeleteWishListItem(id);
                return true;
            }
        }

    }
      
}
