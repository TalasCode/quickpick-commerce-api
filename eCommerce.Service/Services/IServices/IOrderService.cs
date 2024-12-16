using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IOrderService
    {
        Task<List<OrderDTO>?> GetAllOrders();
        Task<Order?> GetOrderById(int id);
        Task<List<OrderDTO>?> GetOrderByUser(int userId);
         
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int orderId);
    }
}
