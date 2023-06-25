using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Domain.Entities;


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
    }
}
