using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Contract;
using Hotel.web.Models;
using Hotel.Application.Dtos.EstadoHabitacion;



namespace Hotel.web.Controllers
{
    public class EstadohabitacionController : Controller
    {
        private readonly IEstadoHabitacionService estadoHabitacionService;

        public EstadohabitacionController(IEstadoHabitacionService estadoHabitacionService)
        {
            this.estadoHabitacionService = estadoHabitacionService;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            var result = estadoHabitacionService.Get();

            if ((bool)!result.Success)
                    ViewBag.Message = result.Message;
           
            var Estadohabitacions = result.Data;

            List <EstadoHabitacionModel> estadoHabitacionModels = new List<EstadoHabitacionModel>();

            foreach( var estados in Estadohabitacions)
            {
                {
                    EstadoHabitacionModel estadoHabitacionModel = new EstadoHabitacionModel
                    {
                        IdEstadoHabitacion = estados.IdEstadoHabitacion,
                        Descripcion = estados.Descripcion
                    };

                    estadoHabitacionModels.Add(estadoHabitacionModel);
                }
            }

            return View (estadoHabitacionModels);

        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var result = this.estadoHabitacionService.GetById(id);

            if ((bool)!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var Estadohabitacions =result.Data;

            EstadoHabitacionModel estadoHabitacionModel = new Models.EstadoHabitacionModel
            {
                IdEstadoHabitacion = Estadohabitacions.IdEstadoHabitacion,
                Descripcion = Estadohabitacions.Descripcion
            };

           
            return View(estadoHabitacionModel);




        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoHabitacionAddDto estadoHabitacionAddDto)
        {
            try
            {

                var Estadohabitacion = new EstadoHabitacionAddDto()
                {
                    Descripcion = estadoHabitacionAddDto.Descripcion,
                    CambioUsuario = 1,
                    CambioFecha = DateTime.Now

                };

                var result = this.estadoHabitacionService.Add(Estadohabitacion);

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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var result = estadoHabitacionService.GetById(id);

            if ((bool)!result.Success)
                ViewBag.Message = result.Message;

            var Estadohabitacions = result.Data;

            EstadoHabitacionModel estadoHabitacionModel = new Models.EstadoHabitacionModel
            {
                IdEstadoHabitacion = Estadohabitacions.IdEstadoHabitacion,
                Descripcion = Estadohabitacions.Descripcion

            };


            return View(estadoHabitacionModel);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstadoHabitacionModel estadoHabitacionModel)
        {
            try
            {
                var Estadohabitacions = new EstadoHabitacionUpdateDto()
                {
                    IdEstadoHabitacion = estadoHabitacionModel.IdEstadoHabitacion,
                    Descripcion = estadoHabitacionModel.Descripcion,
                    CambioUsuario = 1,
                    CambioFecha = DateTime.Now

                };

                var result = this.estadoHabitacionService.Update(Estadohabitacions);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
