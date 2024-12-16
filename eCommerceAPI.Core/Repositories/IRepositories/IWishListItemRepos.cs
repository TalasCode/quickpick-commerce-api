using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;
namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IWishListItemRepos :IRepository<WishlistItem>
    {
        Task<List<WishListItemDTO>?> GetAll();
        Task<List<ItemDTO>> GetItemsByUserId(int userId);

    }
}
