namespace Hotel.Web.Models.Usuario.Request
{
    public class UsuarioRemoveRequest : BaseRequest
    {
        public int IdUsuario { get; set; }

        public UsuarioRemoveRequest()
        {
           
        }
        public UsuarioRemoveRequest(int id)
        {
            IdUsuario = id;
        }

    }
}
