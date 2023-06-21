

namespace Hotel.Application.Core
{
    internal abstract class BaseService<TModelAdd, TModelUpd, TModelRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetById(int id);
        public abstract ServiceResult Save(TModelAdd model);
        public abstract ServiceResult Update(TModelUpd model);
        public abstract ServiceResult Remove(TModelRem model);
    }
}
