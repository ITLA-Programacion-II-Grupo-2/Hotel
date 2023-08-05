using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Extentions
{
    public static class PisoExtentions
    {
        public static Piso ConvertDtoAddToEntity(this PisoAddDto pisoAdd)
        {

            return new Piso()
            {
                Descripcion = pisoAdd.Descripcion,
               FechaCreacion=pisoAdd.ChangeDate,
               UsuarioCreacion=pisoAdd.ChangeUser
            };

      
        }

        public static Piso ConvertDtoUpdateToEntity(this PisoUpdateDto pisoUpdate)
        {

            return new Piso()
            {
                Descripcion = pisoUpdate.Descripcion,
                FechaModificacion = pisoUpdate.ChangeDate,
                UsuarioModificacion = pisoUpdate.ChangeUser,
                IdPiso = pisoUpdate.IdPiso

            };

        }

        public static Piso ConvertDtoRemoveToEntity(this PisoRemoveDto pisoRemove)
        {

            return new Piso()
            {
                IdPiso = pisoRemove.Idpiso,
                Estado = false,
                FechaEliminacion = pisoRemove.ChangeDate,
                UsuarioEliminacion = pisoRemove.ChangeUser

            };

        }

    }


}
