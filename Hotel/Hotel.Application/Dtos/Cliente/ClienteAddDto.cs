
using System;

namespace Hotel.Application.Dtos.Cliente
{
    public class ClienteAddDto : ClienteDto
    {
        public string? NombreCompleto { get; internal set; }
        public string? Correo { get; internal set; }


        internal object ConvertAddDtoToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
