

namespace Hotel.Application.Dtos.EstadoHabitacion
{
    public class EstadoHabitacionRemoveDto : EstadoHabitacionDto
    {
        public int IdEstadoHabitacion {  get; set; }  
        public bool Estado { get; set; }  
    }
}
