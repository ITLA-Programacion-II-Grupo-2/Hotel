using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Dtos.Habitacion;
using Hotel.web.Models.Response.Estadohabitacion;
using Hotel.web.Models.Response.Habitacion;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.web.Servicios_Api
{
    public class EstadoHabitacionA : IEstadohabitacionA
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<HabitacionServiceA> logger;
        private readonly IConfiguration configuration;
        private string baseUrl = "http://localhost:5068/api/Habitacion/";

        public EstadoHabitacionA(IConfiguration configuration, ILogger<HabitacionServiceA> logger)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.configuration = configuration;
            logger = this.logger;
        }
        public EstadohabitacionListReponse GetEntities()
        {
            EstadohabitacionListReponse? estadohabitacionList = new EstadohabitacionListReponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    using (var response = httpClient.GetAsync($" {baseUrl}Get").Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    using (var response = httpClient.GetAsync($" {baseUrl}/{id}").Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
                estadoHabitacionDetail.message = "Error al obtener el Estado";
                this.logger.LogError($"{estadoHabitacionDetail.message}", ex.ToString());

            }
            return estadoHabitacionDetail;
        }
        public EstadoHabitacionAddResponse Add(EstadoHabitacionAddDto estadoHabitacionAdd)
        {
            EstadoHabitacionAddResponse estadoHabitacionAdd1 = new EstadoHabitacionAddResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionAdd1), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync($" {baseUrl}Add", content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        estadoHabitacionAdd1 = JsonConvert.DeserializeObject<EstadoHabitacionAddResponse>(apiResponse);

                    }
                }
            }
            catch (Exception ex)
            {
                estadoHabitacionAdd1.success = false;
                estadoHabitacionAdd1.message = "Error al Guardar el Estado.";
                this.logger.LogError($"{estadoHabitacionAdd1.message}", ex.ToString());
            }
            return estadoHabitacionAdd1;
        }

        public EstadoHabitacionUpdateResponse Update(EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            EstadoHabitacionUpdateResponse estadoHabitacionUpdate1 = new EstadoHabitacionUpdateResponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionUpdate1), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync($" {baseUrl}Update", content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        estadoHabitacionUpdate1 = JsonConvert.DeserializeObject<EstadoHabitacionUpdateResponse>(apiResponse);

                    }
                }
            }
            catch (Exception ex)
            {
                estadoHabitacionUpdate1.success = false;
                estadoHabitacionUpdate1.message = "Error Editar el Estado.";
                this.logger.LogError($"{estadoHabitacionUpdate1.message}", ex.ToString());
            }
            return estadoHabitacionUpdate1;
        }
    }
}
