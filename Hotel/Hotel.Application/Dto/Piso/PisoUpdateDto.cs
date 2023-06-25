using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Dto.Piso
{
    public class PisoUpdateDto : Dtobasep
    {
        public int Idpiso { get; set; }
        public string? Descripcion { get; set; }

    }
}
