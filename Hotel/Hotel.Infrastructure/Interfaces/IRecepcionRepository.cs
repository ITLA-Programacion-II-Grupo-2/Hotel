using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;


namespace Hotel.Infrastructure.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        List<RecepcionModels> GetRecepcion(int id);
        List<RecepcionModels> GetRecepcion();

    }
}