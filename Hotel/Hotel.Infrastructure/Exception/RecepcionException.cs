using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Exceptions
{
    public class RecepcionException : Exception
    {
        public RecepcionException(string message) : base(message)
        {

        }
    }
}
