using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerceAPI.Core.Repositories
{
    public class AuthRepos : IAuthRepos
    {
        private readonly DatabaseServerContext _databaseServerContext;

        public AuthRepos(DatabaseServerContext databaseServerContext)
        {
            _databaseServerContext = databaseServerContext;
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _databaseServerContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);

            return user;
        }

        public bool CheckUserPermission(int roleId, string apiPath)
        {
            var role = _databaseServerContext.Roles
                .Include(r => r.UserPermissions)
                .FirstOrDefault(r => r.Id == roleId);

            if (role != null && role.UserPermissions.Any(p => p.Permission == apiPath))
            {
                return true;
            }

            return false;
        }
    }
}