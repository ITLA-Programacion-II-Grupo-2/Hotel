using Hotel.Application.Dtos.Usuario;
using Hotel.Web.Controllers.Adapters.Core.Interfaces;
using Hotel.Web.Models.Usuario;

namespace Hotel.Web.Controllers.Adapters.Core
{
    public class UsuarioResponseAdapter : IConvertAdapter<UsuarioResponse, object>
    {
        public UsuarioResponse Convert(dynamic usuario)
        {
            return new UsuarioResponse()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                RolUsuario = usuario.Rol
            };
        }

    }
}
