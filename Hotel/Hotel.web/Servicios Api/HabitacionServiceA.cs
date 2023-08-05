using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.Application.Dtos.Habitacion;
using Hotel.web.Models.Response.Estadohabitacion;
using Hotel.web.Models.Response.Habitacion;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.web.Servicios_Api
{
    public class HabitacionServiceA : IHabitacionServiceA
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<HabitacionServiceA> logger;

        private string baseUrl = "http://localhost:5068/api/Habitacion/";


        public HabitacionServiceA(IConfiguration configuration, ILogger<HabitacionServiceA> logger)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };


        }
        public HabitacionListReponse GetEntities()
        {
            HabitacionListReponse habitacionList = new HabitacionListReponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    using (var response = httpClient.GetAsync($" {baseUrl}Get").Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
                habitacionList.message = "Error obteniendo los Los Estados";
                this.logger.LogError($"{habitacionList.message}", ex.ToString());

            }
            return habitacionList;
        }
        public HabitacionDetailReponse GetEntity(int id)
        {
            HabitacionDetailReponse habitacionDetail = new HabitacionDetailReponse();


            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    using (var response = httpClient.GetAsync($" {baseUrl}/{id}").Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
                habitacionDetail.message = "Error obteniendo los Estados";
                this.logger.LogError($"{habitacionDetail.message}", ex.ToString());

            }
            return habitacionDetail;
        }
        public HabitacionAddReponse Add(HabitacionAddDto habitacionAdd)
        {
            HabitacionAddReponse habitacionAdd1 = new HabitacionAddReponse();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(habitacionAdd1), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync($" {baseUrl}Add", content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        habitacionAdd1 = JsonConvert.DeserializeObject<HabitacionAddReponse>(apiResponse);

                    }
                }
            }
            catch (Exception ex)
            {
                habitacionAdd1.success = false;
                habitacionAdd1.message = "Error guardando el curso.";
                this.logger.LogError($"{habitacionAdd1.message}", ex.ToString());
            }
            return habitacionAdd1;
        }

        public HabitacionUpdateReponse Update(HabitacionUpdateDto habitacionUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

