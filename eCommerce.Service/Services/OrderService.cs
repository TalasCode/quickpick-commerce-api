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
    public class OrderService(IUnitOfWork unitOfWork) : IOrderService
    {
       public async Task<List<OrderDTO>?> GetAllOrders()
        {
            try
            {
                var orders = await unitOfWork.Orders.GetAll();
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<Order?> GetOrderById(int id)
        {
            try
            {
                var order = await unitOfWork.Orders.GetByIdAsync(id);
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<List<OrderDTO>?> GetOrderByUser(int userId)
        {
            try
            {
                var order = await unitOfWork.Orders.GetOrderByUser(userId);
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

       public async Task<Order> AddOrder(Order order)
        {
            try
            {
                await unitOfWork.Orders.AddAsync(order);
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<Order> UpdateOrder(Order order)
        {
            try
            {

                await unitOfWork.Orders.UpdateAsync(order);
                await unitOfWork.CommitAsync();
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<bool> DeleteOrder(int orderId)
        {
            try
            {
                var order = await unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                {
                    return false;
                }
                unitOfWork.Orders.Remove(order);
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
