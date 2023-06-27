﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Core
{
    public interface IBaseService<TDtoAdd, TDtoMod, TDtoRem>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Save(TDtoAdd model);
        ServiceResult Update(TDtoMod model);
        ServiceResult Remove(TDtoRem model);

    }
}
