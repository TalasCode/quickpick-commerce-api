using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;
namespace eCommerceAPI.Core.Repositories
{
    public class ItemRepos(DbContext context): Repository<Item>(context) , IItemRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;

        public async Task<List<ItemDTO>?> GetAll()
        {
            return await databaseServerContext.Items.Select(i => new ItemDTO
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                CategoryId = i.CategoryId,
                BrandId = i.BrandId,
                Price = i.Price,
                Stock = i.Stock,
                Picture = i.Picture,
            }).ToListAsync();
        }
        public async Task<List<ItemDTO>> GetItemByCategory(int categoryId)
        {
            return await databaseServerContext.Items.Where(i=> i.CategoryId == categoryId)
                .Select(i => new ItemDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    CategoryId = i.CategoryId,
                    BrandId = i.BrandId,
                    Price = i.Price,
                    Stock = i.Stock,
                    Picture = i.Picture,
                }).ToListAsync();
        }
        public async Task<List<ItemDTO>> GetItemByBrand(int brandId)
        {
            return await databaseServerContext.Items.Where(i => i.BrandId == brandId)
                .Select(i => new ItemDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    CategoryId = i.CategoryId,
                    BrandId = i.BrandId,
                    Price = i.Price,
                    Stock = i.Stock,
                    Picture = i.Picture,
                }).ToListAsync();
        }
        public async Task<ItemDTO?> GetItemByName(string name)
        {
            return await databaseServerContext.Items.Where(i => i.Name == name)
                .Select(i => new ItemDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    CategoryId = i.CategoryId,
                    BrandId = i.BrandId,
                    Price = i.Price,
                    Stock = i.Stock,
                    Picture = i.Picture,
                }).FirstOrDefaultAsync();
        }
    }
}
