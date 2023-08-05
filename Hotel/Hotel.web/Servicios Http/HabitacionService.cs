using Hotel.Application.Dtos.Habitacion;
using Hotel.Application.Services;
using Hotel.web.Models.Response.Estadohabitacion;
using Hotel.web.Models.Response.Habitacion;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.web.Servicios_Http
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<HabitacionService> logger;
        private string baseUrl = "http://localhost:5068/api/EstadoHabitacion/";


        public HabitacionService(IHttpClientFactory httpClientFactory,
                                                                 IConfiguration configuration,
                                                                ILogger<HabitacionService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
        }
        public HabitacionAddReponse Add(HabitacionAddDto habitacionAdd)
        {
            HabitacionAddReponse habitacionAdd1 = new HabitacionAddReponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(habitacionAdd1), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($" {baseUrl}Add", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            habitacionAdd1 = JsonConvert.DeserializeObject<HabitacionAddReponse>(apiResponse);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                habitacionAdd1.success = false;
                habitacionAdd1.message = "Error Al Guardar la Habitacion.";
                this.logger.LogError($"{habitacionAdd1.message}", ex.ToString());
            }
            return habitacionAdd1;
        }

        public HabitacionListReponse GetEntities()
        {
            HabitacionListReponse habitacionList = new HabitacionListReponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($" {baseUrl}Get").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            habitacionList = JsonConvert.DeserializeObject<HabitacionListReponse>(apiResponse);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                habitacionList.success = false;
                habitacionList.message = "Error obteniendo Las habitaciones";
                this.logger.LogError($"{habitacionList.message}", ex.ToString());

            }
            return habitacionList;
        }

        public HabitacionDetailReponse GetEntity(int id)
        {
            HabitacionDetailReponse habitacionDetail = new HabitacionDetailReponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($" {baseUrl}/{id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            habitacionDetail = JsonConvert.DeserializeObject<HabitacionDetailReponse>(apiResponse);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                habitacionDetail.success = false;
                habitacionDetail.message = "Error al Obtener La Habitacion";
                this.logger.LogError($"{habitacionDetail.message}", ex.ToString());

            }
            return habitacionDetail;
        }

        public HabitacionUpdateReponse Update(HabitacionUpdateDto habitacionUpdate)
        {
            HabitacionUpdateReponse habitacionUpdate1 = new HabitacionUpdateReponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(habitacionUpdate1), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($" {baseUrl}Update", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            habitacionUpdate1 = JsonConvert.DeserializeObject<HabitacionUpdateReponse>(apiResponse);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                habitacionUpdate1.success = false;
                habitacionUpdate1.message = "Error Al Editar Las Habitacion.";
                this.logger.LogError($"{habitacionUpdate1.message}", ex.ToString());
            }
            return habitacionUpdate1;
        }
    }
}
