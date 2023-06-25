
using Hotel.Application.Dtos.RolUsuario;
using Hotel.Domain.Entities;

namespace Hotel.Application.Extentions
{
    public static class RolUsuarioExtention
    {
        public static RolUsuario ConvertAddDtoToEntity(this RolUsuarioAddDto rolUsuarioAddDto) 
        {
            return new RolUsuario()
            {
                Descripcion = rolUsuarioAddDto.Descripcion,
                UsuarioCreacion = rolUsuarioAddDto.ChangeUser,
                FechaCreacion = rolUsuarioAddDto.ChangeDate
            };
        }

        public static RolUsuario ConvertUpdateDtoEntity(this RolUsuarioUpdateDto rolUsuarioUpdateDto)
        {
            return new RolUsuario()
            {
                IdRolUsuario = rolUsuarioUpdateDto.IdRolUsuario,
                Descripcion = rolUsuarioUpdateDto.Descripcion,
                UsuarioModificacion = rolUsuarioUpdateDto.ChangeUser,
                FechaModificacion = rolUsuarioUpdateDto.ChangeDate
            };
        }

        public static RolUsuario ConvertRemoveEntity(this RolUsuarioRemoveDto rolUsuarioRemoveDto)
        {
            return new RolUsuario()
            {
                IdRolUsuario = rolUsuarioRemoveDto.IdRolUsuario,
                UsuarioEliminacion = rolUsuarioRemoveDto.ChangeUser,
                FechaEliminacion = rolUsuarioRemoveDto.ChangeDate
            };
        }
    }
}
