using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>?> GetAllORderItems();
        Task<List<OrderItem>> GetAllOrderItem(int orderId);
       
        Task<OrderItem> AddOrderItem(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
        Task<bool> DeleteOrderItem(int id);
    }
}
