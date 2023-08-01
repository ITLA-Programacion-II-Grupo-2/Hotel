using Hotel.Web.Api.ApiServices.Core;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;
using System.Collections.Generic;

namespace Hotel.Web.Api.ApiService
{
    public interface IPisoApiService : IApiService
                                        <PisoListResponse, 
                                         PisoDetailsResponse,   
                                         PisoAddRequest, 
                                         PisoUpdateRequest>
    {

    }
}
