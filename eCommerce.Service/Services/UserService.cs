using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        public async Task<List<User>?> GetAllUsers()
        {
            try
            {
                var users = await unitOfWork.Users.GetAll();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<User?> GetUserById(int id)
        {
            try
            {
                var user = await unitOfWork.Users.GetByIdAsync(id);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<UserDTO?> GetUserByEmail(string email)
        {
            try
            {
                var user = await unitOfWork.Users.GetUserByEmail(email);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<User?> GetUserByUsername(string username)
        {
            try
            {
                var user = await unitOfWork.Users.GetUserByUsername(username);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                await unitOfWork.Users.AddAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<User> UpdateUser(User user)
        {
            try
            {

                await unitOfWork.Users.UpdateAsync(user);
                await unitOfWork.CommitAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return false;
                }
                unitOfWork.Users.Remove(user);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                return await unitOfWork.Users.AuthenticateUserAsync(username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> CheckUserPermissionAsync(int roleId, string requiredPermission)
        {
            

            return await unitOfWork.Users.CheckUserPermissionAsync(roleId, requiredPermission);

        }
        public async Task<Role?> GetUserRoleByIdAsync(int userId)
        {
            // Implement logic to retrieve the user's role based on the user ID
            // For example:

            var user = await unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            return await unitOfWork.Roles.GetByIdAsync(user.RoleId.Value);
        }
    }
}
