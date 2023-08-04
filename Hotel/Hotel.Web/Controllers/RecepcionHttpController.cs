using Hotel.Web.Api.ApiServices.Interfaces;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models.Recepcion.Request;
using Hotel.Web.Models.Recepcion.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RecepcionHttpController : Controller
    {
        private readonly IRecepcionHttpService recepcionHttpService;

        public RecepcionHttpController(IRecepcionHttpService recepcionHttpService)
        {
            this.recepcionHttpService = recepcionHttpService;
        }

        // GET: RecepcionApiControlador
        public ActionResult Index()
        {
            try
            {
                RecepcionListResponse recepcionList = new RecepcionListResponse();

                recepcionList = recepcionHttpService.Get();

                if (!recepcionList.Success)
                    throw new Exception(recepcionList.Message);


                return View(recepcionList.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RecepcionApiControlador/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                RecepcionDetailsResponse recepcion = new RecepcionDetailsResponse();

                recepcion = recepcionHttpService.GetById(id);

                if (!recepcion.Success)
                    throw new Exception(recepcion.Message);


                return View(recepcion.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RecepcionApiControlador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionApiControlador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecepcionAddRequest recepcionAdd)
        {
            try
            {
                var result = recepcionHttpService.Add(recepcionAdd);

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

        // GET: RecepcionApiControlador/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                RecepcionDetailsResponse recepcion = new RecepcionDetailsResponse();

                recepcion = recepcionHttpService.GetById(id);

                if (!recepcion.Success)
                    throw new Exception(recepcion.Message);
                if (recepcion.Data == null)
                    throw new Exception("Recepcion nula");

                RecepcionUpdateRequest recepcionUpdate = recepcion.Data.ConvertModelToRequest();

                return View(recepcionUpdate);

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: RecepcionApiControlador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecepcionUpdateRequest recepcionUpdate)
        {
            try
            {
                var result = recepcionHttpService.Update(recepcionUpdate);

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

        // GET: RecepcionApiControlador/Delete/5
        public ActionResult Delete(int id)
        {
            RecepcionRemoveRequest recepcionRemove = new RecepcionRemoveRequest(id);

            return View(recepcionRemove);
        }

        // POST: RecepcionApiControlador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RecepcionRemoveRequest recepcionRemove)
        {
            try
            {
                var result = recepcionHttpService.Remove(recepcionRemove);

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
