using Hotel.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Domain.Entities
{
    public class Cliente : Person
    {
        [Key]
        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }

        public void ConvertClienteCreateToEntity()
        {
            throw new NotImplementedException();
        }

        public void ConvertClienteEntityToModel()
        {
            throw new NotImplementedException();
        }

        public void ConvertClienteRemoveToEntity(Cliente cliente)
        {
            throw new NotImplementedException();
        }


        public void ConvertClienteUpdateToEntity(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
