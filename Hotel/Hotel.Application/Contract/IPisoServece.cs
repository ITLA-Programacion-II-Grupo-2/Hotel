using Hotel.Application.Core;
using Hotel.Application.Dto.Piso;


namespace Hotel.Application.Contract
{
    public interface IPisoServece : IBaseService< PisoAddDto,
                                                  PisoUpdateDto,
                                                  PisoRemoveDto>
    {



    }
}
