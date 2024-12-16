using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IAuthRepos
    {
        Task<User> AuthenticateUserAsync(string username, string password);
        bool CheckUserPermission(int roleId, string apiPath);
       // Task<User> getUserById(int id);
    }
}
