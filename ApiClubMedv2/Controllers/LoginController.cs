using APIClubMed.Models;
using ApiClubMedv2.Models;
using ApiClubMedv2.Models.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private List<User> appUsers = new List<User>
        {
            new User {
                NomUser = "COUTURIER",
                Email = "vcout@gmail.com",
                Password = "1234",
                UserRole = "User"
            },
            new User {
                NomUser = "DAMAS",
                Email = "ldamas@gmail.com",
                Password = "1234",
                UserRole = "Admin"
            },
        };

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            User user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }

        private User AuthenticateUser(User user)
        {
            PasswordHasher pH = new PasswordHasher();
            return appUsers.SingleOrDefault(x => x.Email.ToUpper() == user.Email.ToUpper() &&
            pH.Validate(user.Password, x.Password));
        }

        private string GenerateJwtToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _config["Jwt:SecretKey"]));
            
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.NomUser),
                new Claim("email", userInfo.Email.ToString()),
                new Claim("role",userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
