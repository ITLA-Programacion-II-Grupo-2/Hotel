using Hotel.Application.Dtos.RolUsuario;
using Hotel.Web.Models.RolUsuario.Request;
using RolUsuarioIModel = Hotel.Infrastructure.Models.RolUsuarioModel;
using RolUsuarioModel = Hotel.Web.Models.RolUsuario.RolUsuarioModel;

namespace Hotel.Web.Controllers.Extentions
{
    public static class RolUsuarioExtentions
    {
        public static RolUsuarioModel ConvertModelToWebModel(this RolUsuarioIModel rolUsuario)
        {
            return new RolUsuarioModel()
            {
                IdRolUsuario = rolUsuario.IdRolUsuario,
                Rol = rolUsuario.Rol
            };
        }

        public static RolUsuarioUpdateRequest ConvertModelToUpdateRequest(this RolUsuarioIModel rolUsuario)
        {
            return new RolUsuarioUpdateRequest()
            {
                IdRolUsuario = rolUsuario.IdRolUsuario,
                Descripcion = rolUsuario.Rol
            };
        }

        public static RolUsuarioUpdateRequest ConvertModelToUpdateRequest(this RolUsuarioModel rolUsuario)
        {
            return new RolUsuarioUpdateRequest()
            {
                IdRolUsuario = rolUsuario.IdRolUsuario,
                Descripcion = rolUsuario.Rol
            };
        }
        public static RolUsuarioAddDto ConvertAddRequestToDto(this RolUsuarioAddRequest rolUsuario)
        {
            return new RolUsuarioAddDto()
            {
                Descripcion = rolUsuario.Descripcion,
                ChangeUser = rolUsuario.ChangeUser,
                ChangeDate = rolUsuario.ChangeDate
            };
        }

        public static RolUsuarioUpdateDto ConvertUpdateRequestToDto(this RolUsuarioUpdateRequest rolUsuario)
        {
            return new RolUsuarioUpdateDto()
            {
                IdRolUsuario = rolUsuario.IdRolUsuario,
                Descripcion = rolUsuario.Descripcion,
                ChangeUser = rolUsuario.ChangeUser,
                ChangeDate = rolUsuario.ChangeDate
            };
        }
        public static RolUsuarioRemoveDto ConvertRemoveRequestToDto(this RolUsuarioRemoveRequest rolUsuario)
        {
            return new RolUsuarioRemoveDto()
            {
                IdRolUsuario = rolUsuario.IdRolUsuario,
                ChangeUser = rolUsuario.ChangeUser,
                ChangeDate = rolUsuario.ChangeDate
            };
        }
    }
}
