using eCommerce.Service.Services.IServices;
using eCommerceAPI.Service.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
namespace eCommerceAPI.Service.Attribute
{

    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public PermissionMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            if (endpoint == null)
            {
                await _next(context);
                return;

            }

            var metadata = endpoint.Metadata.GetMetadata<PermissionAttribute>();
            if (metadata == null)
            {
                await _next(context);
                return;
            }

            // Get the user's role ID from the context
            var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = await _userService.GetUserRoleByIdAsync(userId);

            // Check if the user's role has the required permission
            var hasPermission = await _userService.CheckUserPermissionAsync(role.Id, metadata.RequiredPermission);
            if (!hasPermission)
            {
                context.Response.StatusCode = 403;
                return;
            }

            await _next(context);
        }
    }
}