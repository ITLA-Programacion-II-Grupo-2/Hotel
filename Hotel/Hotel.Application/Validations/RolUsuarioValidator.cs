
using Hotel.Application.Core;
using Hotel.Application.Dtos.RolUsuario;

namespace Hotel.Application.Validations
{
    public static class RolUsuarioValidator
    {
        public static ServiceResult ValidateRolUsuarioAdd(this RolUsuarioAddDto rolUsuarioAddDto)
        {
            ServiceResult result = new ServiceResult();

            if (rolUsuarioAddDto.ChangeUser <= 0)
            {
                result.Message = "Id del Usuario ejecutador es Invalido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(rolUsuarioAddDto.Descripcion))
            {
                result.Message = "El nombre del rol es requerido.";
                result.Success = false;
                return result;

            }
            else if (rolUsuarioAddDto.Descripcion.Length > 50)
            {
                result.Message = "Nombre de rol demasiado largo.";
                result.Success = false;
                return result;
            }

            return result;
        }
        public static ServiceResult ValidateRolUsuarioUpdate(this RolUsuarioUpdateDto rolUsuarioUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            if (rolUsuarioUpdateDto.ChangeUser <= 0)
            {
                result.Message = "Id del Usuario ejecutador es Invalido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(rolUsuarioUpdateDto.Descripcion))
            {
                result.Message = "El nombre del rol es requerido.";
                result.Success = false;
                return result;

            }
            else if (rolUsuarioUpdateDto.Descripcion.Length > 50)
            {
                result.Message = "Nombre de rol demasiado largo.";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateRol(string rol)
        {
            ServiceResult result = new ServiceResult();

            if (rol.Length > 50)
            {
                result.Message = "Nombre de rol demasiado largo.";
                result.Success = false;
                return result;
            }

            return result;
        }
        public static ServiceResult ValidateRolUsuarioRemove(this RolUsuarioRemoveDto rolUsuarioRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            if (rolUsuarioRemoveDto.IdRolUsuario <= 0)
            {
                result.Message = "Id de RolUsuario Invalido";
                result.Success = false;
                return result;

            }else if (rolUsuarioRemoveDto.ChangeUser <= 0)
            {
                result.Message = "Id del Usuario ejecutador es Invalido";
                result.Success = false;
                return result;
            }

            return result;
        }

    }
}
