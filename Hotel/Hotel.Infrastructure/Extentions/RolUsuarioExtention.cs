
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Models;

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
    }
}
