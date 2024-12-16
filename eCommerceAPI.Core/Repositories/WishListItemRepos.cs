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
    public class WishListItemRepos(DbContext context): Repository<WishlistItem>(context) , IWishListItemRepos
    {

        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;
        public async Task<List<WishListItemDTO>?> GetAll()
        {
            return await databaseServerContext.WishlistItems.Select(x => new WishListItemDTO
            {
                Id = x.Id,
                ItemId = x.ItemId,
                UserId = x.UserId
            }).ToListAsync();
        }
            public async Task<List<ItemDTO>> GetItemsByUserId(int userId)
            {
                var WishItems = await databaseServerContext.WishlistItems
                    .Where(w => w.UserId == userId)
                    .Select(i => i.ItemId)
                    .ToListAsync();

            var ItemsDTO = await databaseServerContext.Items.Where(i => WishItems.Contains(i.Id))
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
            return ItemsDTO;


        }
    }
}
