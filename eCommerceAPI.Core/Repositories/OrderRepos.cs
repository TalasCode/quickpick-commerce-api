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
    public class OrderRepos(DbContext context) :Repository<Order>(context) , IOrderRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;

        public async Task<List<OrderDTO>?> GetAll()
        {
            return await databaseServerContext.Orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderStatus = o.OrderStatus,
                OrderDate = o.OrderDate,
                CouponId = o.CouponId,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Email = o.Email,
                Street = o.Street,
                City = o.City,
                Country = o.Country,
                Phone = o.Phone,
                Amount = o.Amount,

            }).ToListAsync();
        }
        public async Task<List<OrderDTO>> GetOrderByUser(int userId)
        {
            return await databaseServerContext.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderStatus = o.OrderStatus,
                    OrderDate = o.OrderDate,
                    CouponId = o.CouponId,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Email = o.Email,
                    Street = o.Street,
                    City = o.City,
                    Country = o.Country,
                    Phone = o.Phone,
                    Amount = o.Amount,

                }).ToListAsync();
        }
    }
}
