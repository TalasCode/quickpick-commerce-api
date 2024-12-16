using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IBrandService
    {
        Task<List<Brand>?> GetAllBrands();
        Task<Brand?> GetBrandById(int id);
        Task<BrandDTO?> GetBrandByName(string name);
        Task<Brand?> AddBrand(Brand brand);
        Task<Brand?> UpdateBrand(Brand brand);
        Task<bool> DeleteBrand(int id);
    }
}
