using Hotel.Infrastructure.Models;

namespace Hotel.Web.Models.Usuario.Request
{
    public class UsuarioAddRequest : UsuarioRequest
    {
        public string? Clave { get; set; }
        public IEnumerable<RolUsuarioModel>? Roles { get; set; }
    }
}
