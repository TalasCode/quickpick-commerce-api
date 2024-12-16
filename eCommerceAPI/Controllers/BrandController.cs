using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using eCommerceAPI.Service.Attribute;
using eCommerceAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class BrandController(IBrandService brandService , IMapper mapper) : Controller
    {
        
       [HttpGet("getAll")]
        

        public async Task<ActionResult> Get()
        {
            var brands = await brandService.GetAllBrands();

            return Ok(brands);
        }

        [HttpPost("add")]
     
        public async Task<ActionResult<Brand?>> CreateBrand(BrandRequest brandRequest)
        {
            if (brandRequest == null || string.IsNullOrEmpty(brandRequest.Name))
            {
                return BadRequest("Please provide a valid name.");
            }
            var existingBrand = await brandService.GetBrandByName(brandRequest.Name);
            if (existingBrand != null)

            {
                return BadRequest($" {brandService.GetBrandByName(brandRequest.Name).Result}The Name '{brandRequest.Name}' is already exist.");
            }

            var newBrand = mapper.Map<Brand>(brandRequest);
            await brandService.AddBrand(newBrand);

            return Ok(newBrand);
        }
        [HttpDelete("delete/{id}")]
       
        public async Task<bool> RemoveBrand(int id) {
            var brand = await brandService.GetBrandById(id);
            if (brand == null)
            {
                BadRequest($"Brand Id: {id} not Found");
                return false;
            }
            else
            {
                await brandService.DeleteBrand(id);
                return true;
            }
        }

        [HttpPut("update/{id}")]
        
        public async Task<ActionResult<Brand>> UpdateBrand(int id, BrandRequest brandRequest)
        {

            if (brandRequest.Name != null)
            {
                var brand = mapper.Map<Brand>(brandRequest);
                brand.Id = id;
                var updatedBrand = await brandService.UpdateBrand(brand);
                if (updatedBrand != null)
                {
                    return Ok(updatedBrand);
                }
                else
                {
                    return NotFound("brand not found");
                }
            }
            else
            {
                return BadRequest("brand is required");
            }
        }
    }
}
