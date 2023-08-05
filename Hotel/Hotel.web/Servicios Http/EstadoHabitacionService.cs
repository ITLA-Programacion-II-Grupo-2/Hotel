using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.web.Models.Response.Estadohabitacion;
using Newtonsoft.Json;
using System.Text;
using static Hotel.web.Servicios_Http.IEstadoHabitacionService;

namespace Hotel.web.Servicios_Http
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<EstadoHabitacionService> logger;
        private string baseUrl = "http://localhost:5068/api/EstadoHabitacion/";


        public EstadoHabitacionService(IHttpClientFactory httpClientFactory,
                                                                 IConfiguration configuration,
                                                                ILogger<EstadoHabitacionService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
        }

        public EstadohabitacionListReponse GetEntities()
        {
            EstadohabitacionListReponse estadohabitacionList = new EstadohabitacionListReponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($" {baseUrl}Get").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            estadohabitacionList = JsonConvert.DeserializeObject<EstadohabitacionListReponse>(apiResponse);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                estadohabitacionList.success = false;
                estadohabitacionList.message = "Error obteniendo Los Estados";
                this.logger.LogError($"{estadohabitacionList.message}", ex.ToString());

            }
            return estadohabitacionList;
        }
        public EstadoHabitacionDetailResponse GetEntity(int id)
        {
            EstadoHabitacionDetailResponse estadoHabitacionDetail = new EstadoHabitacionDetailResponse();


            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($" {baseUrl}/{id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            estadoHabitacionDetail = JsonConvert.DeserializeObject<EstadoHabitacionDetailResponse>(apiResponse);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                estadoHabitacionDetail.success = false;
                estadoHabitacionDetail.message = "Error Al Obtener El Estado";
                this.logger.LogError($"{estadoHabitacionDetail.message}", ex.ToString());

            }
            return estadoHabitacionDetail;
        }
        public EstadoHabitacionAddResponse Add(EstadoHabitacionAddDto estadoHabitacionAddd)
        {
            EstadoHabitacionAddResponse estadoHabitacionAdd = new EstadoHabitacionAddResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionAdd), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($" {baseUrl}Add", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            estadoHabitacionAdd = JsonConvert.DeserializeObject<EstadoHabitacionAddResponse>(apiResponse);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                estadoHabitacionAdd.success = false;
                estadoHabitacionAdd.message = "Error Al Guardar El Estado.";
                this.logger.LogError($"{estadoHabitacionAdd.message}", ex.ToString());
            }
            return estadoHabitacionAdd;
        }
        public EstadoHabitacionUpdateResponse Update(EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            EstadoHabitacionUpdateResponse estadoHabitacionUpdate1 = new EstadoHabitacionUpdateResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionUpdate1), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($" {baseUrl}Update", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            estadoHabitacionUpdate1 = JsonConvert.DeserializeObject<EstadoHabitacionUpdateResponse>(apiResponse);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                estadoHabitacionUpdate1.success = false;
                estadoHabitacionUpdate1.message = "Error Al Editar El Estado.";
                this.logger.LogError($"{estadoHabitacionUpdate1.message}", ex.ToString());
            }
            return estadoHabitacionUpdate1;
        }
    }
    
}
