using Hotel.Application.Dto.Categoria;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;
using static Hotel.Web.Http.HttpServices.CategoriaHttpService;

namespace Hotel.Web.Http.HttpServices
{
    public class CategoriaHttpService : ICategoriaHttpService
    {
        
            private readonly IHttpCaller httpCaller;
            private readonly ILogger<CategoriaHttpService> logger;
            private string baseUrl = string.Empty;

            public CategoriaHttpService(IHttpCaller apiCaller,
                                    IConfiguration configuration,
                                    ILogger<CategoriaHttpService> logger)
            {
                this.httpCaller = apiCaller;
                this.logger = logger;
                this.baseUrl = configuration["ApiConfig:baseUrl"] + "Categoria/";
            }

        public CategoriaListResponse Get()
        {
            CategoriaListResponse? categoriasList = new CategoriaListResponse();
            string url = $" {baseUrl}GetCategoria";

            try
            {
                categoriasList = httpCaller.Get(url, categoriasList);

                if (categoriasList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                categoriasList = new CategoriaListResponse();
                categoriasList.Success = false;
                categoriasList.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(categoriasList.Message, ex.ToString());
            }

            return categoriasList;
        }

        public CategoriaDetailsResponse GetById(int Id)
        {
            CategoriaDetailsResponse? categoria = new CategoriaDetailsResponse();
            string url = $" {baseUrl}GetCategoria?id={Id}";

            try
            {
                categoria = httpCaller.Get(url, categoria);

                if (categoria == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                categoria = new CategoriaDetailsResponse();
                categoria.Success = false;
                categoria.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(categoria.Message, ex.ToString());
            }

            return categoria;
        }

        public BaseResponse Add(CategoriaAddRequest add)
        {
            BaseResponse? result = new BaseResponse();

            CategoriaAddDto categoriaAdd = add.ConvertAddRequestToAddDto();

            string url = $" {baseUrl}SaveCategoria";

            try
            {
                result = httpCaller.Set(url, categoriaAdd, result);
                if (result == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public BaseResponse Update(CategoriaUpdateRequest update)
        {
            BaseResponse? result = new BaseResponse();

             CategoriaUpdateDto categoriaUpdate = update.ConvertirUpdateRequestToUpdateDto();
            string url = $" {baseUrl}UpdateCategoria";

            try
            {
                result = httpCaller.Set(url, categoriaUpdate, result);
                if (result == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                result = new BaseResponse();
                result.Success = false;
                result.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
