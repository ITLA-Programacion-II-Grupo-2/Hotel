using Hotel.Application.Dto.Categoria;
using Hotel.Infrastructure.Models;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;

namespace Hotel.Web.Controllers.Extentions
{
    public static class CategoriaExtentions
    {
        public static CategoriaResponseModel ConvertGetByIdToCategoriaResponse(this CategoriaModels categoria)
        {
            return new CategoriaResponseModel()
            {
                   IdCategoria = categoria.IdCategoria,
                   Descripcion = categoria.Descripcion,
                   
            };
        }

        public static CategoriaAddDto ConvertAddRequestToAddDto(this CategoriaAddRequest categoriaAdd)
        {
            return new CategoriaAddDto()
        {
                Descripcion = categoriaAdd.Descripcion,
                ChangeUser = categoriaAdd.ChangeUser,
                ChangeDate = categoriaAdd.ChangeDate
            };
        }

        public static CategoriaUpdateRequest ConvertCategoriaToUpdateRequest(this CategoriaModels categoria)
        {
            return new CategoriaUpdateRequest()
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion,

            };
        }

        public static CategoriaUpdateDto ConvertirUpdateRequestToUpdateDto(this CategoriaUpdateRequest categoriaUpdate)
        {
            return new CategoriaUpdateDto()
            {
                IdCategoria = categoriaUpdate.IdCategoria,
                Descripcion = categoriaUpdate?.Descripcion,
                ChangeUser = categoriaUpdate.ChangeUser,
                ChangeDate = categoriaUpdate.ChangeDate,
            };
        }

    }
}
