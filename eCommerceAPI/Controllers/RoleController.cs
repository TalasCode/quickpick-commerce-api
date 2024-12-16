using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using eCommerceAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleService roleService , IMapper mapper) : Controller
    {
        [HttpGet("getAll")]
        public async Task<ActionResult> Get()
        {
            var roles = await roleService.GetAllRoles();

            return Ok(roles);
        }
        [HttpPost("add")]
        public async Task<ActionResult<Role?>> Add(RoleRequest roleRequest)
        {
            if (roleRequest == null || string.IsNullOrEmpty(roleRequest.Name))
            {
                return BadRequest("Please provide a valid Role.");
            }
            var existingRole = await roleService.GetRoleByName(roleRequest.Name);
            if (existingRole != null)

            {
                return BadRequest($" {roleService.GetRoleByName(roleRequest.Name).Result}The Role '{roleRequest.Name}' is already exist.");
            }

            var newRole = mapper.Map<Role>(roleRequest);
            await roleService.AddRole(newRole);

            return Ok(newRole);
        }
        [HttpDelete("delete/{id}")]
      
        public async Task<bool> Remove(int id)
        {
            var role = await roleService.GetRoleById(id);
            if (role == null)
            {
                BadRequest($"Role Id: {id} not Found");
                return false;
            }
            else
            {
                await roleService.DeleteRole(id);
                return true;
            }
        }
        [HttpGet("getById/{id}")]
        public async Task<Role?> getById(int id)
        {
            var role = await roleService.GetRoleById(id);
            if (role == null)
            {
                BadRequest($"Role Id: {id} not Found");
                return null;
            }
            else
            {
                return role;

            }
        }
    }
}
