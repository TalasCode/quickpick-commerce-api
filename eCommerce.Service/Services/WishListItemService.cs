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
    public class WishListItemService(IUnitOfWork unitOfWork) : IWishListItemService
    {
       public async Task<List<WishListItemDTO>?> GetAllWishList()
        {
            try
            {
                var wl = await unitOfWork.WishListItems.GetAll();
                return wl;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<WishlistItem?> GetWishListById(int id)
        {
            try
            {
                var wl = await unitOfWork.WishListItems.GetByIdAsync(id);
                return wl;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<List<ItemDTO>?> GetWishListByUser(int user)
        {
            try
            {
                var wls = await unitOfWork.WishListItems.GetItemsByUserId(user);
                return wls;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<WishlistItem> AddWishListItem(WishlistItem wishlistItem)
        {
            try
            {
                await unitOfWork.WishListItems.AddAsync(wishlistItem);
                return wishlistItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<WishlistItem> UpdateWishlistItem(WishlistItem wishlistItem)
        {
            try
            {

                await unitOfWork.WishListItems.UpdateAsync(wishlistItem);
                await unitOfWork.CommitAsync();
                return wishlistItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<bool> DeleteWishListItem(int id)
        {
            try
            {
                var wl = await unitOfWork.WishListItems.GetByIdAsync(id);
                if (wl == null)
                {
                    return false;
                }
                unitOfWork.WishListItems.Remove(wl);
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
