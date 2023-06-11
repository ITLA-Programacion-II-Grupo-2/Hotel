using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    public class Categoria: BaseEntity
    {

        [Key]
        public int IdCategoria { get; set; }
        public string? Descripcion {get; set; }
    }
}
