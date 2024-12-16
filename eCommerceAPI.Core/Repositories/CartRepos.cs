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
    public class CartRepos(DbContext context):Repository<Cart>(context) , ICartRepos
    {
        private DatabaseServerContext databaseContext => (DatabaseServerContext)Context;
        //public async Task<List<CartDTO>> GetAll()
        //{
        //    return await databaseContext.Carts.Select(c => new CartDTO
        //    {
        //        Id = c.Id,
        //        UserId = c.UserId,
        //        ItemId = c.ItemId,
        //        Quantity = c.Quantity
        //    }).ToListAsync();
        //}
        public async Task<List<Cart>> GetAll()
        {
            return await databaseContext.Carts.ToListAsync();
        }
        public async Task<List<Cart>?> GetCartItemsByUser(int id)
        {
            return await databaseContext.Carts.Where(c => c.UserId == id)
                .Include(c=> c.Item).ToListAsync();
        }
    }
}
