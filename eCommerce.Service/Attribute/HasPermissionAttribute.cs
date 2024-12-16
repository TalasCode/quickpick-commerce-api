using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Attribute
{
    using eCommerceAPI.Core.Repositories.IRepositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Linq;
    using System.Security.Claims;

    public class HasPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _permission;
        private readonly IUnitOfWork _unitOfWork;

        public HasPermissionAttribute(string permission , IUnitOfWork unitOfWork)
        {
            _permission = permission;
            _unitOfWork = unitOfWork;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User as ClaimsPrincipal;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
                return;
            }

            var roleId = user.Claims.FirstOrDefault(c => c.Type == "roleId")?.Value;
            if (roleId == null)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
                return;
            }

            // Fetch permissions for the role from the database
            var permissions = GetPermissionsForRole(int.Parse(roleId));
            if (!permissions.Contains(_permission))
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
            }
        }

        private List<string> GetPermissionsForRole(int roleId)
        {
            return _unitOfWork.UserPermissions.GetPermissionsByRole(roleId);
            
        }
    }


}
