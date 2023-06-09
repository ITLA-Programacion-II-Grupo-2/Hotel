
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;

namespace Hotel.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {   
        public UsuarioModel GetUsuario(int id);
        public List<UsuarioModel> GetUsuarios();
        public UserWithRolModel GetUsuarioWithRol(int id);
        public List<UserWithRolModel> GetUsuariosWithRol();
    }
}
