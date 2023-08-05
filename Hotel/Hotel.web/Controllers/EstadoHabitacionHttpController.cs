
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.web.Models.Response.Estadohabitacion;
using Hotel.web.Servicios_Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.web.Controllers
{
    public class EstadoHabitacionHttpController : Controller
    {
        private readonly IEstadoHabitacionService estadoHabitacionService;

        public EstadoHabitacionHttpController(IEstadoHabitacionService estadoHabitacionService)
        {
            this.estadoHabitacionService = estadoHabitacionService;
        }
        // GET: EstadoHabitacionHttpController
        public ActionResult Index()
        {
            EstadohabitacionListReponse estadohabitacionList = new EstadohabitacionListReponse();
            estadohabitacionList = this.estadoHabitacionService.GetEntities();

            return View(estadohabitacionList.data);
        }

        // GET: EstadoHabitacionHttpController/Details/5
        public ActionResult Details(int id)
        {
            EstadoHabitacionDetailResponse estadoHabitacionDetail = new EstadoHabitacionDetailResponse();

            estadoHabitacionDetail = this.estadoHabitacionService.GetEntity(id);

            return View(estadoHabitacionDetail.Data);

        }

        // GET: EstadoHabitacionHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoHabitacionHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoHabitacionAddDto estadoHabitacionAdd)
        {
            try
            {
                EstadoHabitacionAddResponse estadoHabitacionAdd1 = new EstadoHabitacionAddResponse();

                estadoHabitacionAdd1 = this.estadoHabitacionService.Add(estadoHabitacionAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoHabitacionHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            EstadoHabitacionDetailResponse estadoHabitacionDetail = new EstadoHabitacionDetailResponse();

            estadoHabitacionDetail = this.estadoHabitacionService.GetEntity(id);

            return View(estadoHabitacionDetail.Data);

        }

        // POST: EstadoHabitacionHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            try
            {
                EstadoHabitacionUpdateResponse estadoHabitacionUpdate1 = new EstadoHabitacionUpdateResponse();

                estadoHabitacionUpdate1 = this.estadoHabitacionService.Update(estadoHabitacionUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
