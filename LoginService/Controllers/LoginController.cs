using LoginService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IRegister _register;
        private IConfiguration _configuration;
        private string[] SourceRoles = new[] { "Admin", "User" };
        public LoginController(IRegister register, IConfiguration configuration)
        {
            _register = register;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Post(string username, string password)
        {
            //your logic for login process
            bool loginValidate = (username == _register.UserName && password == _register.Password);
            //If login usrename and password are correct then proceed to generate token
            string token = string.Empty;
            if (loginValidate)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, username)
                };

                foreach (var role in SourceRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                  _configuration["Jwt:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

               token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            }
            return Ok(token);

        }
    }
}
