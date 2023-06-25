
using Hotel.Application.Core;
using Hotel.Application.Dtos.Usuario;

namespace Hotel.Application.Validations
{
    public static class UsuarioValidator
    {
        public static ServiceResult ValidateIdUsuario(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"El id de usuario que busca es invalido. id: {id}";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateUsuarioAdd(this UsuarioAddDto usuarioAddDto)
        {
            ServiceResult result = new ServiceResult();

            if (usuarioAddDto.ChangeUser <= 0)
            {
                result.Message = "Id del Usuario ejecutador es Invalido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(usuarioAddDto.NombreCompleto))
            {
                result.Message = "El nombre completo es requerido.";
                result.Success = false;
                return result;
            }

            if (usuarioAddDto.NombreCompleto.Length > 50)
            {
                result.Message = "El nombre completo no puede exceder los 50 caracteres.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(usuarioAddDto.Clave))
            {
                result.Message = "La clave es requerida.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(usuarioAddDto.Correo))
            {
                result.Message = "El correo es requerido.";
                result.Success = false;
                return result;
            }

            if (usuarioAddDto.IdRolUsuario <= 0)
            {
                result.Message = "Debe seleccionar un rol de usuario válido.";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateUsuarioUpdate(this UsuarioUpdateDto usuarioUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            if (usuarioUpdateDto.IdUsuario <= 0)
            {
                result.Message = "Debe seleccionar un id usuario válido.";
                result.Success = false;
                return result;
            }

            if (usuarioUpdateDto.ChangeUser <= 0)
            {
                result.Message = "Id del Usuario ejecutador es Invalido";
                result.Success = false;
                return result;
            }

            if (usuarioUpdateDto.NombreCompleto?.Length > 50)
            {
                result.Message = "El nombre completo no puede exceder los 50 caracteres.";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateUsuarioRemove(this UsuarioRemoveDto usuarioRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            
            if (usuarioRemoveDto.ChangeUser <= 0)
            {
                result.Message = "Id del Usuario ejecutador es Invalido";
                result.Success = false;
                return result;
            }

            if (usuarioRemoveDto.IdUsuario <= 0)
            {
                result.Message = "Debe seleccionar un id usuario válido.";
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
