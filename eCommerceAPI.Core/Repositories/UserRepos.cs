using eCommerceAPI.Core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
namespace eCommerceAPI.Core.Repositories
{
    public class UserRepos(DbContext context) : Repository<User>(context) , IUserRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;

        //public async Task<List<UserDTO>?> GetAll()
        //{
        //    return await databaseServerContext.Users.Select(u => new UserDTO
        //    {
        //        Id = u.Id,
        //        Username = u.Username,
        //        Email = u.Email,
        //        PasswordHash = u.PasswordHash,
        //        StreetAddress = u.StreetAddress,
        //        City = u.City,
        //        State = u.State,
        //        PostalCode = u.PostalCode,
        //        Country = u.Country,
        //        RoleId = u.RoleId

        //    }).ToListAsync();
            
        //}

        public async Task<List<User>?> GetAll()
        {
            return await databaseServerContext.Users.Include(u=> u.Carts).Include(u=> u.Role).ToListAsync();
        }
        public async Task<UserDTO?> GetUserByEmail(string email)
        {
            return await databaseServerContext.Users.Where(u => u.Email == email)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    PasswordHash = u.PasswordHash,
                    StreetAddress = u.StreetAddress,
                    City = u.City,
                    State = u.State,
                    PostalCode = u.PostalCode,
                    Country = u.Country,
                    RoleId = u.RoleId

                }).FirstOrDefaultAsync();
        }
        public async Task<User?> GetUserByUsername(string username)
        {
            return await databaseServerContext.Users.Where(u => u.Username == username)
                .Include(u => u.Carts).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = await databaseServerContext.Users.Where(u=> u.Username == username).FirstOrDefaultAsync();
            if (user != null && user.PasswordHash == password)
            
               return user;
            
            else
            {
                Console.WriteLine($"Username or/and Password Incorrect !");
                return null;
            }
            
        }
        public async Task<bool> RoleHasPermission(int roleId, string apiPath)
        {
            return await databaseServerContext.UserPermissions
                .AnyAsync(up => up.RoleId == roleId && apiPath.Contains(up.Permission));
        }
        public async Task<int?> GetUserRoleIdAsync(int userId)
        {
            var user = await databaseServerContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user?.RoleId;
        }
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await databaseServerContext.Users
                .Include(u => u.Role) // Include role if needed for claims
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password); // Note: Password should be hashed in a real app

            return user;
        }
        public async Task<bool> CheckUserPermissionAsync(int roleId, string apiPath)
        {
            var Permission = await databaseServerContext.UserPermissions
                .Where(r => r.RoleId == roleId && apiPath.StartsWith(r.Permission))
                .FirstOrDefaultAsync();

            return Permission != null;
        }


    }
}
