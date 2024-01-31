using EjercicioPractico.DTOs;
using EjercicioPractico.Models;
using EjercicioPractico.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EjercicioPractico.Servicios.Servicios
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _dbContext;
        public LoginService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuarios> Login(Login login)
        {
            Usuarios usuario = await _dbContext.Usuarios.Where(e => e.Usuario == login.Usuario && e.Password == e.Password)
                .FirstOrDefaultAsync();

            return usuario;
        }
    }
}
