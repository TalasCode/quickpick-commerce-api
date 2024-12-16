using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface ICouponService
    {
        Task<List<CouponDTO>> GetAllCoupons();
        Task<Coupon?> GetCouponById(int id);
        Task<CouponDTO?> GetCouponByCode(string code);
        Task<Coupon> AddCoupon(Coupon coupon);
        Task<Coupon> UpdateCoupon(Coupon coupon);
        Task<bool> DeleteCoupon(int id);
        Task<bool> isActive(string code);
    }
}
