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
    public class OrderItemRepos(DbContext context): Repository<OrderItem>(context) , IOrderItemRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;

        public async Task<List<OrderItem>?> GetAll()
        {
            return await databaseServerContext.OrderItems.Include(o => o.Order).ToListAsync();
        }
       public async Task<List<OrderItem>> GetItemsByOrder(int orderId)
        {
            return await databaseServerContext.OrderItems.Where(o => o.OrderId == orderId)
                .Include(o=> o.Order).ToListAsync();
        }
    }
}
