using Hotel.Application.Core;
using Hotel.Application.Dtos.Habitacion;
using System.Xml;

namespace Hotel.Application.Contract
{
    public interface IHabitacionService : IBaseService<HabitacionAddDto,
                                                  HabitacionUpdateDto,
                                                  HabitacionRemoveDto>
    {
       
    }
}
