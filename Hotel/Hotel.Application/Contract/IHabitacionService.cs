using Hotel.Application.Core;
using Hotel.Application.Dtos.Habitacion;
using System.Xml;

namespace Hotel.Application.Contract
{
    public interface IHabitacionService 
    {
        ServiceResult GetEntities();
        ServiceResult Get(int Id);
        ServiceResult Add(HabitacionAddDto habitacionAdd );
        ServiceResult Update( HabitacionUpdateDto habitacionUpdate);
        ServiceResult Remove(HabitacionRemoveDto habitacionRemove);
    }
}
