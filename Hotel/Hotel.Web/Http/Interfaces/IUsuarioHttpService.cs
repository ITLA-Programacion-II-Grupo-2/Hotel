using Hotel.Web.Http.Core;
using Hotel.Web.Models.Usuario.Request;
using Hotel.Web.Models.Usuario.Response;

namespace Hotel.Web.Http.Interfaces
{
    public interface IUsuarioHttpService : IHttpService<
                                                        UsuarioListResponse,
                                                        UsuarioDetailsResponse,
                                                        UsuarioAddRequest,
                                                        UsuarioUpdateRequest,
                                                        UsuarioRemoveRequest>
    {

    }
}
