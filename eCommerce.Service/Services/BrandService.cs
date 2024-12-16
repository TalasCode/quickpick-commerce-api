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
    public class BrandService(IUnitOfWork unitOfWork) : IBrandService
    {
        public async Task<List<Brand>?> GetAllBrands()
        {
            try
            {
                var Brands = await unitOfWork.Brands.GetAll();
                return Brands;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Brand?> GetBrandById(int id)
        {
            try
            {
                return await unitOfWork.Brands.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<BrandDTO?> GetBrandByName(string name)
        {
            try
            {
                return await unitOfWork.Brands.GetBrandByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Brand?> AddBrand(Brand brand)
        {
            try
            {
                if (brand != null)
                {
                    await unitOfWork.Brands.AddAsync(brand);
                    await unitOfWork.CommitAsync();
                    return brand;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Brand?> UpdateBrand(Brand brand)
            {
                try
                {
                    if (brand != null)
                    {
                        await unitOfWork.Brands.UpdateAsync(brand);
                        await unitOfWork.CommitAsync();
                        return brand;
                    }
                    else { return null; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                Brand? brand = await unitOfWork.Brands.GetByIdAsync(id);
                if (brand == null)
                {
                    return false; 
                }
                unitOfWork.Brands.Remove(brand);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
            
                Console.WriteLine(ex.Message);
                return false; 
            }
        }
    }
}
