using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dtos.Cliente
{
    public abstract  class ClienteDto : DtoBase
    {
        public string? TipoDocumento { get; set; }
        public int Documento { get; set; }
    }
}
