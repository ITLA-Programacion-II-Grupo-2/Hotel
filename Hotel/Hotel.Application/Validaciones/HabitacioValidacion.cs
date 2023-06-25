using Hotel.Application.Core;
using Hotel.Application.Dtos.Habitacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Validaciones
{
    public static class HabitacioValidacion
    {
        public static ServiceResult ValidateIdHabitacion(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"El id Del EstadoHabitacion Es invalido. id: {id}";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateHabitacionoAdd(this HabitacionAddDto habitacionAdd)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(habitacionAdd.Numero))
            {
                result.Message = "El Campo Es Requirido.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(habitacionAdd.Detalle))
            {
                result.Message = "El Campo Es Requirido";
                result.Success = false;
                return result;
            }

            if (!habitacionAdd.Precio.HasValue)
            {
                result.Message = "El Campo de Precio No Puede Ser Cero .";
                result.Success = false;
                return result;
            }

            if (!habitacionAdd.IdEstadoHabitacion.HasValue)
            {
                result.Message = "El Campo de IdEstadoHabitacion No Puede Ser Cero .";
                result.Success = false;
                return result;
            }

            if (!habitacionAdd.IdCategoria.HasValue)
            {
                result.Message = "El Campo de IdCategoria No Puede Ser Cero ";
                result.Success = false;
                return result;
            }

            if (!habitacionAdd.IdPiso.HasValue)
            {
                result.Message = "El Campo de IdPiso No Puede Ser Cero ";
                result.Success = false;
                return result;
            }
            return result;
        }

        public static ServiceResult ValidateHabitacionUpdate(this HabitacionUpdateDto habitacionUpdate)
        {
            ServiceResult result = new ServiceResult();

            if (habitacionUpdate.CambioUsuario <= 0)
            {
                result.Message = "Id No Puede Ser Cero";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(habitacionUpdate.Numero))
            {
                result.Message = "El Campo Es Requirido.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(habitacionUpdate.Detalle))
            {
                result.Message = "El Campo Es Requirido";
                result.Success = false;
                return result;
            }

            if (!habitacionUpdate.Precio.HasValue)
            {
                result.Message = "El Campo de Precio No Puede Ser Cero .";
                result.Success = false;
                return result;
            }

            if (!habitacionUpdate.IdEstadoHabitacion.HasValue)
            {
                result.Message = "El Campo de IdEstadoHabitacion No Puede Ser Cero .";
                result.Success = false;
                return result;
            }

            if (!habitacionUpdate.IdCategoria.HasValue)
            {
                result.Message = "El Campo de IdCategoria No Puede Ser Cero ";
                result.Success = false;
                return result;
            }

            if (!habitacionUpdate.IdPiso.HasValue)
            {
                result.Message = "El Campo de IdPiso No Puede Ser Cero ";
                result.Success = false;
                return result;
            }
            if (habitacionUpdate.IdHabitacionId <= 0)
            {
                result.Message = "El id No Puede Ser Cero";
                result.Success = false;
                return result;
            }



            return result;
        }

        public static ServiceResult ValidateEstadoHabitacionRemove(this HabitacionRemoveDto habitacionRemove)
        {
            ServiceResult result = new ServiceResult();

            if (habitacionRemove.CambioUsuario <= 0)
            {
                result.Message = "Id No Puede Ser Cero";
                result.Success = false;
                return result;
            }

            if (habitacionRemove.IdHabitacion <= 0)
            {
                result.Message = "Debe seleccionar el Id Del EstadoHabitacion que quiere eleminar.";
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
