using Hotel.Web.Api.ApiServices.Core;
using Hotel.Web.Models.Usuario.Request;
using Hotel.Web.Models.Usuario.Response;

namespace Hotel.Web.Api.ApiServices.Interfaces
{
    public interface IUsuarioApiService : IApiService<
                                                        UsuarioListResponse,
                                                        UsuarioDetailsResponse,
                                                        UsuarioAddRequest,
                                                        UsuarioUpdateRequest,
                                                        UsuarioRemoveRequest>
    {

    }
}
