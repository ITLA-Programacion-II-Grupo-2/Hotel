using Hotel.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class RolUsuario : BaseEntity
    {
        public int IdRolUsuario { get; set; }
        public string? Descripcion { get; set; }
    }
}
