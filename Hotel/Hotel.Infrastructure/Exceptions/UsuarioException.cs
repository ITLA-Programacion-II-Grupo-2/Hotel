﻿using System;

namespace Hotel.Infrastructure.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException(string message):base(message)
        {

        }
    }
}
