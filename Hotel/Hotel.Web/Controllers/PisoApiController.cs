using Hotel.Web.Api.ApiService;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class PisoApiController : Controller
    {
        private readonly IPisoApiService pisoApiService;
        public PisoApiController(IPisoApiService pisoApiService)
        {
            this.pisoApiService = pisoApiService;
        }

        // GET: PisoApiController
        public ActionResult Index()
        {
            try
            {
                PisoListResponse pisoList = new PisoListResponse();

                pisoList = pisoApiService.Get();

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

        // GET: PisoApiController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PisoDetailsResponse piso = new PisoDetailsResponse();

                piso = pisoApiService.GetById(id);

                if (!piso.Success)
                    throw new Exception(piso.Message);


                return View(piso.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PisoApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PisoApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PisoAddRequest pisoAdd)
        {
            try
            {
                var result = pisoApiService.Add(pisoAdd);

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

        // GET: PisoApiController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PisoDetailsResponse piso = new PisoDetailsResponse();

                piso = pisoApiService.GetById(id);

                if (!piso.Success)
                    throw new Exception(piso.Message);
                if (piso.Data == null)
                    throw new Exception("Piso nulo");

               // PisoUpdateRequest pisoUpdate = piso.Data.ConvertPisoToUpdateRequest();

                return View();

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PisooApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PisoUpdateRequest pisoUpdate)
        {
            try
            {
                var result = pisoApiService.Update(pisoUpdate);

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
