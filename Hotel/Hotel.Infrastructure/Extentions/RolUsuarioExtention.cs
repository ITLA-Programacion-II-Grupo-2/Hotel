
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Models;
using System;

namespace Hotel.Infrastructure.Extentions
{
    public static class RolUsuarioExtention
    {
        public static RolUsuarioModel ConvertRolUsuarioEntityToModel(this RolUsuario rolUsuario)
        {
            return new RolUsuarioModel(){
                IdRolUsuario = rolUsuario.IdRolUsuario,
                Rol = rolUsuario.Descripcion
            };
        }

        public static RolUsuario ConvertRolUsuarioCreateToEntity(this RolUsuario rolUsuario)
        {
            return new RolUsuario()
            {
                Descripcion = rolUsuario.Descripcion,
                UsuarioCreacion = rolUsuario.UsuarioCreacion
            };
        }

        public static RolUsuario ConvertRolUsuarioUpdateToEntity(this RolUsuario rolUsuarioToUpdate,
                                                                      RolUsuario rolUsuario )
        {
            rolUsuarioToUpdate.Descripcion = rolUsuario.Descripcion;
            rolUsuarioToUpdate.FechaModificacion = DateTime.Now;
            rolUsuarioToUpdate.UsuarioModificacion = rolUsuario.UsuarioModificacion;

            return rolUsuarioToUpdate;
        }

        public static RolUsuario ConvertRolUsuarioRemoveToEntity(this RolUsuario rolUsuarioToRemove, 
                                                                      RolUsuario rolUsuario)
        {
            rolUsuarioToRemove.Estado = false;
            rolUsuarioToRemove.FechaEliminacion = DateTime.Now;
            rolUsuarioToRemove.UsuarioEliminacion = rolUsuario.UsuarioEliminacion;

            return rolUsuarioToRemove;
        }
    }
}
