using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface ICartService
    {
        Task<List<Cart>> GetAllCarts();
        Task<Cart?> GetCartById(int id);
        Task<List<Cart>?> GetCartItemsByUser(int userId);
        Task<Cart> AddCart(Cart cart);
        Task<Cart> UpdateCart(Cart cart);
        Task<bool> DeleteItemCart(int ItemId);
    }
}
