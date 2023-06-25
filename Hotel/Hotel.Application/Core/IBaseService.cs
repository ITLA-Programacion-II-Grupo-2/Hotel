

namespace Hotel.Application.Core
{
    public interface IBaseService<TDtoAdd, TDtoUpd, TDtoRem>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Add(TDtoAdd model);
        ServiceResult Update(TDtoUpd model);
        ServiceResult Remove(TDtoRem model);
    }
}
