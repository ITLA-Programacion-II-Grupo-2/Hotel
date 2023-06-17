
using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    public class Usuario : Person
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdRolUsuario { get; set; }
        public string? Clave { get; set; }

    }
}
