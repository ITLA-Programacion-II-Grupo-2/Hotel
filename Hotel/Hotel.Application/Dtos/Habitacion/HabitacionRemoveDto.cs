

namespace Hotel.Application.Dtos.Habitacion
{
    public class HabitacionRemoveDto : HabitacionDto
    {
        public int IdHabitacion { set; get; }
        public bool Estado { set; get; }        
    }
}
