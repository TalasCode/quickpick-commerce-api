using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
namespace eCommerce.Service.Services.IServices
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role?> GetRoleById(int id);
        Task<Role?> GetRoleByName(string roleName);

        Task<Role> AddRole(Role admin);
        
        Task<bool> DeleteRole(int id);

    }
}
