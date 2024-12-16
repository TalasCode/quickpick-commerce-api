using eCommerceAPI.Core.DTO;
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
    public class UserPermissionService(IUnitOfWork unitOfWork) : IUserPermissionService
    {
        public async Task<List<UserPermissionDTO>?> GetAll()
        {
            try
            {
                var up = await unitOfWork.UserPermissions.GetAll();
                return up;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<UserPermission?> GetById(int id)
        {
            try
            {
                return await unitOfWork.UserPermissions.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<UserPermission?> AddUserPermission(UserPermission userPermission)
        {
            try
            {
                if (userPermission != null)
                {
                    await unitOfWork.UserPermissions.AddAsync(userPermission);
                    await unitOfWork.CommitAsync();
                    return userPermission;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteUserPermission(int id)
        {
            try
            {
                UserPermission? existingUP = await unitOfWork.UserPermissions.GetByIdAsync(id);
                if (existingUP == null)
                {
                    return false;
                }
                unitOfWork.UserPermissions.Remove(existingUP);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
       public  List<string> getPermissionsByRoleId(int roleId)
        {
            try
            {
                return unitOfWork.UserPermissions.GetPermissionsByRole(roleId);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
