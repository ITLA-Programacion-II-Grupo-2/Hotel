
namespace Hotel.Application.Core
{
    public abstract class BaseService<TModelAdd, TModelMod, TModelRem>
    {
        public abstract ServiceResult Save(TModelAdd model);
        public abstract ServiceResult Save(TModelAdd[] model);
        public abstract ServiceResult Update(TModelMod model);
        public abstract ServiceResult Update(TModelMod[] model);
        public abstract ServiceResult Remove(TModelRem model);
        public abstract ServiceResult Remove(TModelRem[] model);
    }
}
