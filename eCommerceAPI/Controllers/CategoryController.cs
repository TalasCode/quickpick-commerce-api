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
    
    public class CategoryController(ICategoryService categoryService , IMapper mapper) : Controller
    {
        [HttpGet("getAll")]
      
        public async Task<ActionResult> Get()
        {
            var categories = await categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpPost("add")]

        public async Task<ActionResult<Category?>> CreateCategory(CategoryRequest categoryRequest)
        {
            if (categoryRequest == null || categoryRequest.Name == null)
            {
                return BadRequest("Please provide a valid name.");
            }
            var existingCategory = await categoryService.GetCategoryByName(categoryRequest.Name);
            

            if (existingCategory != null)

            {
                return BadRequest(" this category is already exist");
            }

            var newCategory = mapper.Map<Category>(categoryRequest);
            await categoryService.AddCategory(newCategory);
            return Ok(newCategory);
        }
        [HttpDelete("delete/{id}")]
        public async Task<bool> RemoveCategory(int id)
        {
            var category = await categoryService.GetCategoryById(id);
            if (category == null)
            {
                BadRequest($"Category Id: {id} not Found");
                return false;
            }
            else
            {
                await categoryService.DeleteCategory(id);
                return true;
            }
        }

        [HttpPut("update/{id}")]
     
        public async Task<ActionResult<Cart>> UpdateCategory(int id, CategoryRequest categoryRequest)
        {

            if (categoryRequest.Name != null)
            {
                var category = mapper.Map<Category>(categoryRequest);
                category.Id = id;
                var updatedCategory = await categoryService.UpdateCategory(category);
                if (updatedCategory != null)
                {
                    return Ok(updatedCategory);
                }
                else
                {
                    return NotFound("Category not found");
                }
            }
            else
            {
                return BadRequest("Category is required");
            }
        }
    }
}
