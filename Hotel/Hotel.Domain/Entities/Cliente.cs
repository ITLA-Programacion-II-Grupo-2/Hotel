using Hotel.Domain.Core;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Hotel.Domain.Entities
{
    public class Cliente : Person
    {
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public int Documento { get; set; }
    }
}
