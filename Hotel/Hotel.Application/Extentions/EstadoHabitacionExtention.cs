using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Domain.Entities;
using System.Collections.Generic;

namespace Hotel.Application.Extentions
{
    public static class EstadoHabitacionExtention
    {
        public static EstadoHabitacion ConvertDtoAddToEntity(this EstadoHabitacionAddDto estadoHabitacionAdd)
        {

            return new EstadoHabitacion()
            {
                Descripcion = estadoHabitacionAdd.Descripcion,
                FechaCreacion = estadoHabitacionAdd.CambioFecha,
                UsuarioCreacion = estadoHabitacionAdd.CambioUsuario
                
            };
      
        }

        public static EstadoHabitacion ConvertDtoUpdateToEntity(this EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {

            return new EstadoHabitacion()
            {
                Descripcion = estadoHabitacionUpdate.Descripcion,
                FechaModificacion = estadoHabitacionUpdate.CambioFecha,
                UsuarioModificacion = estadoHabitacionUpdate.CambioUsuario,
                IdEstadoHabitacion = estadoHabitacionUpdate.IdEstadoHabitacion

            };

        }
        public static EstadoHabitacion ConvertDtoRemoveToEntity(this EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {

            return new EstadoHabitacion()
            {
                IdEstadoHabitacion = estadoHabitacionRemove.IdEstadoHabitacion,
                Estado = estadoHabitacionRemove.Estado,
                FechaEliminacion = estadoHabitacionRemove.CambioFecha,
                UsuarioEliminacion = estadoHabitacionRemove.CambioUsuario

            };

        }
    }
}
