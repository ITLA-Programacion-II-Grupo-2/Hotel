
using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;

namespace Hotel.Infrastructure.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        public RecepcionModel GetRecepcion(int id);
        public List<RecepcionModel> GetRecepciones();
    }
}
