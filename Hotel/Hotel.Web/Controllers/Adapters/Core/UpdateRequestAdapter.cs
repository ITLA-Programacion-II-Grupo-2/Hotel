using Hotel.Domain.Entities;
using Hotel.Web.Controllers.Adapters.Core.Interfaces;
using Hotel.Web.Models.Usuario.Request;

namespace Hotel.Web.Controllers.Adapters.Core
{
    public class UpdateRequestAdapter : IConvertAdapter<UsuarioUpdateRequest, object>
    {
        public UsuarioUpdateRequest Convert(dynamic usuario)
        {
            return new UsuarioUpdateRequest()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = usuario.IdRolUsuario
            };
        }
    }
}
