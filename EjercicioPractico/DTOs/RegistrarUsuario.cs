using EjercicioPractico.Models;

namespace EjercicioPractico.DTOs
{
    public class RegistrarUsuario
    {
        public string? Tenant { get; set; }
        public string? Metadata { get; set; }
        public List<Roles> Roles { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
