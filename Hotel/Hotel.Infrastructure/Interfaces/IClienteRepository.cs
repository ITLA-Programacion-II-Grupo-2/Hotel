using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;

namespace Hotel.Infrastructure.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        public ClienteModel GetCliente(int id);
        public List<ClienteModel> GetCliente();
    }

}