using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services
{
    public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<List<CategoryDTO>?> GetAllCategories()
        {
            try
            {
                var categories = await unitOfWork.Category.GetAll();
                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Category?> GetCategoryById(int id)
        {
            try
            {
                return await unitOfWork.Category.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<CategoryDTO?> GetCategoryByName(string name)
        {
            try
            {
                return await unitOfWork.Category.GetCategoryByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                await unitOfWork.Category.AddAsync(category);
                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            try
            {

                await unitOfWork.Category.UpdateAsync(category);
                await unitOfWork.CommitAsync();
                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    
        public async Task<bool> DeleteCategory(int id)
        {

            try
            {
                var category = await unitOfWork.Category.GetByIdAsync(id);
                if (category == null)
                {
                    return false;
                }
                unitOfWork.Category.Remove(category);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
