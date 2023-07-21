namespace Hotel.Web.Models.Usuario
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? RolUsuario { get; set; }
    }
}
