using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services
{
    public class RoleService(IUnitOfWork unitOfWork) : IRoleService
    {
      public async Task<IEnumerable<Role>> GetAllRoles()
        {
            try
            {
                var roles =  await unitOfWork.Roles.GetAllAsync();
                return roles;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Role?> GetRoleById(int id)
        {
            try
            {
                var role = await unitOfWork.Roles.GetByIdAsync(id);
                return role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
      
        public async Task<Role> AddRole(Role role)
        {
            try
            {
                 await unitOfWork.Roles.AddAsync(role);
                await unitOfWork.CommitAsync();
                return role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

       public async Task<Role?> GetRoleByName(string roleName)
        {
            try
            {
                var role = await unitOfWork.Roles.GetRoleByName(roleName);
                return role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public async Task<bool> DeleteRole(int id)
        {
            try
            {
                var role = await unitOfWork.Roles.GetByIdAsync(id);
                if (role == null)
                {
                    return false;
                }
                unitOfWork.Roles.Remove(role);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
