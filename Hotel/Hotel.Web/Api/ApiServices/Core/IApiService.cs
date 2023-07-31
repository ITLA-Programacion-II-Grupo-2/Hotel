using Hotel.Web.Models;

namespace Hotel.Web.Api.ApiServices.Core
{
    public interface IApiService<List, Details, TAdd,TUpdate,TRemove>
    {
        public List Get();
        public Details GetById(int id);
        public BaseResponse Add(TAdd add);
        public BaseResponse Update(TUpdate update);
        public BaseResponse Remove(TRemove remove);
    }
}
