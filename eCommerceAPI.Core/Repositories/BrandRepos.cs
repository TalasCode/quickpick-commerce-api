using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;
namespace eCommerceAPI.Core.Repositories
{
    public class BrandRepos(DbContext context) : Repository<Brand>(context) , IBrandRepos
    {
        private DatabaseServerContext databaseContext => (DatabaseServerContext)Context;

        public async Task<List<Brand>> GetAll()
        {
            //return await databaseContext.Brands.Select(b => new BrandDTO
            //{
            //    Id = b.Id,
            //    Name = b.Name,
            //    Picture = b.Picture,
            //}).ToListAsync();
            return await databaseContext.Brands.ToListAsync();
        }
        public async Task<BrandDTO?> GetBrandByName(string name)
        {
            return await databaseContext.Brands.Where(b => b.Name == name)
                .Select(b => new BrandDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Picture = b.Picture,
                }).FirstOrDefaultAsync();
        }
    }
}
