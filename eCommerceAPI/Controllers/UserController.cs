using AutoMapper;
using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class UserController(IUserService userService, IMapper mapper) : Controller
    {
        [HttpGet("getAll")]
        public async Task<ActionResult> Get()
        {
            var users = await userService.GetAllUsers();

            return Ok(users);
        }
        [HttpGet("getByUsername/{username}")]
        public async Task<ActionResult> GetByUsername(string username)
        {
            var user = await userService.GetUserByUsername(username);

            return Ok(user);
        }
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var user = await userService.GetUserById(id);

            return Ok(user);
        }
        [HttpPost("add")]
        public async Task<ActionResult<User?>> CreateUser(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest("Please provide a valid user.");
            }


            var newUser = mapper.Map<User>(userRequest);
            await userService.AddUser(newUser);

            return Ok(newUser);
        }
        [HttpDelete("delete/{id}")]
        public async Task<bool> RemoveUser(int id)
        {
            var user = await userService.GetUserById(id);
            if (user == null)
            {
                BadRequest($"user Id: {id} not Found");
                return false;
            }
            else
            {
                await userService.DeleteUser(id);
                return true;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, UserRequest userRequest)
        {


            var user = mapper.Map<User>(userRequest);
            user.Id = id;
            var updatedUser = await userService.UpdateUser(user);
            if (updatedUser != null)
            {
                return Ok(updatedUser);
            }
            else
            {
                return NotFound("User not found");
            }


        }

    }
}
