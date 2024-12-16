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

    public class OfferController(IOfferService offerService, IMapper mapper) : Controller
    {
        [HttpGet("getAll")]
        public async Task<ActionResult> Get()
        {
            var offers = await offerService.GetAllOffers();

            return Ok(offers);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Offer?>> CreateOffer(OfferRequest offerRequest)
        {
            if (offerRequest == null)
            {
                return BadRequest("Please provide a valid offer.");
            }
           

            var newOffer = mapper.Map<Offer>(offerRequest);
            await offerService.AddOffer(newOffer);

            return Ok(newOffer);
        }
        [HttpDelete("delete/{id}")]
  
        public async Task<bool> RemoveOffer(int id)
        {
            var offer = await offerService.GetOfferById(id);
            if (offer == null)
            {
                BadRequest($"Offer Id: {id} not Found");
                return false;
            }
            else
            {
                await offerService.DeleteOffer(id);
                return true;
            }
        }

        [HttpPost("update/{id}")]

        public async Task<ActionResult<Offer>> UpdateOffer(int id, OfferRequest offerRequest)
        {

           
                var offer = mapper.Map<Offer>(offerRequest);
                offer.Id = id;
                var updatedOffer = await offerService.UpdateOffer(offer);
                if (updatedOffer != null)
                {
                    return Ok(updatedOffer);
                }
                else
                {
                    return NotFound("Offer not found");
                }
            
            
        }
    }
}
