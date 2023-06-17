using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Core
{
    public abstract  class BaseEntity
    {
        public BaseEntity()
        {
            this.FechaCreacion = DateTime.Now;
            this.Estado = true;
        }

        public int ClienteCreacion { get; set;}
        public DateTime FechaCreacion { get; set; }
        public int? ClienteModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? ClienteEliminacion { get; set; }
        public DateTime? FechaEliminacion{ get; set; }
        public bool Estado { get; set; }

    }

    
}
