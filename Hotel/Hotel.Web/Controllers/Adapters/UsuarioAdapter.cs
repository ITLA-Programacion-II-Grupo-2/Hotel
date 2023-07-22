using Hotel.Application.Dtos.Usuario;
using Hotel.Web.Controllers.Adapters.Core;
using Hotel.Web.Controllers.Adapters.Core.Interfaces;
using Hotel.Web.Models.Usuario;
using Hotel.Web.Models.Usuario.Request;

namespace Hotel.Web.Controllers.Adapters
{
    public static class UsuarioAdapter
    {
        public static IConvertAdapter<UsuarioResponse, Object>
            UsuarioResponseAdapter { get; set; } = new UsuarioResponseAdapter();

        public static IConvertAdapter<UsuarioAddDto, UsuarioAddRequest>
            UsuarioaAddDtoAdapter { get; set; } = new UsuarioAddDtoAdapter();

        public static IConvertAdapter<UsuarioUpdateRequest, Object>
            UpdateRequestAdapter { get; set; } = new UpdateRequestAdapter();

    }
}
