]using System;

namespace Hotel.Application.Dtos
{
    public abstract class DtoBase
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get;set; }
    }
}
