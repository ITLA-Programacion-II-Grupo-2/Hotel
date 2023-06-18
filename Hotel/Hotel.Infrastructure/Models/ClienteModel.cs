
namespace Hotel.Infrastructure.Models
{
    public class ClienteModel 
    {
        public int IdCliente { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? TipoDocumento { get; set; }
        public int Documento { get; set; }
    }
}
