using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Core
{
    public abstract class Person : BaseEntity
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
    }
}
