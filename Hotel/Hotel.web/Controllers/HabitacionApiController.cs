using Hotel.web.Models.Response.Habitacion;
using Hotel.Application.Dtos.Habitacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Hotel.web.Servicios_Api;

namespace Hotel.web.Controllers
{
    public class HabitacionApiController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly IConfiguration configuration;
        private readonly HabitacionServiceA habitacionServiceA;

        public HabitacionApiController(IConfiguration configuration, HabitacionServiceA habitacionServiceA)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.configuration = configuration;
            this.habitacionServiceA = habitacionServiceA;
        }
        // GET: HabitacionApiController
        public ActionResult Index()
        {
            HabitacionListReponse habitacionList = new HabitacionListReponse();

            habitacionList = this.habitacionServiceA.GetEntities();

            return View(habitacionList.data);
        }

        // GET: HabitacionApiController/Details/5
        public ActionResult Details(int id)
        {
            HabitacionDetailReponse habitacionDetail = new HabitacionDetailReponse();
            habitacionDetail = this.habitacionServiceA.GetEntity(id);

            return View(habitacionDetail.data);
        }

        // GET: HabitacionApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HabitacionAddDto habitacionAdd)
        {
            HabitacionAddReponse habitacionAddReponse = new HabitacionAddReponse();

            try
            {
                habitacionAddReponse = this.habitacionServiceA.Add(habitacionAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionApiController/Edit/5
        public ActionResult Edit(int id)
        {
            HabitacionDetailReponse habitacionDetail = new HabitacionDetailReponse();

            habitacionDetail = this.habitacionServiceA.GetEntity(id);

            return View(habitacionDetail.data);
        }

        // POST: HabitacionApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HabitacionUpdateDto habitacionUpdate)
        {
            try
            {
                var habitacionUpdateReponse = new HabitacionUpdateReponse();

                habitacionUpdateReponse = this.habitacionServiceA.Update(habitacionUpdate);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
      
   
}

