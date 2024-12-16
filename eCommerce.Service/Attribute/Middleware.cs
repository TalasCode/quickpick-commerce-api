using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using eCommerceAPI.Service.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Attribute
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        //private readonly IUserService _userService;
     //   private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public Middleware(RequestDelegate next,IConfiguration configuration)
        {
            _next = next;
           // _userService = userService;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context , IUserService _userService)
        {
            Console.WriteLine($"Hello from Middleware , {context.Request.Path}");

            if (context.Request.Path.Equals("/api/Login/login", StringComparison.OrdinalIgnoreCase) || context.Request.Path.Equals("/api/UserPermission/getByRoleId", StringComparison.OrdinalIgnoreCase) || context.Request.Path.Equals("/api/User/getByUsername", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

           // var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

            //if (endpoint == null)
            //{
            //    await _next(context);
            //    Console.WriteLine("Hello from endpoint null");
            //    return;
            //}

            //var metadata = endpoint.Metadata.GetMetadata<PermissionAttribute>();

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401; // Unauthorized
                return;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            }, out var validatedToken);

            var roleIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Console.WriteLine($"Hello from RoleId {roleIdClaim}");

            if (roleIdClaim != null && int.TryParse(roleIdClaim, out var roleId))
            {
                //var role = await _userService.GetUserRoleByIdAsync(userId);
                Console.WriteLine($"Hello from tryParse {roleId} {context.Request.Path}");


                var hasPermission = await _userService.CheckUserPermissionAsync(roleId, context.Request.Path);

                if (!hasPermission)
                {
                    Console.WriteLine($"Hello from hasPermission");
                    context.Response.StatusCode = 403; // Forbidden
                    return;
                }
                else
                {
                    await _next(context);
                }
            }
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
                return;
            }

            //await _next(context);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}