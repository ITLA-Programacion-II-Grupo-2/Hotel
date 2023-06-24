
namespace Hotel.Application.Dtos.Usuario
{
    public abstract class UsuarioDto : DtoBase
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public int IdRolUsuario { get; set; }
    }
}
