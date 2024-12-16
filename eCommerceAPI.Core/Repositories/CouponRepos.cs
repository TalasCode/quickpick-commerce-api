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
    public class CouponRepos(DbContext context) : Repository<Coupon>(context),ICouponRepos
    {
        DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;
      public async Task<List<CouponDTO>> GetAll()
        {
            return await databaseServerContext.Coupons.Select(c => new CouponDTO
            {
                Id = c.Id,
                Code = c.Code,
                DiscountAmount = c.DiscountAmount,
                DiscountPercentage = c.DiscountPercentage,
                ExpiryDate = c.ExpiryDate,
                IsActive = c.IsActive,
            }).ToListAsync();
        }
        public async Task<CouponDTO?> GetCouponByCode(string code)
        {
            return await databaseServerContext.Coupons.Where(c => c.Code == code)
                .Select(c=> new CouponDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    DiscountAmount = c.DiscountAmount,
                    DiscountPercentage = c.DiscountPercentage,
                    ExpiryDate = c.ExpiryDate,
                    IsActive = c.IsActive,
                }).FirstOrDefaultAsync();
        }
        
        public async Task<bool> isActive(string code)
        {
            return await databaseServerContext.Coupons.Where(c => c.Code == code).Select(c=>c.IsActive).FirstOrDefaultAsync();
        }
    }
}
