
using Hotel.Application.Core;
using Hotel.Application.Dtos.RolUsuario;

namespace Hotel.Application.Contract
{
    public interface IRolUsuarioService : IBaseService<RolUsuarioAddDto,
                                                       RolUsuarioUpdateDto,
                                                       RolUsuarioRemoveDto>
    {
        ServiceResult GetRolUsuarios();
        ServiceResult GetUsuariosByRoles();
        ServiceResult GetUsuariosByRol(string rol);
    }
}
