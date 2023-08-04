using Hotel.Web.Api.ApiServices;
using Hotel.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.Web.Http
{
    public class HttpCaller : IHttpCaller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<HttpCaller> logger;

        public HttpCaller(IHttpClientFactory httpClientFactory, ILogger<HttpCaller> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public Response? Get<Response>(string url, Response? response) where Response : BaseResponse
        {
            using (var httpClient = this.httpClientFactory.CreateClient())
            {
                using (var result = httpClient.GetAsync(url).Result)
                {
                    if (result.IsSuccessStatusCode)
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
            using (var httpClient = this.httpClientFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (var result = httpClient.PostAsync(url, content).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        string apiResponse = result.Content.ReadAsStringAsync().Result;

                        response = JsonConvert.DeserializeObject<Response>(apiResponse);
                    }
                }
            }
            return response;
        }
    }
}
