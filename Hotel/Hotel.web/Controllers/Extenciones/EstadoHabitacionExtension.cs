using Hotel.Domain.Entities;
using Hotel.web.Models;
using Hotel.web.Models.Response.Estadohabitacion;
using Hotel.Infrastructure.Models;
using Hotel.Application.Dtos.EstadoHabitacion;

namespace Hotel.web.Controllers.Extenciones
{
    public static class EstadoHabitacionExtension
    {
        public static EstadohabitacionWModel ConvertModelToWebModel(this EstadoHabitacion estados)
        {
            return new EstadohabitacionWModel()
            {
                IdEstadoHabitacion = estados.IdEstadoHabitacion,
                Descripcion = estados.Descripcion
                
            };
        }
        public static EstadoHabitacion ConvertDtoUpdateToEntity(this EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {

            return new EstadoHabitacion()
            {
                Descripcion = estadoHabitacionUpdate.Descripcion,
                FechaModificacion = DateTime.Now,
                UsuarioModificacion =1,
                IdEstadoHabitacion = estadoHabitacionUpdate.IdEstadoHabitacion

            };

        }
    }
}
