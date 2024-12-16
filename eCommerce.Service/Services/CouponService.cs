using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services
{
    public class CouponService(IUnitOfWork unitOfWork) : ICouponService
    {
        public async Task<List<CouponDTO>> GetAllCoupons()
        {
            try
            {
                var coupons = await unitOfWork.Coupons.GetAll();
                return coupons;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Coupon?> GetCouponById(int id)
        {
            try
            {
                var coupon = await unitOfWork.Coupons.GetByIdAsync(id);
                return coupon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<CouponDTO?> GetCouponByCode(string code)
        {
            try
            {
                var coupon = await unitOfWork.Coupons.GetCouponByCode(code);
                return coupon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            try
            {
                await unitOfWork.Coupons.AddAsync(coupon);
                return coupon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Coupon> UpdateCoupon(Coupon coupon)
        {
            try
            {

                await unitOfWork.Coupons.UpdateAsync(coupon);
                await unitOfWork.CommitAsync();
                return coupon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> DeleteCoupon(int id)
        {
            try
            {
                var coupon = await unitOfWork.Coupons.GetByIdAsync(id);
                if (coupon == null)
                {
                    return false;
                }
                unitOfWork.Coupons.Remove(coupon);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> isActive(string code)
        {
            try
            {
                return await unitOfWork.Coupons.isActive(code);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
