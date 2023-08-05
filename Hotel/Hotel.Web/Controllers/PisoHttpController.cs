using Hotel.Web.Api.ApiService;
using Hotel.Web.Http.HttpServices;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class PisoHttpController : Controller
    {
        private readonly IPisoApiService pisoHttpService;
        public PisoHttpController(IPisoApiService pisoHttpService)
        {
            this.pisoHttpService = pisoHttpService;
        }
        // GET: PisoHttpController
        public ActionResult Index()
        {
            try
            {
                PisoListResponse pisoList = new PisoListResponse();

                pisoList = pisoHttpService.Get();

                if (!pisoList.Success)
                    throw new Exception(pisoList.Message);


                return View(pisoList.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
            // GET: PisoHttpController/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PisoHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PisoHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PisoAddRequest pisoadd)
        {
            try
            {
                var result = pisoHttpService.Add(pisoadd);

                if (!result.Success)
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

        // GET: PisoHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            PisoDetailsResponse pisodetail = new PisoDetailsResponse();
            pisodetail = this.pisoHttpService.GetById(id);

            return View(pisodetail.Data);
        }

        // POST: PisoHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PisoUpdateRequest pisoUpdate)
        {
            try
            {
                var result = pisoHttpService.Update(pisoUpdate);

                if (!result.Success)
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
