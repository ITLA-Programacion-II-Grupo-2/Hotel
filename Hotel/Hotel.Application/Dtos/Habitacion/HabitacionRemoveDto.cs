

namespace Hotel.Application.Dtos.Habitacion
{
    internal class HabitacionRemoveDto : HabitacionDto
    {
        public int IdHabitacion { set; get; }
        public bool Estado { set; get; }        
    }
}
