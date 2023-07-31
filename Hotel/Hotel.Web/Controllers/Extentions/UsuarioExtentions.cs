using Hotel.Application.Dtos.Usuario;
using Hotel.Infrastructure.Models;
using Hotel.Web.Models.Usuario;
using Hotel.Web.Models.Usuario.Request;

namespace Hotel.Web.Controllers.Extentions
{
    public static class UsuarioExtentions
    {
        public static UsuarioWModel ConvertUserWithRolToUsuarioWModel(this UserWithRolModel usuario)
        {
            return new UsuarioWModel()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Rol= usuario.Rol
            };
        }
        public static UsuarioUpdateRequest ConvertUsuarioToUpdateRequest(this UsuarioWModel usuario)
        {
            return new UsuarioUpdateRequest()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = 1
            };
        }
        public static UsuarioAddDto ConvertAddRequestToAddDto(this UsuarioAddRequest usuarioAdd)
        {
            return new UsuarioAddDto()
            {
                NombreCompleto = usuarioAdd.NombreCompleto,
                Correo = usuarioAdd.Correo,
                Clave = usuarioAdd.Clave,
                IdRolUsuario = usuarioAdd.IdRolUsuario,
                ChangeUser = usuarioAdd.ChangeUser,
                ChangeDate = usuarioAdd.ChangeDate
            };
        }
        public static UsuarioUpdateRequest ConvertUsuarioToUpdateRequest(this UsuarioModel usuario)
        {
            return new UsuarioUpdateRequest()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = usuario.IdRolUsuario
            };
        }
        public static UsuarioUpdateDto ConvertUpdateRequestToUpdateDto(this UsuarioUpdateRequest usuarioUpdate)
        {
            return new UsuarioUpdateDto()
            {
                IdUsuario = usuarioUpdate.IdUsuario,
                NombreCompleto = usuarioUpdate.NombreCompleto,
                Correo = usuarioUpdate.Correo,
                IdRolUsuario = usuarioUpdate.IdRolUsuario,
                ChangeUser = usuarioUpdate.ChangeUser,
                ChangeDate = usuarioUpdate.ChangeDate
            };
        }

        public static UsuarioRemoveDto ConvertRemoveDtoToRemoveRequest(this UsuarioRemoveRequest usuarioRemove)
        {
            return new UsuarioRemoveDto()
            {
                IdUsuario = usuarioRemove.IdUsuario,
                ChangeUser = usuarioRemove.ChangeUser,
                ChangeDate = usuarioRemove.ChangeDate
            };
        }
    }
}
