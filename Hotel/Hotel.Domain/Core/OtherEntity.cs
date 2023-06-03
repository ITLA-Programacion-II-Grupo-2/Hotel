

namespace Hotel.Domain.Core
{
    public abstract class OtherEntity : BaseEntity
    {
        public int? IdCliente { get; set; }
        public int? IdHabitacion { get; set; }
    }
}
