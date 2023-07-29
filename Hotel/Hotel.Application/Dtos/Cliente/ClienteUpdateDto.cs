
using Hotel.Application.Core;
using System;

namespace Hotel.Application.Dtos.Cliente
{
    public class ClienteUpdateDto : ClienteDto
    {
        public int IdCliente { get; set; }
        public string? NombreCompleto { get; internal set; }
        public string? Correo { get; internal set; }

        internal ServiceResult ValidateClienteUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
