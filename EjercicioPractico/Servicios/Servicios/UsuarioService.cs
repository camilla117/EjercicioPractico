using EjercicioPractico.DTOs;
using EjercicioPractico.Models;
using EjercicioPractico.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EjercicioPractico.Servicios.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _dbContext;

        public UsuarioService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuarios> GetUsuario(string searchText)
        {
            Usuarios usuario = await _dbContext.Usuarios.Where(e => e.Nombre == searchText).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<List<Usuarios>> GetUsuarios()
        {
            List<Usuarios> usuarios = await _dbContext.Usuarios.ToListAsync();

            return usuarios;
        }

        public async Task<Usuarios> RegistrarUsuarios(RegistrarUsuario usuario)
        {
            Usuarios user = usuario.Usuario;
            _dbContext.Usuarios.Add(user);
            await _dbContext.SaveChangesAsync();

            List<Roles> roles = usuario.Roles;

            roles.ForEach(element =>
            {
                element.UsuarioId = user.Id;
            });

            _dbContext.Roles.AddRange(roles);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
