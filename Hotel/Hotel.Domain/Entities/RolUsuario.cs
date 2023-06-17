using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    public class RolUsuario : BaseEntity
    {
        [Key]
        public int IdRolUsuario { get; set; }
        public string? Descripcion { get; set; }
    }
}
