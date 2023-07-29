using System.ComponentModel.DataAnnotations;
namespace Hotel.Application.Dtos.Cliente
{
    public abstract  class ClienteDto : DtoBase
    {
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
    }
}
