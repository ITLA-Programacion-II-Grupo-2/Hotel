using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.web.Models.Response.Estadohabitacion;

namespace Hotel.web.Servicios_Http
{
    public interface IEstadoHabitacionService
    {
        
            EstadoHabitacionDetailResponse GetEntity(int id);
            EstadohabitacionListReponse GetEntities();
            EstadoHabitacionUpdateResponse Update(EstadoHabitacionUpdateDto estadoHabitacionUpdate);
            EstadoHabitacionAddResponse Add(EstadoHabitacionAddDto estadoHabitacionAdd);

        
    }
}
