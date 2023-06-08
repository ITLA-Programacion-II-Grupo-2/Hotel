using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Exceptions
{
    public class RolUsuarioException : Exception
    {
        public RolUsuarioException(string message) : base(message)
        {

        }
    }
}
