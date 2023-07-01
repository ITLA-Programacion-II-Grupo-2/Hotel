using System;

namespace Hotel.Domain.Core
{
    public abstract class BaseEntity

    {

        public BaseEntity()
        {
            this.FechaCreacion = DateTime.Now;
            this.Estado = true;

        }

        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public bool Estado { get; set; }
        public int? IdCliente { get; set; }
        public int? IdHabitacion { get; set; }

    }

}
