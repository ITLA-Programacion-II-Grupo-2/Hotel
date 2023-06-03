using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class Recepcion: BaseEntity
    {
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaSalidaConfirmacion { get; set; }
        public Decimal PrecioInicial { get; set; }
        public Decimal Adelanto { get; set; }
        public Decimal PrecioRestante { get; set; }
        public Decimal TotalPagado { get; set; }
        public Decimal CostoPenalidad { get; set; }
        public string? Observacion { get; set; }
    }
}
