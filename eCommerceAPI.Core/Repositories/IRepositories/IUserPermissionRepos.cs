using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IUserPermissionRepos : IRepository<UserPermission>
    {
        Task<List<UserPermissionDTO>?> GetAll();
        List<string> GetPermissionsByRole(int roleId);
        Task<UserPermission?> AddPermissionRole(UserPermission userPermission);
        Task<UserPermission?> updatePermissionRole(UserPermission userPermission);
        Task<bool> RoleHasPermission(int roleId, string permission);
    }
}
