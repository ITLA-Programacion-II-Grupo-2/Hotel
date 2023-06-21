

namespace Hotel.Application.Core
{
    internal interface IBaseService<TDtoAdd, TDtoUpd, TDtoRem>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Save(TDtoAdd model);
        ServiceResult Update(TDtoUpd model);
        ServiceResult Remove(TDtoRem model);
    }
}
