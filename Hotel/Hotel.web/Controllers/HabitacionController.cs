using Hotel.Application.Contract;
using Hotel.Application.Dtos.Habitacion;
using Hotel.Application.Services;
using Hotel.Domain.Entities;
using Hotel.web.Controllers.Extenciones;
using Hotel.web.Models;
using Hotel.web.Models.Response.Habitacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.web.Controllers
{
    public class HabitacionController : Controller
    {
        private readonly IHabitacionService habitacionService;

        public HabitacionController(IHabitacionService habitacionService)
        {
            this.habitacionService = habitacionService;
        }
        // GET: HabitacionController
        public ActionResult Index()
        {
            var result = habitacionService.Get();

            if ((bool)!result.Success)
                ViewBag.Message = result.Message;

            var habitacions = result.Data as List<HabitacionModel>;

            List<HabitacionReponse> habitacionReponses = habitacions.Select(h => h.ConvertModelToResponse()).ToList();



            return View(habitacionReponses);
        }

        // GET: HabitacionController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.habitacionService.GetById(id);

            if ((bool)!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var habitacions = result.Data as List<HabitacionModel>;

            List<HabitacionReponse> habitacionReponses = habitacions.Select(h => h.ConvertModelToResponse()).ToList();


            return View(habitacionReponses);
        }

        // GET: HabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HabitacionAddReponse habitacionAdd)
        {
            try
            {
                var habitacion = habitacionAdd.ConvertRequestToDto();

                var result = this.habitacionService.Add(habitacion);

                if ((bool)!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.habitacionService.GetById(id);

            if ((bool)!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var habitacion = result.Data as HabitacionModel;

           

            HabitacionUpdateReponse habitacionUpdate = habitacion.ConvertModelToRequest();



            return View(habitacionUpdate);


        }

        // POST: HabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HabitacionUpdateReponse habitacionUpdate)
        {
            try
            {

                var habitacion = habitacionUpdate.ConvertRequestToDto();

                var result = this.habitacionService.Update(habitacion);

                if ((bool)!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
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
