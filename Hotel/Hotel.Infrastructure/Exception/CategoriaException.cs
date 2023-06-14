using System;


namespace Hotel.Infrastructure.Exceptions
{
   public class CategoriaException : Exception
    {
        public CategoriaException(string message): base(message) 
        { 
        
        }
    }
}
