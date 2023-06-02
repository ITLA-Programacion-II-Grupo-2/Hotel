
using Hotel.Domain.Core;

namespace Hotel.Domain.Entities
{
    public class Usuario : Person
    {
        public int IdUsuario { get; set; }
        public int IdRolUsuario { get; set; }
        public string? Clave { get; set; }

    }
}
