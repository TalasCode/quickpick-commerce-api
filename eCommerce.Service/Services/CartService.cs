using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services
{
    public class CartService(IUnitOfWork unitOfWork) : ICartService
    {
        public async Task<List<Cart>> GetAllCarts()
        {
            try
            {
                var carts = await unitOfWork.Carts.GetAll();
                return carts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Cart?> GetCartById(int id)
        {
            try
            {
                return await unitOfWork.Carts.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<Cart>?> GetCartItemsByUser(int userId)
        {
            try
            {
               var carts = await unitOfWork.Carts.GetCartItemsByUser(userId);
                return carts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<Cart> AddCart(Cart cart)
        {
            try
            {

                await unitOfWork.Carts.AddAsync(cart);
                await unitOfWork.CommitAsync();
                return cart;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Cart> UpdateCart(Cart cart)

        {
            try
            {
                await unitOfWork.Carts.UpdateAsync(cart);
                await unitOfWork.CommitAsync();
                return cart;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<bool> DeleteItemCart(int ItemId)
        {
            try
            {
                
                var cart = await unitOfWork.Carts.GetByIdAsync(ItemId);
                if (cart == null)
                {
                    return false;
                }
                unitOfWork.Carts.Remove(cart);
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
