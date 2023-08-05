using Hotel.Application.Dtos.Habitacion;
using Hotel.web.Models.Response.Habitacion;

namespace Hotel.web.Servicios_Api
{
    public interface IHabitacionServiceA
    {
        HabitacionDetailReponse GetEntity(int id);
        HabitacionListReponse GetEntities();
        HabitacionUpdateReponse Update(HabitacionUpdateDto habitacionUpdate);
        HabitacionAddReponse Add(HabitacionAddDto habitacionAdd);
    }
}
