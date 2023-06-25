using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos
{
    public abstract class DtoBase
    {
        public DateTime CambioFecha { get; set; }
        public int CambioUsuario { get; set; }
    }
}
