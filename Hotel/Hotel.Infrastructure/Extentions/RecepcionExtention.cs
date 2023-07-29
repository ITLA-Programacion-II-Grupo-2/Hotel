
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Models;
using System;

namespace Hotel.Infrastructure.Extentions
{
    public static class RecepcionExtention
    {
        public static RecepcionModel ConvertRecepcionToModel(this Recepcion recepcion)
        {
            return new RecepcionModel()
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
        public static Recepcion ConvertRecepcionCreateToEntity(this Recepcion recepcion)
        {
            return new Recepcion(){
                IdCliente = recepcion.IdCliente,
                IdHabitacion = recepcion.IdHabitacion,
                Observacion = recepcion.Observacion,
                FechaEntrada =  recepcion.FechaEntrada,
                FechaSalida = recepcion.FechaSalida,
                FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion,
                PrecioInicial = recepcion.PrecioInicial,
                Adelanto = recepcion.Adelanto,
                PrecioRestante = recepcion.PrecioRestante,
                TotalPagado = recepcion.TotalPagado,
                CostoPenalidad = recepcion.CostoPenalidad,
                UsuarioCreacion = recepcion.UsuarioCreacion
            };
        }
        public static Recepcion ConvertRecepcionUpdateToEntity(this Recepcion recepcionToUpdate, Recepcion recepcion)
        {
            recepcionToUpdate.IdCliente = recepcion.IdCliente;
            recepcionToUpdate.IdHabitacion = recepcion.IdHabitacion;
            recepcionToUpdate.Observacion = recepcion.Observacion;
            recepcionToUpdate.FechaEntrada = recepcion.FechaEntrada;
            recepcionToUpdate.FechaSalida = recepcion.FechaSalida;
            recepcionToUpdate.FechaSalidaConfirmacion = recepcion.FechaSalidaConfirmacion;
            recepcionToUpdate.PrecioInicial = recepcion.PrecioInicial;
            recepcionToUpdate.Adelanto = recepcion.Adelanto;
            recepcionToUpdate.PrecioRestante = recepcion.PrecioRestante;
            recepcionToUpdate.TotalPagado = recepcion.TotalPagado;
            recepcionToUpdate.CostoPenalidad = recepcion.CostoPenalidad;
            recepcionToUpdate.UsuarioModificacion = recepcion.UsuarioModificacion;
            recepcionToUpdate.FechaModificacion = recepcion.FechaModificacion;

            return recepcionToUpdate;
        }
        public static Recepcion ConvertRecepcionRemoveToEntity(this Recepcion recepcionToRemove, Recepcion recepcion)
        {
            recepcionToRemove.Estado = false;
            recepcionToRemove.UsuarioEliminacion = recepcion.UsuarioEliminacion;
            recepcionToRemove.FechaEliminacion = recepcion.FechaEliminacion;

            return recepcionToRemove;
        }
    }
}
