using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IUserRepos : IRepository<User>
    {
        Task<List<User>?> GetAll();
        Task<UserDTO?> GetUserByEmail(string email);
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUserByUsernameAndPassword(string username, string password);
        Task<bool> RoleHasPermission(int roleId, string apiPath);
        Task<int?> GetUserRoleIdAsync(int userId);
        Task<User> AuthenticateUserAsync(string username, string password);
        Task<bool> CheckUserPermissionAsync(int roleId, string apiPath);

    }
}
