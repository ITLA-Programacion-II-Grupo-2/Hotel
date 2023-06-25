using Hotel.Domain.Entities;
using Hotel.Infrastructure.Models;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Hotel.Infrastructure.Exceptions
{
    public class ClienteException : Exception
    {
        public ClienteException(string message) : base(message)
        {
            ClienteModel clienteModel = new ClienteModel();
            { 
            }

        }
    }
    }