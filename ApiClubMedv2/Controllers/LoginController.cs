using Microsoft.AspNetCore.Authorization;
using ApiClubMedv2.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiClubMedv2.Models.Repository;
using ApiClubMedv2.Models;

namespace JwtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDataRepositoryUser<Client> _dataRepository;
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config, IDataRepositoryUser<Client> dataRepository)
        {
            _config = config;
            _dataRepository = dataRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User userInfo)
        {
            IActionResult response = Unauthorized();
            ActionResult<Client> user = AuthenticateUser(userInfo);
            if (user.Value != null)
            {
                var tokenString = GenerateJwtToken(user.Value);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user.Value,
                });
            }
            return response;
        }

        private ActionResult<Client> AuthenticateUser(User user)
        {
            return _dataRepository.GetAutenticateUser(user.Email, user.Password);
        }

        private string GenerateJwtToken(Client userInfo)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _config["Jwt:SecretKey"]));
            
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.GenreClient),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.NomClient),
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
