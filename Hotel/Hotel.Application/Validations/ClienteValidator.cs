using Hotel.Application.Core;
using Hotel.Application.Dtos.Cliente;
using System.Linq;

namespace Hotel.Application.Validations
{
    public static class ClienteValidator
    {
        public static ServiceResult ValidateIdCliente(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"Cliente id incorrecto {id}";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateClienteAdd(this ClienteAddDto clienteAddDto)
        {
            ServiceResult result = new ServiceResult();

            if (clienteAddDto.ClienteChange <= 0)
            {
                result.Message = "Id invalido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(clienteAddDto.TipoDocumento))
            {
                result.Message = "Rs obligatorio ingresar el tipo de documento.";
                result.Success = false;
                return result;
            }


            if (clienteAddDto.Documento.Length <= 0)
            {
                result.Message = "El documento debe existir";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidateUsuarioUpdate(this ClienteUpdateDto clienteUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            if (clienteUpdateDto.IdCliente <= 0)
            {
                result.Message = "Debe seleccionar un id usuario válido.";
                result.Success = false;
                return result;
            }

            if (clienteUpdateDto.ClienteChange <= 0)
            {
                result.Message = "Id del Usuario ejecutador es Invalido";
                result.Success = false;
                return result;
            }

            if (clienteUpdateDto.TipoDocumento.Length > 50)
            {
                result.Message = "El documento no puede exceder la longitud.";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateClienteRemove(this ClienteRemoveDto clienteRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            if (clienteRemoveDto.ClienteChange <= 0)
            {
                result.Message = "Id Invalido";
                result.Success = false;
                return result;
            }

            if (clienteRemoveDto.IdCliente <= 0)
            {
                result.Message = "Id inexistente";
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
