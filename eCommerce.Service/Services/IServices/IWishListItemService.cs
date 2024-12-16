using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IWishListItemService
    {
        Task<List<WishListItemDTO>?> GetAllWishList();
        Task<WishlistItem?> GetWishListById(int id);
        Task<List<ItemDTO>?> GetWishListByUser(int user);
        Task<WishlistItem> AddWishListItem(WishlistItem wishlistItem);
        Task<WishlistItem> UpdateWishlistItem(WishlistItem wishlistItem);
        Task<bool> DeleteWishListItem(int id);
    }
}
