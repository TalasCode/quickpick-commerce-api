using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Repositories.IRepositories;
namespace eCommerceAPI.Core.Repositories
{
    public class CategoryRepos(DbContext context): Repository<Category>(context) , ICategoryRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;
        public async Task<CategoryDTO?> GetCategoryByName(string name)
        {
            return await databaseServerContext.Categories.Where(c => c.Name == name)
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Picture = c.Picture
                }).FirstOrDefaultAsync();
        }

        public async Task<List<CategoryDTO>?> GetAll()
        {
            return await databaseServerContext.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Picture = c.Picture
            }).ToListAsync();
        }
    }
}
