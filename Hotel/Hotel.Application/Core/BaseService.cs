﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Core
{
    public abstract class BaseService<TModelAdd, TModelMod, TModelRem>
    {
        
        public abstract ServiceResult Get();
        public abstract ServiceResult GetById(int id);
        public abstract ServiceResult Save(TModelAdd model);
        public abstract ServiceResult Update(TModelMod model);
        public abstract ServiceResult Remove(TModelRem model);
        
    }
}
