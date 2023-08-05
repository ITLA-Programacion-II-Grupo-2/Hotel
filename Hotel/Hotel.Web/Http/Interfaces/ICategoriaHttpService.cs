using Hotel.Web.Http.Core;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;

namespace Hotel.Web.Http.Interfaces
{
    public interface ICategoriaHttpService : IBaseHttpService
                                            <CategoriaListResponse,
                                             CategoriaDetailsResponse,
                                             CategoriaAddRequest,
                                             CategoriaUpdateRequest>
    {
    }
}
                                                      