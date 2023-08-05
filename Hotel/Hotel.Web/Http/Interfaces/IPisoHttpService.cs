using Hotel.Application.Dto.Piso;
using Hotel.Web.Http.Core;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;

namespace Hotel.Web.Http.Interfaces
{
    public interface IPisoHttpService : IBaseHttpService
                                        <PisoListResponse,
                                         PisoDetailsResponse, 
                                         PisoAddRequest,
                                         PisoUpdateRequest>
    {
    }
}
