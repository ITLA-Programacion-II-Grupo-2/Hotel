using Hotel.Application.Dto.Categoria;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;

namespace Hotel.Web.Api.ApiService
{
    public class CategoriaApiService : ICategoriaApiService
    {
        private readonly IApicaller apicaller;
        private readonly ILogger<CategoriaApiService> logger;
        private string baseUrl = "http://localhost:5286/api/Categoria/";
       

        public CategoriaApiService(IApicaller apicaller, ILogger<CategoriaApiService> logger)
        {
            this.apicaller = apicaller;
            this.logger = logger;
        }

        public CategoriaListResponse Get()
        {
            CategoriaListResponse? categoriasList = new CategoriaListResponse();
            string url = $" {baseUrl}GetCategoria";

            try
            {
                categoriasList = apicaller.Get(url, categoriasList);

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
        public CategoriaDetailsResponse GetById(int id)
        {
            CategoriaDetailsResponse? categoria = new CategoriaDetailsResponse();
            string url = $" {baseUrl}/{id}";

            try
            {
                categoria = apicaller.Get(url, categoria);

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
                result = apicaller.Set(url, categoriaAdd, result);
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
                result = apicaller.Set(url, categoriaUpdate, result);
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