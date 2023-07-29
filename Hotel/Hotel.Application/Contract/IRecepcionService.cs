
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;

namespace Hotel.Application.Contract
{
    public interface IRecepcionService : IBaseService<RecepcionAddDto,
                                                       RecepcionUpdateDto,
                                                       RecepcionRemoveDto>
    {
    }
}
