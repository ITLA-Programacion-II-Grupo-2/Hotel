using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
   public class Piso: BaseEntity
    {
        [Key]
        public int IdPiso { get; set; }
        public string? Descripcion { get; set; }
    }
}
