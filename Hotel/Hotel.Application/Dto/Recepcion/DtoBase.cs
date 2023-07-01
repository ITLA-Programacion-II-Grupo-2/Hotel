using System;

namespace Hotel.API.Controllers
{
    public abstract class DtoBase
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }

    }
}
