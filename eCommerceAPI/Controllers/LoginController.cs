using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;
using eCommerceAPI.Service.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class LoginController(IAuthService authService , IConfiguration _configuration) : ControllerBase
    {
        //private readonly IUserService _userService;
        //private readonly IConfiguration _configuration;

        //public LoginController(IUserService userService, IConfiguration configuration)
        //{
        //    _userService = userService;
        //    _configuration = configuration;
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequests model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Validate model state

            var user = await authService.AuthenticateUserAsync(model.Username, model.Password);
            if (user == null)
                return Unauthorized(); // 401 Unauthorized

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token }); // Return token in response
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.RoleId.ToString()), // Include UserId
        //new Claim("RoleId", user.RoleId.ToString()) // Include RoleId
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Set expiration time
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token); // Convert token to string
        }
    }
}