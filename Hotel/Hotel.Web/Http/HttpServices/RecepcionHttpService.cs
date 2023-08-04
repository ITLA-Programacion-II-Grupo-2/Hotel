using Hotel.Application.Dtos.Recepcion;
using Hotel.Web.Models;
using Hotel.Web.Models.Recepcion.Response;
using Hotel.Web.Models.Recepcion.Request;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;

namespace Hotel.Web.Http.HttpServices
{
    public class RecepcionHttpService : IRecepcionHttpService
    {
        private readonly IHttpCaller httpCaller;
        private readonly ILogger<RecepcionHttpService> logger;
        private string baseUrl = string.Empty;

        public RecepcionHttpService(IHttpCaller httpCaller, 
                                IConfiguration configuration,
                                ILogger<RecepcionHttpService> logger)
        {
            this.httpCaller = httpCaller;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"] + "Recepcion/";
        }

        public RecepcionListResponse Get()
        {
            RecepcionListResponse? recepcionList = new RecepcionListResponse();
            string url = $" {baseUrl}Get";

            try
            {
                recepcionList = httpCaller.Get(url, recepcionList);

                if (recepcionList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                recepcionList = new RecepcionListResponse();
                recepcionList.Success = false;
                recepcionList.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(recepcionList.Message, ex.ToString());
            }

            return recepcionList;
        }
        public RecepcionDetailsResponse GetById(int id)
        {
            RecepcionDetailsResponse? recepcion = new RecepcionDetailsResponse();
            string url = $" {baseUrl}GetById?id={id}";

            try
            {
                recepcion = httpCaller.Get(url, recepcion);

                if (recepcion == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                recepcion = new RecepcionDetailsResponse();
                recepcion.Success = false;
                recepcion.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(recepcion.Message, ex.ToString());
            }

            return recepcion;
        }
        public BaseResponse Add(RecepcionAddRequest add)
        {
            BaseResponse? result = new BaseResponse();

            RecepcionAddDto recepcionAdd = add.ConvertRequestToDto();

            string url = $" {baseUrl}Save";

            try
            {
                result = httpCaller.Set(url, recepcionAdd, result);
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
        public BaseResponse Update(RecepcionUpdateRequest update)
        {
            BaseResponse? result = new BaseResponse();

            RecepcionUpdateDto recepcionUpdate = update.ConvertRequestToDto();
            string url = $" {baseUrl}Update";

            try
            {
                result = httpCaller.Set(url, recepcionUpdate, result);
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
        public BaseResponse Remove(RecepcionRemoveRequest remove)
        {
            BaseResponse? result = new BaseResponse();

            RecepcionRemoveDto recepcionRemove = remove.ConvertRequestToDto();
            string url = $" {baseUrl}Remove";

            try
            {
                result = httpCaller.Set(url, recepcionRemove, result);
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
