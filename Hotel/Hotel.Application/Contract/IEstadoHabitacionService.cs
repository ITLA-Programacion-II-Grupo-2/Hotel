using Hotel.Application.Core;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Dtos.Habitacion;

namespace Hotel.Application.Contract
{
    public interface IEstadoHabitacionService : IBaseService<EstadoHabitacionAddDto,
                                                  EstadoHabitacionUpdateDto,
                                                  EstadoHabitacionRemoveDto>
    {
       
    }
}
