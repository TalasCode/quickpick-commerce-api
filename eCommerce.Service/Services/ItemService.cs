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
    public class ItemService(IUnitOfWork unitOfWork) : IItemService
    {
        public async Task<List<ItemDTO>?> GetAllItems()
        {
            try
            {
                var items = await unitOfWork.Items.GetAll();
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Item?> GetItemById(int id)
        {
            try
            {
                var item = await unitOfWork.Items.GetByIdAsync(id);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<ItemDTO>?> GetItemByCategory(int categoryId)
        {
            try
            {
                var items = await unitOfWork.Items.GetItemByCategory(categoryId);
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<ItemDTO>?> GetItemByBrand(int brandId)
        {
            try
            {
                var items = await unitOfWork.Items.GetItemByBrand(brandId);
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Item> AddItem(Item item)
        {
            try
            {
                await unitOfWork.Items.AddAsync(item);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Item> UpdateItem(Item item)
        {
            try
            {

                await unitOfWork.Items.UpdateAsync(item);
                await unitOfWork.CommitAsync();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> DeleteItem(int id)
        {
            try
            {
                var item = await unitOfWork.Items.GetByIdAsync(id);
                if (item == null)
                {
                    return false;
                }
                unitOfWork.Items.Remove(item);
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
