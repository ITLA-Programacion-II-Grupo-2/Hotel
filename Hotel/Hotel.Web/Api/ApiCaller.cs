using Hotel.Web.Api.ApiServices;
using Hotel.Web.Models;
using Hotel.Web.Models.RolUsuario.Response;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.Web.Api
{
    public class ApiCaller : IApiCaller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<ApiCaller> logger;

        public ApiCaller(ILogger<ApiCaller> logger)
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.logger = logger;
        }

        public Response? Get<Response>(string url, Response? response) where Response : BaseResponse
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var result = httpClient.GetAsync(url).Result)
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = result.Content.ReadAsStringAsync().Result;
                        response = JsonConvert.DeserializeObject<Response>(apiResponse);
                    }
                }
            }

            return response;
        }

        public Response? Set<Request, Response>(string url, Request request, Response? response) where Response : BaseResponse
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (var result = httpClient.PostAsync(url, content).Result)
                {
                    string apiResponse = result.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<Response>(apiResponse);
                }

                return response;
            }
        }
    }
}
