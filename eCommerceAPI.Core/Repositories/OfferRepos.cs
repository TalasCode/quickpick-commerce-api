using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories
{
    public class OfferRepos(DbContext context) : Repository<Offer>(context) , IOfferRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;

        public async Task<List<OfferDTO>?> GetAll()
        {
            return await databaseServerContext.Offers.Select(o => new OfferDTO
            {
                Id = o.Id,
                ItemId = o.ItemId,
                Description = o.Description,
                DiscountAmount = o.DiscountAmount,
                DiscountPercentage = o.DiscountPercentage,
                StartDate = o.StartDate,
                EndDate = o.EndDate,
                CategoryId = o.CategoryId,
                BrandId = o.BrandId

            }).ToListAsync();
        }
        public async Task<List<OfferDTO>?> GetOfferByCategory(int categoryId)
        {
            return await databaseServerContext.Offers.Where(o => o.CategoryId == categoryId)
                .Select(o => new OfferDTO
                {

                    Id = o.Id,
                    ItemId = o.ItemId,
                    Description = o.Description,
                    DiscountAmount = o.DiscountAmount,
                    DiscountPercentage = o.DiscountPercentage,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    CategoryId = o.CategoryId,
                    BrandId = o.BrandId,
                    Picture = o.Picture,

                }).ToListAsync();
        }
        public async Task<List<OfferDTO>?> GetOfferByBrand(int brandId)
        {
            return await databaseServerContext.Offers.Where(o => o.BrandId == brandId)
               .Select(o => new OfferDTO
               {

                   Id = o.Id,
                   ItemId = o.ItemId,
                   Description = o.Description,
                   DiscountAmount = o.DiscountAmount,
                   DiscountPercentage = o.DiscountPercentage,
                   StartDate = o.StartDate,
                   EndDate = o.EndDate,
                   CategoryId = o.CategoryId,
                   BrandId = o.BrandId,
                   Picture = o.Picture,

               }).ToListAsync();
        }
    }
}
