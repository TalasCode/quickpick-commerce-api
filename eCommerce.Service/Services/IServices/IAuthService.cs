using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services.IServices
{
    public interface IAuthService
    {
        Task<User> AuthenticateUserAsync(string username, string password);
        bool CheckUserPermission(int roleId, string requiredPermission);

    }
}
