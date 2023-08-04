using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RolUsuarioHttpController : Controller
    {
        private readonly IRolUsuarioHttpService rolUsuarioHttpService;

        public RolUsuarioHttpController(IRolUsuarioHttpService rolUsuarioHttpService)
        {
            this.rolUsuarioHttpService = rolUsuarioHttpService;
        }

        // GET: RolUsuarioApiController
        public ActionResult Index()
        {
            try
            {
                RolUsuarioListResponse rolUsuarioList = new RolUsuarioListResponse();

                rolUsuarioList = rolUsuarioHttpService.Get();

                if (!rolUsuarioList.Success)
                    throw new Exception(rolUsuarioList.Message);


                return View(rolUsuarioList.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RolUsuarioApiController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                RolUsuarioDetailsResponse rolUsuario = new RolUsuarioDetailsResponse();

                rolUsuario = rolUsuarioHttpService.GetById(id);

                if (!rolUsuario.Success)
                    throw new Exception(rolUsuario.Message);


                return View(rolUsuario.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RolUsuarioApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsuarioApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolUsuarioAddRequest rolUsuarioAdd)
        {
            try
            {
                var result = rolUsuarioHttpService.Add(rolUsuarioAdd);

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

        // GET: RolUsuarioApiController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                RolUsuarioDetailsResponse rolUsuario = new RolUsuarioDetailsResponse();

                rolUsuario = rolUsuarioHttpService.GetById(id);

                if (!rolUsuario.Success)
                    throw new Exception(rolUsuario.Message);
                if (rolUsuario.Data == null)
                    throw new Exception("Rol usuario nulo");

                RolUsuarioUpdateRequest rolUsuarioUpdate = rolUsuario.Data.ConvertModelToUpdateRequest();

                return View(rolUsuarioUpdate);

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: RolUsuarioApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RolUsuarioUpdateRequest rolUsuarioUpdate)
        {
            try
            {
                var result = rolUsuarioHttpService.Update(rolUsuarioUpdate);

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

        // GET: RolUsuarioApiController/Delete/5
        public ActionResult Delete(int id)
        {
            RolUsuarioRemoveRequest rolUsuarioRemove = new RolUsuarioRemoveRequest(id);

            return View(rolUsuarioRemove);
        }

        // POST: RolUsuarioApiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RolUsuarioRemoveRequest rolUsuarioRemove)
        {
            try
            {
                var result = rolUsuarioHttpService.Remove(rolUsuarioRemove);

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
