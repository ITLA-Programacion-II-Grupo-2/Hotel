using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Models
{
    public class UserByRolModel
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? Rol { get; set; }
    }
}
