using Hotel.Application.Dto.Categoria;
using Hotel.Domain.Entities;

namespace Hotel.Application.Extentions
{
    public static class CategoriaExtentions
    {
        public static Categoria ConvertDtoAddToEntity(this CategoriaAddDto categoriaAdd)
        {

            return new Categoria()
            {
                Descripcion = categoriaAdd.Descripcion,
                FechaCreacion = categoriaAdd.ChangeDate,
                UsuarioCreacion = categoriaAdd.ChangeUser

            };

        }


        public static Categoria ConvertDtoUpdateToEntity(this CategoriaUpdateDto categoriaUpdate)
        {

            return new Categoria()
            {
                Descripcion = categoriaUpdate.Descripcion,
                FechaModificacion = categoriaUpdate.ChangeDate,
                UsuarioModificacion = categoriaUpdate.ChangeUser,
                IdCategoria = categoriaUpdate.IdCategoria

            };

        }


        public static Categoria ConvertDtoRemoveToEntity(this CategoriaRemoveDto categoriaRemove)
        {

            return new Categoria()
            {
                IdCategoria = categoriaRemove.IdCategoria,
                Estado = categoriaRemove.Estado,
                FechaEliminacion = categoriaRemove.ChangeDate,
                UsuarioEliminacion = categoriaRemove.ChangeUser

            };

        }
    }


}  
