using Hotel.Application.Core;
using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Validations
{
    public static class PisoValidations
    {
        public static ServiceResult Validapiso(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"El id del piso invalido. id: {id}";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidandopisAdd(this PisoAddDto pisoAdd)
        {

            ServiceResult result = new ServiceResult();
            if (pisoAdd.ChangeUser <= 0)
            {
                result.Message = "El Id del usuario que ejecuto es invalido";
                result.Success = false;
                return result;

            }

            if (string.IsNullOrEmpty(pisoAdd.Descripcion))
            {

                result.Message = "El nombre del piso es necesario.";
                result.Success = false;
                return result;

            }

            else if (pisoAdd.Descripcion.Length > 50)
            {
                result.Message = "El nombre que ingresa en el piso supera el numero permitido de digitos.";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidandopisUpdate(this PisoUpdateDto pisoUpdate)
        {
            ServiceResult result = new ServiceResult();

            if (pisoUpdate.ChangeUser <= 0)
            {
                result.Message = "Id ingresado no es correcto, este no puede ser cero.";
                result.Success = false;
                return result;
            }


            if (string.IsNullOrEmpty(pisoUpdate.Descripcion))
            {
                result.Message = "El campo de Descripcion es obligatorio: ";
                result.Success = false;
                return result;
            }
            return result;
        }

        public static ServiceResult ValidandopisRemove(this PisoRemoveDto pisoRemove)
        {
            ServiceResult result = new ServiceResult();

            if (pisoRemove.ChangeUser <= 0)
            {
                result.Message = "Id ingresado no es correcto, este no puede ser cero.";
                result.Success = false;
                return result;
            }

            if (pisoRemove.Idpiso <= 0)
            {
                result.Message = "Debe selecionar el id del piso que desea eliminar.";
                result.Success = false;
                return result;
            }
            return result;
        }



    }

}

