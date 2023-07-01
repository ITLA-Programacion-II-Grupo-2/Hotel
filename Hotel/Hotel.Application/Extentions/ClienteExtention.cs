using Hotel.Application.Dtos.Cliente;
using Hotel.Domain.Entities;

namespace Hotel.Application.Extentions
{
    public static class ClienteExtention
    {
        public static Cliente ConvertAddDtoToEntity(this ClienteAddDto clienteAddDto)
        {
            return new Cliente()
            {
                NombreCompleto = clienteAddDto.NombreCompleto,
                Correo = clienteAddDto.Correo,
                TipoDocumento = clienteAddDto.TipoDocumento,
                Documento = clienteAddDto.Documento,
                ClienteCreacion = clienteAddDto.ClienteChange,
                FechaCreacion = clienteAddDto.FechaChange
            };
        }
        public static Cliente ConvertUpdateDtoToEntity(this ClienteUpdateDto clienteUpdateDto)
        {
            return new Cliente()
            {
                NombreCompleto = clienteUpdateDto.NombreCompleto,
                Correo = clienteUpdateDto.Correo,
                TipoDocumento = clienteUpdateDto.TipoDocumento,
                Documento = clienteUpdateDto.Documento,
                ClienteCreacion = clienteUpdateDto.ClienteChange,
                FechaCreacion = clienteUpdateDto.FechaChange
            };
        }

        public static Cliente ConvertRemoveDtoToEntity(this ClienteRemoveDto clienteRemoveDto)
        {
            return new Cliente()
            {
                IdCliente = clienteRemoveDto.IdCliente,
                ClienteModificacion = clienteRemoveDto.ClienteChange,
                FechaModificacion = clienteRemoveDto.FechaChange
            };
        }
    }
}