using Hotel.Application.Core;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Dtos.Habitacion;

namespace Hotel.Application.Contract
{
    public interface IEstadoHabitacionService 
    {
        ServiceResult GetEntities();
        ServiceResult Get(int Id);
        ServiceResult Add(EstadoHabitacionAddDto estadoHabitacionAdd);
        ServiceResult Update(EstadoHabitacionUpdateDto estadoHabitacionUpdate);
        ServiceResult Remove(EstadoHabitacionRemoveDto estadoHabitacionRemove);
    }
}
