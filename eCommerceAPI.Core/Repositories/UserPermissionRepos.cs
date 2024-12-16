using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories
{
   public class UserPermissionRepos(DbContext context):Repository<UserPermission>(context) , IUserPermissionRepos
    {
        private DatabaseServerContext databaseContext => (DatabaseServerContext)Context;
       public async Task<List<UserPermissionDTO>?> GetAll()
        {
            return await databaseContext.UserPermissions.Select(p => new UserPermissionDTO
            {
                
                RoleId = p.RoleId,
                Permission = p.Permission
            }).ToListAsync();
        }

       public  List<string>? GetPermissionsByRole(int roleId)
        {
            return  databaseContext.UserPermissions.Where(r => r.RoleId == roleId).Select(p => p.Permission).ToList();
          
        }
      public async Task<UserPermission?> AddPermissionRole(UserPermission userPermission)
        {
           var _userPermission =   databaseContext.UserPermissions.Add(userPermission);
           await  databaseContext.SaveChangesAsync();
            return userPermission;
        }
       public async Task<UserPermission?> updatePermissionRole(UserPermission userPermission)
        {
            var _userPermission =  databaseContext.UserPermissions.Update(userPermission);
          await databaseContext.SaveChangesAsync();
            return userPermission;
        }
        public async Task<bool> RoleHasPermission(int roleId, string permission)
        {
            
            var hasPermission = await databaseContext.UserPermissions
                .AnyAsync(up => up.RoleId == roleId && up.Permission == permission);

            return hasPermission; 
        }
    }
}
