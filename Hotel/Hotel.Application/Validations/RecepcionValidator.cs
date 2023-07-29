
using Hotel.Application.Core;
using Hotel.Application.Dtos.Recepcion;

namespace Hotel.Application.Validations
{
    public static class RecepcionValidator
    {
        public static ServiceResult ValidateRecepcionId(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"El id de recepcion que busca es invalido. id: {id}";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateRecepcionDto(this RecepcionDto recepcion)
        {
            ServiceResult result = new ServiceResult();

            if (recepcion.IdCliente <= 0)
            {
                result.Message = $"El IdCliente invalido. id: {recepcion.IdCliente}";
                result.Success = false;
                return result;
            }

            if (recepcion.IdHabitacion <= 0)
            {
                result.Message = $"El IdHabitacion invalido. id: {recepcion.IdHabitacion}";
                result.Success = false;
                return result;
            }

            if (recepcion.ChangeUser <= 0)
            {
                result.Message = $"Change User invalido. id: {recepcion.ChangeUser}";
                result.Success = false;
                return result;
            }

            if (recepcion.PrecioInicial < 0)
            {
                result.Message = $"Precio Inicial: {recepcion.PrecioInicial}, Invalido.";
                result.Success = false;
                return result;
            }

            if (recepcion.PrecioRestante < 0)
            {
                result.Message = $"Precio Restante: {recepcion.PrecioRestante}, Invalido.";
                result.Success = false;
                return result;
            }

            if (recepcion.TotalPagado < 0)
            {
                result.Message = $"Total Pagado: {recepcion.TotalPagado}, Invalido.";
                result.Success = false;
                return result;
            }

            if (recepcion.Adelanto < 0)
            {
                result.Message = $"Adelanto: {recepcion.Adelanto}, Invalido.";
                result.Success = false;
                return result;
            }

            if (recepcion.CostoPenalidad < 0)
            {
                result.Message = $"Precio Inicial: {recepcion.CostoPenalidad}, Invalido.";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidateRecepcionDto(this RecepcionRemoveDto recepcion)
        {
            ServiceResult result = new ServiceResult();

            if (recepcion.ChangeUser <= 0)
            {
                result.Message = $"Change User invalido. id: {recepcion.ChangeUser}";
                result.Success = false;
                return result;
            }

            return result;
        }
    }
}
