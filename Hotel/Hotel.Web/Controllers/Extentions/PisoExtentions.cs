using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Infrastructure.Models;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;

namespace Hotel.Web.Controllers.Extentions
{
    public static class PisoExtentions
    {

        public static PisoResponse ConvertGetByIdToCategoriaResponse(this PisoModels piso)
        {
            return new PisoResponse()
            {
                IdPiso = piso.IdPiso,
                Descripcion = piso.Descripcion,

            };
        }

        public static PisoAddDto ConvertAddRequestToAddDto(this PisoAddRequest pisoAdd)
        {
            return new PisoAddDto()
            {
                Descripcion = pisoAdd.Descripcion,
                ChangeUser = pisoAdd.ChangeUser,
                ChangeDate = pisoAdd.ChangeDate
            };
        }

        public static PisoUpdateRequest ConvertPisoToUpdateRequest(this Infrastructure.Models.PisoModels piso)
        {
            return new PisoUpdateRequest()
            {
                IdPiso = piso.IdPiso,
                Descripcion = piso.Descripcion

            };
        }

        public static PisoUpdateDto ConvertirUpdateRequestToUpdateDto(this PisoUpdateRequest pisoUpdate)
        {
            return new PisoUpdateDto()
            {
                IdPiso = pisoUpdate.IdPiso,
                Descripcion = pisoUpdate?.Descripcion,
                ChangeUser = pisoUpdate.ChangeUser,
                ChangeDate = pisoUpdate.ChangeDate
            };
        }
    } 

}



