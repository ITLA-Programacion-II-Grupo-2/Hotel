
using Hotel.Application.Core;
using Hotel.Application.Dto.Categoria;


namespace Hotel.Application.Validations
{
    public static class CategoriaValidations
    {
        public static ServiceResult ValidaCategorias(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"El id de la categoria es invalido. id: {id}";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult validandocapAdd(this CategoriaAddDto categoriaAdd)
        {

            ServiceResult result = new ServiceResult();
            if (categoriaAdd.ChangeUser <= 0)
            {
                result.Message = "El Id del usuario que ejecuto es invalido";
                result.Success = false;
                return result;

            }

            if (string.IsNullOrEmpty(categoriaAdd.Descripcion))
            {

                result.Message = "El nombre de la categoria es necesario.";
                result.Success = false;
                return result;

            }

            else if (categoriaAdd.Descripcion.Length > 50)
            {
                result.Message = "El nombre que ingresa en la categoria supera el numero permitido de digitos.";
                result.Success = false;
                return result;
            }

            return result;

        }


        public static ServiceResult validandocapUpdate(this CategoriaUpdateDto categoriaUpdate)
        {
            ServiceResult result = new ServiceResult();

            if (categoriaUpdate.ChangeUser <= 0)
            {
                result.Message = "Id ingresado no es correcto, este no puede ser cero.";
                result.Success = false;
                return result;
            }


            if (string.IsNullOrEmpty(categoriaUpdate.Descripcion))
            {
                result.Message = "El campo de Descripcion es obligatorio: ";
                result.Success = false;
                return result;
            }


            return result;
        }

        public static ServiceResult validandocapRemove(this CategoriaRemoveDto categoriaRemove)
        {
            ServiceResult result = new ServiceResult();

            if (categoriaRemove.ChangeUser <= 0)
            {
                result.Message = "Id ingresado no es correcto, este no puede ser cero.";
                result.Success = false;
                return result;
            }

            if (categoriaRemove.IdCategoria <= 0)
            {
                result.Message = "Debe selecionar el id de la categoria que desea eliminar.";
                result.Success = false;
                return result;
            }
            return result;
        }




    }


}
