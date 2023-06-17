using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;

namespace Hotel.Infrastructure.Interfaces
{
    public interface IEstadoHabitacionRepository : IBaseRepository<EstadoHabitacion>
    {
        List<EstadohabitacionModel> GetEstadohabitacions();
        EstadohabitacionModel GetEstadohabitacionBy (int id);
    }
}
