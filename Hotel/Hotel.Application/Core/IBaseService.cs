
namespace Hotel.Application.Core
{
    public interface IBaseService<TDtoAdd, TDtoMod, TDtoRem>
    {
       ServiceResult Save(TDtoAdd model);
       ServiceResult Save(TDtoAdd[] model); 
       ServiceResult Update(TDtoMod model);
       ServiceResult Update(TDtoMod[] model);
       ServiceResult Remove(TDtoRem model);
       ServiceResult Remove(TDtoRem[] model);
    }
}
