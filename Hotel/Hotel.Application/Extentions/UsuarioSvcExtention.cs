
using Hotel.Application.Dtos.Usuario;
using Hotel.Domain.Entities;

namespace Hotel.Application.Extentions
{
    public static class UsuarioExtention
    {
        public static Usuario ConvertAddDtoToEntity(this UsuarioAddDto usuarioAddDto)
        {
            return new Usuario()
            {
                NombreCompleto = usuarioAddDto.NombreCompleto,
                Correo = usuarioAddDto.Correo,
                Clave = usuarioAddDto.Clave,
                IdRolUsuario = usuarioAddDto.IdRolUsuario,
                UsuarioCreacion = 1,
                FechaCreacion = usuarioAddDto.ChangeDate
            };
        }
        public static Usuario ConvertUpdateDtoToEntity(this UsuarioUpdateDto usuarioUpdateDto)
        {
            return new Usuario()
            {
                IdUsuario = usuarioUpdateDto.IdUsuario,
                NombreCompleto = usuarioUpdateDto.NombreCompleto,
                Correo = usuarioUpdateDto.Correo,
                Clave = usuarioUpdateDto.Clave,
                IdRolUsuario = usuarioUpdateDto.IdRolUsuario,
                UsuarioModificacion = usuarioUpdateDto.ChangeUser,
                FechaModificacion = usuarioUpdateDto.ChangeDate
            };
        }

        public static Usuario ConvertRemoveDtoToEntity(this UsuarioRemoveDto usuarioRemoveDto)
        {
            return new Usuario()
            {
                IdUsuario = usuarioRemoveDto.IdUsuario,
                UsuarioModificacion = usuarioRemoveDto.ChangeUser,
                FechaModificacion = usuarioRemoveDto.ChangeDate
            };
        }
    }
}
