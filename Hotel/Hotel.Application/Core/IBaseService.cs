﻿
namespace Hotel.Application.Core
{
    public interface IBaseService<TDtoAdd, TDtoMod, TDtoRem>
    {
        ServiceResult Add(TDtoAdd model);
        ServiceResult Add(TDtoAdd[] models);
        ServiceResult Update(TDtoMod model);
        ServiceResult Update(TDtoMod[] models);
        ServiceResult Remove(TDtoRem model);
        ServiceResult Remove(TDtoRem[] models);
    }
}