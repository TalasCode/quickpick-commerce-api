using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface ICartRepos : IRepository<Cart>
    {
        Task<List<Cart>> GetAll();
        Task<List<Cart>?> GetCartItemsByUser(int id);
    }
}
