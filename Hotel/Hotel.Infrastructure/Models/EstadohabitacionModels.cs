
using System;

namespace Hotel.Infrastructure.Models
{
    internal class EstadohabitacionModels
    {
        public string? Descripcion { get; internal set; }
        public int IdHabitacion { get; internal set; }
        public int IdEstadoHabitacion { get; internal set; }

        public class EstadohabitacionModels1
        {
            public int IdHabitacion { get; set; }
            public int IdEstadoHabitacion { get; set; }
            public string? Descripcion { get; set; }

        }
    }
}
