using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PaySharp.API.Models;
using PaySharp.API.Services.Contracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            this._config = config ?? throw new ArgumentNullException(nameof(config));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(login);
            }

            IActionResult response = Unauthorized();

            var user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJSONWebToken(UserLoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] 
            {
                     new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                     new Claim("userRole", userInfo.Role),
                     new Claim("userId", userInfo.UserId),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserLoginModel> AuthenticateUser(LoginModel login)
        {
            var user = await userService.GetLoginUserAsync(login.UserName, login.Password);

            return user;
        }
    }
}