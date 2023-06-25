using Hotel.Application.Core;
using Hotel.Application.Dtos.Cliente;
using System.Collections.Generic;

namespace Hotel.Application.Contract
{
    public interface IClienteService : IBaseService<ClienteAddDto, ClienteUpdateDto, ClienteRemoveDto>
    {

        ServiceResult GetUsuario(int id);
        ServiceResult GetUsuarios();
        ServiceResult GetUsuarioWithRol(int id);
        ServiceResult GetUsuariosWithRol();
    }
}
