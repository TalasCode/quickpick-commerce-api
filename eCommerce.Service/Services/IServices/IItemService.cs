using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IItemService
    {
        Task<List<ItemDTO>?> GetAllItems();
        Task<Item?> GetItemById(int id);
        Task<List<ItemDTO>?> GetItemByCategory(int categoryId);
        Task<List<ItemDTO>?> GetItemByBrand(int brandId);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<bool> DeleteItem(int id);
    }
}
