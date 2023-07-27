using Hotel.Web.Models;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;

namespace Hotel.Web.ApiServices
{
    public interface IRolUsuarioApiService
    {
        public RolUsuarioDetailsResponse GetById(int id);
        public RolUsuarioListResponse Get();
        public BaseResponse Add(RolUsuarioAddRequest rolUsuario);
        public BaseResponse Update(RolUsuarioUpdateRequest rolUsuario);
        public BaseResponse Remove(RolUsuarioRemoveRequest rolUsuario);

    }
}
