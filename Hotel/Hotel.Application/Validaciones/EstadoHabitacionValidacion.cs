using Hotel.Application.Core;
using Hotel.Application.Dtos.EstadoHabitacion;


namespace Hotel.Application.Validaciones
{
    public static class EstadoHabitacionValidacion
    {
        public static ServiceResult ValidateIdEstadoHabitacion(int id)
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

        public static ServiceResult ValidateEstadoHabitacionoAdd(this EstadoHabitacionAddDto estadoHabitacionAdd)
        {
            ServiceResult result = new ServiceResult();

            if (estadoHabitacionAdd.CambioUsuario <= 0)
            {
                result.Message = "Id No Puede Ser Cero";
                result.Success = false;
                return result;
            }


            if (string.IsNullOrEmpty(estadoHabitacionAdd.Descripcion))
            {
                result.Message = "El Campo Descripcion Es Requerido, No Puede Estar Vacio";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateEstadoHabitacionUpdate(this EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            ServiceResult result = new ServiceResult();

            if (estadoHabitacionUpdate.CambioUsuario <= 0)
            {
                result.Message = "Id No Puede Ser Cero";
                result.Success = false;
                return result;
            }


            if (string.IsNullOrEmpty(estadoHabitacionUpdate.Descripcion))
            {
                result.Message = "El Campo Descripcion Es Requerido, No Puede Estar Vacio";
                result.Success = false;
                return result;
            }


            return result;
        }

        public static ServiceResult ValidateEstadoHabitacionRemove(this EstadoHabitacionRemoveDto estadoHabitacionRemove)
        {
            ServiceResult result = new ServiceResult();

            if (estadoHabitacionRemove.CambioUsuario <= 0)
            {
                result.Message = "Id No Puede Ser Cero";
                result.Success = false;
                return result;
            }

            if (estadoHabitacionRemove.IdEstadoHabitacion <= 0)
            {
                result.Message = "Debe seleccionar el Id Del EstadoHabitacion que quiere eleminar.";
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
