namespace Hotel.Web.Models.RolUsuario.Request
{
    public class RolUsuarioRemoveRequest : BaseRequest
    {
        public int IdRolUsuario { get; set; }

        public RolUsuarioRemoveRequest()
        {

        }

        public RolUsuarioRemoveRequest(int id)
        {
            IdRolUsuario = id;
        }
    }
}
