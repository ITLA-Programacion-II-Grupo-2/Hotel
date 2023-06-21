using Hotel.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities
{
    public class EstadoHabitacion : BaseEntity
    {
        [Key]
        public int IdEstadoHabitacion { get; set; }
        public string? Descripcion { get; set; }

    }
}
