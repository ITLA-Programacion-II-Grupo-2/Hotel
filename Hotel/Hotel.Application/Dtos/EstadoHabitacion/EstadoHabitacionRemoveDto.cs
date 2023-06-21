

namespace Hotel.Application.Dtos.EstadoHabitacion
{
    internal class EstadoHabitacionRemoveDto : EstadoHabitacionDto
    {
        public int IdEstadoHabitacion {  get; set; }  
        public bool Estado { get; set; }  
    }
}
