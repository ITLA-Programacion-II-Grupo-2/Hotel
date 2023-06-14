using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Exceptions
{
    public class PisoException : Exception
    {
        public PisoException(string message) : base(message)
        {

        }
    }
}
