using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>?> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
        Task<CategoryDTO?> GetCategoryByName(string name);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
}
