using Hotel.Application.Contract;
using Hotel.Application.Dtos.Habitacion;
using Hotel.Application.Services;
using Hotel.Domain.Entities;
using Hotel.web.Models;
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

            var habitacions = result.Data;

            List<HabitacionModel> habitacionModels = new List<HabitacionModel>();

            foreach (var habitacion in habitacions)
            {
                {
                    HabitacionModel habitacionModel = new HabitacionModel
                    {
                       IdHabitacion = habitacion.IdHabitacion,
                       Numero= habitacion.Numero,
                       Detalle = habitacion.Detalle,
                       Precio = habitacion.Precio,
                       IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                       IdCategoria = habitacion.IdCategoria,
                       IdPiso = habitacion.IdPiso
                    };

                    habitacionModels.Add(habitacionModel);
                }
            }

            return View(habitacionModels);
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
            var habitacion = result.Data;

            HabitacionModel habitacionModel = new Models.HabitacionModel
            {
                IdHabitacion = habitacion.IdHabitacion,
                Numero = habitacion.Numero,
                Detalle = habitacion.Detalle,
                Precio = habitacion.Precio,
                IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                IdCategoria = habitacion.IdCategoria,
                IdPiso = habitacion.IdPiso
            };


            return View(habitacionModel);
        }

        // GET: HabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HabitacionAddDto habitacionAddDto)
        {
            try
            {
                var habitacion = new HabitacionAddDto()
                {
                    Numero = habitacionAddDto.Numero,
                    Detalle = habitacionAddDto.Detalle,
                    Precio = habitacionAddDto.Precio,
                    IdEstadoHabitacion = habitacionAddDto.IdEstadoHabitacion,
                    IdCategoria = habitacionAddDto.IdCategoria,
                    IdPiso = habitacionAddDto.IdPiso,
                    CambioUsuario = 1,
                    CambioFecha = DateTime.Now

                };

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
            var habitacion = result.Data;

            HabitacionModel habitacionModel = new Models.HabitacionModel
            {
                IdHabitacion = habitacion.IdHabitacion,
                Numero = habitacion.Numero,
                Detalle = habitacion.Detalle,
                Precio = habitacion.Precio,
                IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                IdCategoria = habitacion.IdCategoria,
                IdPiso = habitacion.IdPiso
            };


            return View(habitacionModel);
        }

        // POST: HabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HabitacionModel habitacionModel)
        {
            try
            {
                
                    var habitacion = new HabitacionUpdateDto()
                    {
                        IdHabitacionId = habitacionModel.IdHabitacion,
                        Numero = habitacionModel.Numero,
                        Detalle = habitacionModel.Detalle,
                        Precio = habitacionModel.Precio,
                        IdEstadoHabitacion = habitacionModel.IdEstadoHabitacion,
                        IdCategoria = habitacionModel.IdCategoria,
                        IdPiso = habitacionModel.IdPiso,
                        CambioUsuario = 1,
                        CambioFecha = DateTime.Now

                    };

                    var result = this.habitacionService.Update(habitacion);
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
