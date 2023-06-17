using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;


namespace Hotel.Infrastructure.Interfaces
{
    public interface IPisoRepository : IBaseRepository<Piso>
    {
        List<PisoModels> GetPiso(int id);
        List<PisoModels> GetPiso();
    }
}
