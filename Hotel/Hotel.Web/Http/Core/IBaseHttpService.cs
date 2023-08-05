using Hotel.Web.Models;

namespace Hotel.Web.Http.Core
{
    public interface IBaseHttpService<List, Details, TAdd, TUpdate>
    {
        public List Get();
        public Details GetById(int Id);
        public BaseResponse Add(TAdd add);
        public BaseResponse Update(TUpdate update);

    }
}
