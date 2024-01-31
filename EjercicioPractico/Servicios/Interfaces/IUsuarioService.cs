using EjercicioPractico.DTOs;
using EjercicioPractico.Models;

namespace EjercicioPractico.Servicios.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuarios> GetUsuario(string searchText);
        Task<List<Usuarios>> GetUsuarios();
        Task<Usuarios> RegistrarUsuarios(RegistrarUsuario usuario);
    }
}
