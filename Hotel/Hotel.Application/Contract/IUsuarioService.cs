
using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;
using System.Collections.Generic;

namespace Hotel.Application.Contract
{
    public interface IUsuarioService : IBaseService<UsuarioAddDto,
                                                    UsuarioUpdateDto,
                                                    UsuarioRemoveDto>
    {
        ServiceResult GetUsuarioWithRol(int id);
        ServiceResult GetUsuariosWithRol();
    }
}
