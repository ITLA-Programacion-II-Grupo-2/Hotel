using Hotel.Application.Contract;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.web.Models.Response;
using Hotel.web.Models.Response.Estadohabitacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.web.Controllers
{
    public class EstadohabitacionApiController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public EstadohabitacionApiController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }
        // GET: EstadohabitacionApiController
        public ActionResult Index()
        {
            EstadohabitacionListReponse estadohabitacionList = new EstadohabitacionListReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5068/api/EstadoHabitacion/GetEstados").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        estadohabitacionList = JsonConvert.DeserializeObject<EstadohabitacionListReponse>(apiResponse);
                    }
                }
            }

            return View(estadohabitacionList.data);
        }

        // GET: EstadohabitacionApiController/Details/5
        public ActionResult Details(int id)
        {
            EstadohabitacionDetailReponse estadohabitacionDetail = new EstadohabitacionDetailReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5068/api/EstadoHabitacion/GetEstadosById?"+id).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        estadohabitacionDetail = JsonConvert.DeserializeObject<EstadohabitacionDetailReponse>(apiResponse);
                    }

                }
            }


            return View(estadohabitacionDetail);
        }

        // GET: EstadohabitacionApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadohabitacionApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoHabitacionAddDto estadoHabitacionAdd)
        {
            EstadoHabitacionAddDto estadoHabitacionAddd = new EstadoHabitacionAddDto();

            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionAddd), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5068/api/EstadoHabitacion/ADD", content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        estadoHabitacionAddd = JsonConvert.DeserializeObject<EstadoHabitacionAddDto>(apiResponse);
                        
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadohabitacionApiController/Edit/5
        public ActionResult Edit(int id)
        {
            EstadohabitacionDetailReponse estadohabitacionDetail = new EstadohabitacionDetailReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5068/api/EstadoHabitacion/GetEstadosById?" + id).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        estadohabitacionDetail = JsonConvert.DeserializeObject<EstadohabitacionDetailReponse>(apiResponse);
                    }

                }
            }

            return View(estadohabitacionDetail);
        }

        // POST: EstadohabitacionApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            try
            {
                var estadoHabitacionUpdateDto = new EstadoHabitacionUpdateDto();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5037/api/Department/Update", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            var result = JsonConvert.DeserializeObject<EstadoHabitacionUpdateDto>(apiResponse);
                        }

                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
