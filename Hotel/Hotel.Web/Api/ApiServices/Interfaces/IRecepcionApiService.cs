using Hotel.Web.Api.ApiServices.Core;
using Hotel.Web.Models.Recepcion.Request;
using Hotel.Web.Models.Recepcion.Response;

namespace Hotel.Web.Api.ApiServices.Interfaces
{
    public interface IRecepcionApiService : IApiService<
                                                        RecepcionListResponse,
                                                        RecepcionDetailsResponse,
                                                        RecepcionAddRequest,
                                                        RecepcionUpdateRequest,
                                                        RecepcionRemoveRequest>
    {
    }
}
