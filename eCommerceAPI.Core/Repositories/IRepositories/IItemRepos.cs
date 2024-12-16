using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;
namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IItemRepos : IRepository<Item>
    {
        Task<List<ItemDTO>?> GetAll();
        Task<List<ItemDTO>> GetItemByCategory(int categoryId);
        Task<List<ItemDTO>> GetItemByBrand(int brandId);
        Task<ItemDTO?> GetItemByName(string name);
    }
}
