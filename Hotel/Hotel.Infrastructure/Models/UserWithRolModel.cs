
namespace Hotel.Infrastructure.Models
{
    public class UserWithRolModel
    {
        public int IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? Rol { get; set; }
    }
}
