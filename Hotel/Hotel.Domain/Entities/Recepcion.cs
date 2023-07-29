using Hotel.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Domain.Entities
{
    public class Recepcion : BaseEntity
    {
        [Key]
        public int IdRecepcion { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaSalidaConfirmacion { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioInicial { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Adelanto { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioRestante { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPagado { get; set; } = 0;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? CostoPenalidad { get; set; } = 0;
    }
}
