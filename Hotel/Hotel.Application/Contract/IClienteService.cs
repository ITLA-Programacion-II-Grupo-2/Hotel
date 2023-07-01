using Hotel.Application.Core;
using Hotel.Application.Dtos.Cliente;

namespace Hotel.Application.Contract
{
    public interface IClienteService : IBaseService<ClienteAddDto, ClienteUpdateDto, ClienteRemoveDto>
    {

        ServiceResult GetCliente(int id);
        ServiceResult GetClientes();
        ServiceResult Remove();


    }
}
