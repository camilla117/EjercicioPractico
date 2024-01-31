using EjercicioPractico.DTOs;
using EjercicioPractico.Models;
using EjercicioPractico.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EjercicioPractico.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("authentication")]
        public async Task<object> Login(Login login) 
        {
            Usuarios usuario = await _loginService.Login(login);

            if(usuario == null)
            {
                return new
                {
                    statusCode = "400",
                    message = "Sus datos son incorrectos, verifique su información e intente nuevamente"
                };
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials:  credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {Token = tokenString});
        }
    }
}
