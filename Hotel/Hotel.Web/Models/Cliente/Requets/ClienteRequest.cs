namespace Hotel.Web.Models.Cliente.Requets
{
    public class ClienteRequest
    {
        public class ClienteUpdateRequest : ClienteRequest
        {
            public int IdCliente{ get; set; }
            public string? NombreCompleto { get; set; }
            public string? Correo { get; set; }
            public string? TipoDocumento { get; set; }
            public string? Documento { get; set; }

        }
}
