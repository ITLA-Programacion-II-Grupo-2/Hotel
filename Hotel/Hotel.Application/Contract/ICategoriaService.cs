using Hotel.Application.Core;
using Hotel.Application.Dto.Categoria;


namespace Hotel.Application.Contract
{
    public interface ICategoriaService : IBaseService<CategoriaAddDto,
                                                      CategoriaUpdateDto,
                                                      CategoriaRemoveDto>
    {
     
    }
}
