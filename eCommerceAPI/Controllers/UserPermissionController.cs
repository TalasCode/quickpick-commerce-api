using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using eCommerceAPI.Service.Services;
using eCommerceAPI.Service.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController(IUserPermissionService userPermissionService , IMapper mapper) : Controller
    {
      
            [HttpGet("getAll")]
            public async Task<ActionResult> Get()
            {
                var ups = await userPermissionService.GetAll();

                return Ok(ups);
            }

        [HttpGet("getByRoleId/{id}")]
        public async Task<ActionResult> GetByRoleId(int id)
        {
            var ups = userPermissionService.getPermissionsByRoleId(id);

            return Ok(ups);
        }

        /* [HttpGet("getPermissions/{roleId}")]
         public Task<ActionResult getPermissionsByRoleId(int roleId)
         {
             var ups =  userPermissionService.getPermissionsByRoleId(roleId);
             return Ok(ups);
         }*/

        [HttpPost("add")]
        public async Task<ActionResult<UserPermissionRequest?>> Add(UserPermissionRequest userPermission)
        {
            if (userPermission == null || string.IsNullOrEmpty(userPermission.Permission))
            {
                return BadRequest("Please provide a valid Permission.");
            }
            var newUP = mapper.Map<UserPermission>(userPermission);
            await userPermissionService.AddUserPermission(newUP);

            return Ok(newUP);
        }

        [HttpDelete("delete/{id}")]

        public async Task<bool> Remove(int id)
        {
            var up = await userPermissionService.GetById(id);
            if (up == null)
            {
                BadRequest($"User Permission Id: {id} not Found");
                return false;
            }
            else
            {
                await userPermissionService.DeleteUserPermission(id);
                return true;
            }
        }
        [HttpGet("getById/{id}")]
        public async Task<UserPermission?> getById(int id)
        {
            var up = await userPermissionService.GetById(id);
            if (up == null)
            {
                BadRequest($"User Permission Id: {id} not Found");
                return null;
            }
            else
            {
                return up;
            }
        }
    }
}
