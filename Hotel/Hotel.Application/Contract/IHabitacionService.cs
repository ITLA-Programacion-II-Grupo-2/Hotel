using Hotel.Application.Core;
using Hotel.Application.Dtos.Habitacion;

namespace Hotel.Application.Contract
{
    internal interface IHabitacionService : IBaseService<HabitacionAddDto,
                                                  HabitacionUpdateDto,
                                                  HabitacionRemoveDto>
    {
    }
}
