
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Models;
using System;

namespace Hotel.Infrastructure.Extentions
{
    public static class UsuarioExtention
    {
        public static UsuarioModel ConvertUsuarioEntityToModel(this Usuario usuario)
        {
            return new UsuarioModel()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo
            };
        }

        public static UserWithRolModel ConvertUsuarioWithRolToModel(this Usuario usuario, RolUsuario rol) 
        {
            return new UserWithRolModel()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Rol = rol.Descripcion
            };
        }

        public static Usuario ConvertUsuarioCreateToEntity(this Usuario usuario)
        {
            return new Usuario()
            {
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdRolUsuario,
            };
        }

        public static Usuario ConvertUsuarioUpdateToEntity(this Usuario usuarioToUpdate,
                                                                Usuario usuario)
        {
            usuarioToUpdate.NombreCompleto = usuario.NombreCompleto;
            usuarioToUpdate.Correo = usuario.Correo;
            usuarioToUpdate.Clave = usuario.Clave;
            usuarioToUpdate.IdRolUsuario = usuario.IdRolUsuario;
            usuarioToUpdate.FechaModificacion = DateTime.Now;
            usuarioToUpdate.UsuarioModificacion = usuario.UsuarioModificacion;

            return usuarioToUpdate; 
        }

        public static Usuario ConvertUsuarioRemoveToEntity(this Usuario usuarioToRemove, 
                                                                Usuario usuario)
        {
            usuarioToRemove.Estado = false;
            usuarioToRemove.FechaEliminacion = DateTime.Now;
            usuarioToRemove.UsuarioEliminacion = usuario.UsuarioEliminacion;

            return usuarioToRemove;
        }
    }
}
