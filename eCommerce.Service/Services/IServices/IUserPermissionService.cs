using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services.IServices
{
   public interface IUserPermissionService
    {
        Task<List<UserPermissionDTO>?> GetAll();
        Task<UserPermission?> GetById(int id);

        Task<UserPermission?> AddUserPermission(UserPermission userPermission);

        Task<bool> DeleteUserPermission(int id);
        List<string> getPermissionsByRoleId(int roleId);
    }
}
