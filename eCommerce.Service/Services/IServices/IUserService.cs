using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IUserService
    {
        Task<List<User>?> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<UserDTO?> GetUserByEmail(string email);
        Task<User?> GetUserByUsername(string username);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> AuthenticateUserAsync(string username, string password);
        Task<bool> CheckUserPermissionAsync(int roleId, string requiredPermission);
        Task<Role?> GetUserRoleByIdAsync(int userId);
    }
}
