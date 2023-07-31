using Hotel.Web.Api.ApiServices.Core;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;

namespace Hotel.Web.Api.ApiServices.Interfaces
{
    public interface IRolUsuarioApiService : IApiService<
                                                        RolUsuarioListResponse,
                                                        RolUsuarioDetailsResponse,
                                                        RolUsuarioAddRequest,
                                                        RolUsuarioUpdateRequest,
                                                        RolUsuarioRemoveRequest>
    {

    }
}
