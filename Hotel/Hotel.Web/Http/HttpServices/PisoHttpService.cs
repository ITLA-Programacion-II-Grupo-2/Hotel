using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;

namespace Hotel.Web.Http.HttpServices
{
    public class PisoHttpService : IPisoHttpService
    {

        private readonly IHttpCaller httpCaller;
        private readonly ILogger<PisoHttpService> logger;
        private string baseUrl = string.Empty;

        public PisoHttpService(IHttpCaller apiCaller,
                                IConfiguration configuration,
                                ILogger<PisoHttpService> logger)
        {
            this.httpCaller = apiCaller;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"] + "Piso/";
        }
        public PisoListResponse Get()
        {
            PisoListResponse? pisosList = new PisoListResponse();
            string url = $" {baseUrl}GetPiso";

            try
            {
                pisosList = httpCaller.Get(url, pisosList);

                if (pisosList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                pisosList = new PisoListResponse();
                pisosList.Success = false;
                pisosList.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(pisosList.Message, ex.ToString());
            }

            return pisosList; throw new NotImplementedException();
        }

        public PisoDetailsResponse GetById(int Id)
        {
            PisoDetailsResponse? piso = new PisoDetailsResponse();
            string url = $" {baseUrl}GetPiso?id={Id}";

            try
            {
                piso = httpCaller.Get(url, piso);

                if (piso == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                piso = new PisoDetailsResponse();
                piso.Success = false;
                piso.Message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(piso.Message, ex.ToString());
            }

            return piso;
        }
        public BaseResponse Add(PisoAddRequest add)
        {
            BaseResponse? result = new BaseResponse();
            PisoAddDto pisoAdd = add.ConvertAddRequestToAddDto();

            string url = $" {baseUrl}SavePiso";

            try
            {
                result = httpCaller.Set(url, pisoAdd, result);
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
        public BaseResponse Update(PisoUpdateRequest update)
        {
            BaseResponse? result = new BaseResponse();

             PisoUpdateDto pisoUpdate = update.ConvertirUpdateRequestToUpdateDto();
            string url = $" {baseUrl}UpdatePiso";

            try
            {
                result = httpCaller.Set(url, pisoUpdate, result);
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
