using System;

namespace Hotel.Infrastructure.Exceptions
{
    public class HabitacionException : Exception
    {
        public HabitacionException (string message) : base(message)
        {

        }
    }
}
