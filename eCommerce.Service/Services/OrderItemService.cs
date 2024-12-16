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
    public class OrderItemService(IUnitOfWork unitOfWork) : IOrderItemService
    {
       public async Task<List<OrderItem>?> GetAllORderItems()
        {
            try
            {
                var orderItemDTOs = await unitOfWork.OrderItems.GetAll();
                return orderItemDTOs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<List<OrderItem>> GetAllOrderItem(int orderId)
        {
            try
            {
                var Items = await unitOfWork.OrderItems.GetItemsByOrder(orderId);
                return Items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
     
      public async  Task<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            try
            {
                await unitOfWork.OrderItems.AddAsync(orderItem);
                Item? item = await unitOfWork.Items.GetByIdAsync(orderItem.ItemId);
                if (item != null)
                {
                    item.Stock -= orderItem.Quantity;

                    // Ensure stock doesn't go below zero
                    if (item.Stock < 0)
                    {
                        throw new InvalidOperationException("Insufficient stock available.");
                    }

                    // Update the item in the database
                    await unitOfWork.Items.UpdateAsync(item);
                }


                return orderItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            try
            {

                await unitOfWork.OrderItems.UpdateAsync(orderItem);
                await unitOfWork.CommitAsync();
                return orderItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<bool> DeleteOrderItem(int id)
        {
            try
            {
                var orderItem = await unitOfWork.OrderItems.GetByIdAsync(id);
                if (orderItem == null)
                {
                    return false;
                }
                unitOfWork.OrderItems.Remove(orderItem);
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
