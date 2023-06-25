using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Models;
using System.Collections.Generic;


namespace Hotel.Infrastructure.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        List<HabitacionModel> GetHabitacions();
        HabitacionModel GetHabitacionById(int id);
    }
}
