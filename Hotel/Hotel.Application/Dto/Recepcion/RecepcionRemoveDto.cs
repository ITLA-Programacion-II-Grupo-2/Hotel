using Hotel.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dto.Recepcion
{
    public class RecepcionRemoveDto : DtoBase
    {
        public int IdRecepcion { get; set; }
        public bool Estado { get; set; }
    }
}
