using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IOrderRepos : IRepository<Order>
    {
        Task<List<OrderDTO>?> GetAll();
        Task<List<OrderDTO>> GetOrderByUser(int  userId);
    }
}
