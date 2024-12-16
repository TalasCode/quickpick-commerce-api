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
    public class RoleRepos(DbContext context) : Repository<Role>(context) , IRoleRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;
        public async Task<Role?> GetRoleByName(string roleName)
        {
            return await databaseServerContext.Roles.Where(r=> r.Name == roleName).FirstOrDefaultAsync();
        }
    }
}
