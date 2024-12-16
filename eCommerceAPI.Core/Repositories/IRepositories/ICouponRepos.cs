using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.DTO;
namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface ICouponRepos :IRepository<Coupon>
    {
        Task<List<CouponDTO>> GetAll();
        Task<CouponDTO?> GetCouponByCode(string code);
        Task<bool> isActive(string code);
    }
}
