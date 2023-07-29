using Hotel.Application.Contract;
using Hotel.Infrastructure.Models;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models.Recepcion;
using Hotel.Web.Models.Recepcion.Request;
using Microsoft.AspNetCore.Mvc;
using RecepcionResponse = Hotel.Web.Models.Recepcion.RecepcionResponse;

namespace Hotel.Web.Controllers
{
    public class RecepcionController : Controller
    {
        private readonly IRecepcionService recepcionService;
        public RecepcionController(IRecepcionService recepcionService)
        {
            this.recepcionService = recepcionService;
        }

        // GET: RecepcionController
        public ActionResult Index()
        {
            try
            {
                var result = recepcionService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var recepciones = result.Data as List<RecepcionModel>;

                if (recepciones == null)
                    throw new Exception("No hay recepciones.");

                List<RecepcionResponse> recepcionResponses = recepciones
                .Select(r => r.ConvertModelToResponse()).ToList();

                return View(recepcionResponses);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RecepcionController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = recepcionService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var recepcion = result.Data as RecepcionModel;

                if (recepcion == null)
                    throw new Exception("No hay recepciones.");

                RecepcionResponse recepcionResponse = recepcion.ConvertModelToResponse();

                return View(recepcionResponse);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RecepcionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecepcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecepcionAddRequest recepcionAdd)
        {
            try
            {
                var recepcion = recepcionAdd.ConvertRequestToDto();

                var result = this.recepcionService.Add(recepcion);

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

        // GET: RecepcionController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = recepcionService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var recepcion = result.Data as RecepcionModel;

                if (recepcion == null)
                    throw new Exception("No hay recepciones.");

                RecepcionUpdateRequest recepcionUpdate = recepcion.ConvertModelToRequest();

                return View(recepcionUpdate);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: RecepcionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecepcionUpdateRequest recepcionUpdate)
        {
            try
            {
                var recepcion = recepcionUpdate.ConvertRequestToDto();

                var result = this.recepcionService.Update(recepcion);

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

        // GET: RecepcionController/Delete/5
        public ActionResult Delete(int id)
        {
            RecepcionRemoveRequest recepcionRemove = new RecepcionRemoveRequest(id);
            return View(recepcionRemove);
        }

        // POST: RecepcionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RecepcionRemoveRequest recepcionRemove)
        {
            try
            {
                var recepcion = recepcionRemove.ConvertRequestToDto();

                var result = this.recepcionService.Remove(recepcion);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
