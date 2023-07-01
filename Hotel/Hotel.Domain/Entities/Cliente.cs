using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Domain.Entities
{
    public class Cliente : Person
    {
        [Key]
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public int Documento { get; set; }
    }
}
