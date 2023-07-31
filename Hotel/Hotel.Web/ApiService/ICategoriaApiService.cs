using Hotel.Web.Models;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;

namespace Hotel.Web.ApiService
{
    public interface ICategoriaApiService
    {

        public CategoriaResponse GetById(int id);
        public CategoriaResponse Get();
        public BaseResponse Add(CategoriaAddRequest categoria);
        public BaseResponse Update(CategoriaUpdateRequest categoria);
     

    }
}
