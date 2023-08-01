using Hotel.Web.Api.ApiServices.Core;
using Hotel.Web.Models;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;

namespace Hotel.Web.Api.ApiService
{
    public interface ICategoriaApiService : IApiService
                                            <CategoriaListResponse,
                                            CategoriaDetailsResponse, 
                                            CategoriaAddRequest, 
                                            CategoriaUpdateRequest>
    {
       

      
    }
}
