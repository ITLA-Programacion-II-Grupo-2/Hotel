using Hotel.Application.Dtos.Habitacion;
using Hotel.web.Models;
using Hotel.web.Models.Response.Habitacion;

namespace Hotel.web.Controllers.Extenciones
{
    public static class HabitacionExtencion
    {
        public static HabitacionReponse ConvertModelToResponse(this HabitacionModel habitacion)
        {
            return new HabitacionReponse()
            {
                IdHabitacion = habitacion.IdHabitacion,
                Numero = habitacion.Numero,
                Detalle = habitacion.Detalle,
                Precio = habitacion.Precio,
                IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                IdCategoria = habitacion.IdCategoria,
                IdPiso = habitacion.IdPiso
            };
        }
        public static HabitacionAddDto ConvertRequestToDto(this HabitacionAddReponse habitacionAdd)
        {
            return new HabitacionAddDto()
            {
                Numero = habitacionAdd.Numero,
                Detalle = habitacionAdd.Detalle,
                Precio = habitacionAdd.Precio,
                IdEstadoHabitacion = habitacionAdd.IdEstadoHabitacion,
                IdCategoria = habitacionAdd.IdCategoria,
                IdPiso = habitacionAdd.IdPiso,
                CambioUsuario = 1,
                CambioFecha = DateTime.Now
            };
        }
        public static HabitacionUpdateReponse ConvertModelToRequest(this HabitacionModel habitacion)
        {
            return new HabitacionUpdateReponse()
            {
                IdHabitacion = habitacion.IdHabitacion,
                Numero = habitacion.Numero,
                Detalle = habitacion.Detalle,
                Precio = habitacion.Precio,
                IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                IdCategoria = habitacion.IdCategoria,
                IdPiso = habitacion.IdPiso
            };



        }
    }
}
