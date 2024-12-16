using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using eCommerceAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
  
    public class CouponController(ICouponService couponService , IMapper mapper) : Controller
    {
        [HttpGet("getAll")]
        public async Task<ActionResult> Get()
        {
            var coupons = await couponService.GetAllCoupons();

            return Ok(coupons);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Coupon?>> CreateCoupon(CouponRequest couponRequest)
        {
            if (couponRequest == null || string.IsNullOrEmpty(couponRequest.Code))
            {
                return BadRequest("Please provide a valid Code.");
            }
            var existingCoupon = await couponService.GetCouponByCode(couponRequest.Code);
            if (existingCoupon != null)

            {
                return BadRequest($" {couponService.GetCouponByCode(couponRequest.Code).Result}The Code '{couponRequest.Code}' is already used.");
            }

            var newCoupon = mapper.Map<Coupon>(couponRequest);
            await couponService.AddCoupon(newCoupon);

            return Ok(newCoupon);
        }
        [HttpDelete("delete/{id}")]
        public async Task<bool> RemoveCoupon(int id)
        {
            var coupon = await couponService.GetCouponById(id);
            if (coupon == null)
            {
                BadRequest($"Coupon Id: {id} not Found");
                return false;
            }
            else
            {
                await couponService.DeleteCoupon(id);
                return true;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Coupon>> UpdateCoupon(int id, CouponRequest couponRequest)
        {

            if (couponRequest.Code != null)
            {
                var coupon = mapper.Map<Coupon>(couponRequest);
                coupon.Id = id;
                var updatedCoupon = await couponService.UpdateCoupon(coupon);
                if (updatedCoupon != null)
                {
                    return Ok(updatedCoupon);
                }
                else
                {
                    return NotFound("Coupon not found");
                }
            }
            else
            {
                return BadRequest("Coupon is required");
            }
        }
        [HttpGet("getcoupon/{code}")]
        public async Task<ActionResult> GetCoupon(string code)
        {
            var coupon = await couponService.GetCouponByCode(code);
           return Ok(coupon);
        }
        [HttpGet("getcouponById/{id}")]
        public async Task<ActionResult> GetCouponbyId(int id)
        {
            var coupon = await couponService.GetCouponById(id);
            return Ok(coupon);
        }
    }
}
