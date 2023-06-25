using Hotel.Application.Dtos.Habitacion;
using Hotel.Domain.Entities;


namespace Hotel.Application.Extentions
{
    public static class HabitacionExtention
    {
        public static Habitacion ConvertDtoAddToEntity(this HabitacionAddDto habitacionAdd)
        {
            return new Habitacion()
            {
                Numero = habitacionAdd.Numero,
                Detalle = habitacionAdd.Detalle,
                Precio = (decimal)habitacionAdd.Precio,
                IdEstadoHabitacion = (int)habitacionAdd.IdEstadoHabitacion,
                IdCategoria = (int)habitacionAdd.IdCategoria,
                IdPiso = (int)habitacionAdd.IdPiso,
                UsuarioCreacion = habitacionAdd.CambioUsuario,
                FechaCreacion = habitacionAdd.CambioFecha

            };
          
        }

        public static Habitacion ConvertDtoUpdateToEntity(this HabitacionUpdateDto habitacionUpdate)
        {
            return new Habitacion()
            {
                Numero = habitacionUpdate.Numero,
                Detalle = habitacionUpdate.Detalle,
                Precio = (decimal)habitacionUpdate.Precio,
                IdEstadoHabitacion = (int)habitacionUpdate.IdEstadoHabitacion,
                IdCategoria = (int)habitacionUpdate.IdCategoria,
                IdPiso = (int)habitacionUpdate.IdPiso,
                UsuarioCreacion = habitacionUpdate.CambioUsuario,
                FechaCreacion = habitacionUpdate.CambioFecha,
                IdHabitacion = habitacionUpdate.IdHabitacionId

            };

        }
        public static Habitacion ConvertDtoRemoveToEntity(this HabitacionRemoveDto habitacionRemove)
        {
            return new Habitacion()
            {
                IdHabitacion = habitacionRemove.IdHabitacion,
                Estado = habitacionRemove.Estado,
                FechaEliminacion = habitacionRemove.CambioFecha,
                UsuarioEliminacion = habitacionRemove.CambioUsuario

            };

        }
    }
}
