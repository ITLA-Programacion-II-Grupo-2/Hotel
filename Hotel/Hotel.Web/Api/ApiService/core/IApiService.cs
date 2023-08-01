using Hotel.Web.Models;

namespace Hotel.Web.Api.ApiServices.Core
{
    public interface IApiService<List, Details, TAdd, TUpdate>
    {
        public List Get();
        public Details GetById(int id);
        public BaseResponse Add(TAdd add);
        public BaseResponse Update(TUpdate update);
    }
}

