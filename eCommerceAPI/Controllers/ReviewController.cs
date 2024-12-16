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
    public class ReviewController(IReviewService reviewService , IMapper mapper) : Controller
    {
        
        
            [HttpGet("getAll")]

            public async Task<ActionResult> Get()
            {
                var reviews = await reviewService.GetAllReviews();

                return Ok(reviews);
            }

            [HttpPost("add")]
        [Authorize]
            public async Task<ActionResult<Review?>> CreateReview(ReviewRequest reviewRequest)
            {
                if (reviewRequest == null)
                {
                    return BadRequest("Please provide a valid Review.");
                }


                var newReview = mapper.Map<Review>(reviewRequest);
                await reviewService.AddReview(newReview);

                return Ok(newReview);
            }
            [HttpDelete("delete/{id}")]

        public async Task<bool> RemoveReview(int id)
            {
                var review = await reviewService.GetReviewById(id);
                if (review == null)
                {
                    BadRequest($"Review Id: {id} not Found");
                    return false;
                }
                else
                {
                    await reviewService.DeleteReview(id);
                    return true;
                }
            }

        /*    [HttpPost("/UdateReview")]
            public async Task<ActionResult<Offer>> UpdateReview(int id, OfferRequest offerRequest)
            {


                var offer = mapper.Map<Offer>(offerRequest);
                offer.OfferId = id;
                var updatedOffer = await offerService.UpdateOffer(offer);
                if (updatedOffer != null)
                {
                    return Ok(updatedOffer);
                }
                else
                {
                    return NotFound("Offer not found");
                }


            }*/
        }
}
