using Hotel.Web.Http.Core;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;

namespace Hotel.Web.Http.Interfaces
{
    public interface IRolUsuarioHttpService : IHttpService<
                                                        RolUsuarioListResponse,
                                                        RolUsuarioDetailsResponse,
                                                        RolUsuarioAddRequest,
                                                        RolUsuarioUpdateRequest,
                                                        RolUsuarioRemoveRequest>
    {

    }
}
