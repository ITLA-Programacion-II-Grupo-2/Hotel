using System;

namespace Hotel.Infrastructure.Exceptions
{
    public class ClienteException : Exception
    {
        public ClienteException(string message) : base(message)
        {

        }
    }
}