using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IBrandRepos :IRepository<Brand>
    {
        Task<List<Brand>> GetAll();
        Task<BrandDTO?> GetBrandByName(string name);
    }
}
