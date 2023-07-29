
using Hotel.Application.Dtos.Recepcion;
using Hotel.Domain.Entities;

namespace Hotel.Application.Extentions
{
    public static class RecepcionSvcExtention
    {
        public static Recepcion ConvertAddDtoToEntity(this RecepcionAddDto recepcion)
        {
            return new Recepcion()
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
                UsuarioCreacion = recepcion.ChangeUser
            };
        }

        public static Recepcion ConvertUpdateDtoToEntity(this RecepcionUpdateDto recepcion)
        {
            return new Recepcion()
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
                UsuarioModificacion = recepcion.ChangeUser,
                FechaModificacion = recepcion.ChangeDate
            };
        }

        public static Recepcion ConvertRemoveDtoToEntity(this RecepcionRemoveDto recepcion)
        {
            return new Recepcion()
            {
                IdRecepcion = recepcion.IdRecepcion,
                UsuarioEliminacion = recepcion.ChangeUser,
                FechaEliminacion = recepcion.ChangeDate
            };
        }
    }
}
