
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

        public static ServiceResult validandocapadd(this CategoriaAddDto categoriaAddDto)
        {

            ServiceResult result = new ServiceResult();
            if (categoriaAddDto.ChangeUser <= 0)
            {
                result.Message = "El Id del usuario que ejecuto es invalido";
                result.Success = false;
                return result;

            }

            if (string.IsNullOrEmpty(categoriaAddDto.Descripcion))
            {

                result.Message = "El nombre de la categoria es necesario.";
                result.Success = false;
                return result;

            }

            else if (categoriaAddDto.Descripcion.Length > 50)
            {
                result.Message = "El nombre que ingresa en la categoria supera el numero permitido de digitos.";
                result.Success = false;
                return result;
            }

            return result;

        }



    }


}
