using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Dtos.Habitacion;
using Hotel.web.Models.Response.Estadohabitacion;
using Hotel.web.Models.Response.Habitacion;

namespace Hotel.web.Servicios_Api
{
    public interface IEstadohabitacionA
    {
        EstadoHabitacionDetailResponse GetEntity(int id);
        EstadohabitacionListReponse GetEntities();
        EstadoHabitacionUpdateResponse Update(EstadoHabitacionUpdateDto estadoHabitacionUpdateDto);
        EstadoHabitacionAddResponse Add(EstadoHabitacionAddDto estadoHabitacionAddDto);
    }
}
