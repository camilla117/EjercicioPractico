using EjercicioPractico.DTOs;
using EjercicioPractico.Models;

namespace EjercicioPractico.Servicios.Interfaces
{
    public interface ILoginService
    {
        Task<Usuarios> Login(Login login);
    }
}
