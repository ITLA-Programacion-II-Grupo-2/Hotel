
namespace Hotel.Web.Models.Cliente.Requets
{
    public class ClienteAddRequest : ClienteRequest
    {
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
    }
}
