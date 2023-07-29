using Hotel.Application.Dtos.Recepcion;
using Hotel.Infrastructure.Models;
using Hotel.Web.Models.Recepcion;
using Hotel.Web.Models.Recepcion.Request;

namespace Hotel.Web.Controllers.Extentions
{
    public static class RecepcionExtentions
    {
        public static RecepcionResponse ConvertModelToResponse(this RecepcionModel recepcion)
        {
            return new RecepcionResponse()
            {
                IdRecepcion = recepcion.IdRecepcion,
                IdCliente = recepcion.IdCliente,
                IdHabitacion = recepcion.IdHabitacion,
                Observacion = recepcion.Observacion,
                FechaEntrada = recepcion.FechaEntrada,
                FechaSalida = recepcion.FechaSalida,
                FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                PrecioInicial = recepcion.PrecioInicial,
                Adelanto = recepcion.Adelanto,
                PrecioRestante = recepcion.PrecioRestante,
                TotalPagado = recepcion.TotalPagado,
                CostoPenalidad = recepcion.CostoPenalidad
            };
        }

        public static RecepcionAddDto ConvertRequestToDto(this RecepcionAddRequest recepcion)
        {
            return new RecepcionAddDto()
            {
                IdCliente = recepcion.IdCliente,
                IdHabitacion = recepcion.IdHabitacion,
                Observacion = recepcion.Observacion,
                FechaEntrada = recepcion.FechaEntrada,
                FechaSalida = recepcion.FechaSalida,
                FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                PrecioInicial = recepcion.PrecioInicial,
                Adelanto = recepcion.Adelanto,
                PrecioRestante = recepcion.PrecioRestante,
                TotalPagado = recepcion.TotalPagado,
                CostoPenalidad = recepcion.CostoPenalidad,
                ChangeUser = recepcion.ChangeUser,
                ChangeDate = recepcion.ChangeDate
            };
        }
        public static RecepcionUpdateDto ConvertRequestToDto(this RecepcionUpdateRequest recepcion)
        {
            return new RecepcionUpdateDto()
            {
                IdRecepcion = recepcion.IdRecepcion,
                IdCliente = recepcion.IdCliente,
                IdHabitacion = recepcion.IdHabitacion,
                Observacion = recepcion.Observacion,
                FechaEntrada = recepcion.FechaEntrada,
                FechaSalida = recepcion.FechaSalida,
                FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                PrecioInicial = recepcion.PrecioInicial,
                Adelanto = recepcion.Adelanto,
                PrecioRestante = recepcion.PrecioRestante,
                TotalPagado = recepcion.TotalPagado,
                CostoPenalidad = recepcion.CostoPenalidad,
                ChangeUser = recepcion.ChangeUser,
                ChangeDate = recepcion.ChangeDate
            };
        }
        public static RecepcionUpdateRequest ConvertModelToRequest(this RecepcionModel recepcion)
        {
            return new RecepcionUpdateRequest()
            {
                IdRecepcion = recepcion.IdRecepcion,
                IdCliente = recepcion.IdCliente,
                IdHabitacion = recepcion.IdHabitacion,
                Observacion = recepcion.Observacion,
                FechaEntrada = recepcion.FechaEntrada,
                FechaSalida = recepcion.FechaSalida,
                FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                PrecioInicial = recepcion.PrecioInicial,
                Adelanto = recepcion.Adelanto,
                PrecioRestante = recepcion.PrecioRestante,
                TotalPagado = recepcion.TotalPagado,
                CostoPenalidad = recepcion.CostoPenalidad
            };
        }

        public static RecepcionRemoveDto ConvertRequestToDto(this RecepcionRemoveRequest recepcion)
        {
            return new RecepcionRemoveDto()
            {
                IdRecepcion = recepcion.IdRecepcion,
                ChangeUser = recepcion.ChangeUser,
                ChangeDate = recepcion.ChangeDate
            };
        }

    }
}
