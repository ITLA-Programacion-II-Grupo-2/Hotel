using Hotel.Application.Contract;
using Hotel.Application.Dtos.EstadoHabitacion;
using Hotel.web.Models.Response;
using Hotel.web.Models.Response.Estadohabitacion;
using Hotel.web.Models.Response.Habitacion;
using Hotel.web.Servicios_Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.web.Controllers
{
    public class EstadohabitacionApiController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private string baseUrl = "http://localhost:5068/api/EstadoHabitacion/";
        private readonly EstadoHabitacionA estadoHabitacionA;

        public EstadohabitacionApiController(IConfiguration configuration, EstadoHabitacionA estadoHabitacionA)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.estadoHabitacionA = estadoHabitacionA;
        }
        // GET: EstadohabitacionApiController
        public ActionResult Index()
        {
            EstadohabitacionListReponse estadohabitacionList = new EstadohabitacionListReponse();
            estadohabitacionList = this.estadoHabitacionA.GetEntities();

            return View(estadohabitacionList.data);
        }

        // GET: EstadohabitacionApiController/Details/5
        public ActionResult Details(int id)
        {
            EstadoHabitacionDetailResponse estadoHabitacionDetail = new EstadoHabitacionDetailResponse();

            estadoHabitacionDetail = this.estadoHabitacionA.GetEntity(id);

            return View(estadoHabitacionDetail.Data);
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
            EstadoHabitacionAddResponse? estadoHabitacionAdd1 = new EstadoHabitacionAddResponse();

            try
            {
                estadoHabitacionAdd1 = this.estadoHabitacionA.Add(estadoHabitacionAdd);
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
            EstadoHabitacionDetailResponse estadohabitacionDetail = new EstadoHabitacionDetailResponse();

            estadohabitacionDetail = this.estadoHabitacionA.GetEntity(id);

            return View(estadohabitacionDetail.Data);
        }

        // POST: EstadohabitacionApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstadoHabitacionUpdateDto estadoHabitacionUpdate)
        {
            try
            {
                var estadoHabitacionUpdate1 = new EstadoHabitacionUpdateResponse();

                estadoHabitacionUpdate1 = this.estadoHabitacionA.Update(estadoHabitacionUpdate);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
