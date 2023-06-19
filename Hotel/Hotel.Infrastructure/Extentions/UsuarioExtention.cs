
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Models;

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
    }
}
