using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;

namespace Hotel.Infrastructure.Interfaces
{
    public interface IRolUsuarioRepository : IBaseRepository<RolUsuario>
    {
        List<RolUsuarioModel> GetRolUsuarios();
        List<UserWithRolModel> GetUsuariosByRoles();
        List<UserWithRolModel> GetUsuariosByRol(string rol);
    }
}
