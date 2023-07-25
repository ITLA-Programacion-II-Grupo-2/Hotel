namespace Hotel.Web.Models.Usuario.Request
{
    public class UsuarioRequest : BaseRequest
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int IdRolUsuario { get; set; }

    }
}
