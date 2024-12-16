using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;
namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface ICategoryRepos : IRepository<Category>
    {
        Task<List<CategoryDTO>?> GetAll();
        Task<CategoryDTO?> GetCategoryByName(string name);
        
    }
}
