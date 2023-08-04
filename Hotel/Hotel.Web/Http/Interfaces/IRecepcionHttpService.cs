using Hotel.Web.Http.Core;
using Hotel.Web.Models.Recepcion.Request;
using Hotel.Web.Models.Recepcion.Response;

namespace Hotel.Web.Http.Interfaces
{
    public interface IRecepcionHttpService : IHttpService<
                                                        RecepcionListResponse,
                                                        RecepcionDetailsResponse,
                                                        RecepcionAddRequest,
                                                        RecepcionUpdateRequest,
                                                        RecepcionRemoveRequest>
    {
    }
}
