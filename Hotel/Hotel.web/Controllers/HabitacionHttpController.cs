using Hotel.Application.Dtos.Habitacion;
using Hotel.web.Models.Response.Habitacion;
using Hotel.web.Servicios_Api;
using Hotel.web.Servicios_Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.web.Controllers
{
    public class HabitacionHttpController : Controller
    {
        private readonly HabitacionService habitacionService;

        public HabitacionHttpController(HabitacionService habitacionService)
        {
            this.habitacionService = habitacionService;
        }
        // GET: HabitacionHttpController
        public ActionResult Index()
        {
            HabitacionListReponse habitacionList = new HabitacionListReponse();

            habitacionList = this.habitacionService.GetEntities();
            return View(habitacionList.data);
        }

        // GET: HabitacionHttpController/Details/5
        public ActionResult Details(int id)
        {
            HabitacionDetailReponse habitacionDetail = new HabitacionDetailReponse();
            habitacionDetail = this.habitacionService.GetEntity(id);
            return View(habitacionDetail.data);
        }

        // GET: HabitacionHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HabitacionAddDto habitacionAdd)
        {
            try
            {
                HabitacionAddReponse habitacionAdd1 = new HabitacionAddReponse();
                habitacionAdd1 = this.habitacionService.Add(habitacionAdd);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            HabitacionDetailReponse habitacionDetail = new HabitacionDetailReponse();
            habitacionDetail = this.habitacionService.GetEntity(id);
            return View(habitacionDetail.data);
        }

        // POST: HabitacionHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HabitacionUpdateDto habitacionUpdate)
        {
            try
            {
                HabitacionUpdateReponse habitacionUpdate1 = new HabitacionUpdateReponse();

                habitacionUpdate1 = this.habitacionService.Update(habitacionUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
