using EjercicioPractico.DTOs;
using EjercicioPractico.Models;
using EjercicioPractico.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioPractico.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsuaiosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuaiosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize]
        [Route("GetUser")]
        public async Task<Usuarios> GetUser(string username)
        {
            Usuarios usuario = await _usuarioService.GetUsuario(username);

            return usuario;
        }

        [HttpGet]
        [Authorize]
        [Route("GetUsers")]
        public async Task<List<Usuarios>> GetUsers() 
        {
            List<Usuarios> usuarios = await _usuarioService.GetUsuarios();

            return usuarios;
        }

        [HttpPost]
        [Authorize]
        [Route("RegisterUserRole")]
        public async Task<object> RegisterUserRole(RegistrarUsuario usuario)
        {
            Usuarios user = await _usuarioService.RegistrarUsuarios(usuario);

            if(user.Id > 0)
            {
                return new
                {
                    statusCode = "200",
                    message = "Usuario registrado con exito"
                };
            }

            return new
            {
                statusCode = "400",
                message = "Verifica que tu informacion sea correcta"
            };
        }
    }
}
