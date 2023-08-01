using Hotel.Web.Models;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;

namespace Hotel.Web.Api.ApiService
{
    public class PisoApiService : IPisoApiService
    {
        private readonly IApicaller apicaller;
        private readonly ILogger<PisoApiService> logger;
        private string baseUrl = "http://localhost:5286/api/Piso/";


        public PisoApiService(IApicaller apicaller, ILogger<PisoApiService> logger)
        {
            this.apicaller = apicaller;
            this.logger = logger;
        }
        public BaseResponse Add(PisoAddRequest add)
        {
            PisoListResponse? pisosList = new PisoListResponse();
            string url = $" {baseUrl}GetPiso";

            try
            {
                pisosList = apicaller.Get(url, pisosList);

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

            return pisosList;
        }

        public PisoListResponse Get()
        {
            throw new NotImplementedException();
        }

        public PisoDetailsResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Update(PisoUpdateRequest update)
        {
            throw new NotImplementedException();
        }
    }
}
