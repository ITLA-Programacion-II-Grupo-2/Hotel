namespace Hotel.Web.Models.Cliente.Requets
{
    public class ClienteRemoveRequest : BaseRequest
    {
        public int IdCliente { get; set; }

        public ClienteRemoveRequest()
        {
        }

        public ClienteRemoveRequest(int id)
        {
            IdCliente = id;
        }
    }
}
