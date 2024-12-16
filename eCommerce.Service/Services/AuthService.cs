using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using eCommerceAPI.Service.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services
{
  public class AuthService(IUnitOfWork unitOfWork): IAuthService
    {
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
        public bool CheckUserPermission(int roleId, string requiredPermission)
        {


            return unitOfWork.Auths.CheckUserPermission(roleId, requiredPermission);

        }
    }
}
