using Hotel.Application.Dtos.Usuario;
using Hotel.Web.Controllers.Adapters.Core.Interfaces;
using Hotel.Web.Models.Usuario.Request;

namespace Hotel.Web.Controllers.Adapters.Core
{
    public class UsuarioAddDtoAdapter : IConvertAdapter<UsuarioAddDto, UsuarioAddRequest>
    {
        public UsuarioAddDto Convert(UsuarioAddRequest usuarioAdd)
        {
            return new UsuarioAddDto()
            {
                NombreCompleto = usuarioAdd.NombreCompleto,
                Correo = usuarioAdd.Correo,
                Clave = usuarioAdd.Clave,
                IdRolUsuario = usuarioAdd.IdRolUsuario,
                ChangeUser = 1,
                ChangeDate = DateTime.Now
            };
        }
    }
}
