using Hotel.Web.ApiServices;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RolUsuarioController : Controller
    {
        private readonly IRolUsuarioApiService rolUsuarioApiService;

        public RolUsuarioController(IRolUsuarioApiService rolUsuarioApiService)
        {
            this.rolUsuarioApiService = rolUsuarioApiService;
        }

        // GET: RolUsuarioController
        public ActionResult Index()
        {
            try
            {
                RolUsuarioListResponse rolUsuarioList = new RolUsuarioListResponse();

                rolUsuarioList = rolUsuarioApiService.Get();

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

        // GET: RolUsuarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                RolUsuarioDetailsResponse rolUsuario = new RolUsuarioDetailsResponse();

                rolUsuario = rolUsuarioApiService.GetById(id);

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

        // GET: RolUsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolUsuarioAddRequest rolUsuarioAdd)
        {
            try
            {
                var result = rolUsuarioApiService.Add(rolUsuarioAdd);

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

        // GET: RolUsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                RolUsuarioDetailsResponse rolUsuario = new RolUsuarioDetailsResponse();

                rolUsuario = rolUsuarioApiService.GetById(id);

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

        // POST: RolUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RolUsuarioUpdateRequest rolUsuarioUpdate)
        {
            try
            {
                var result = rolUsuarioApiService.Update(rolUsuarioUpdate);

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

        // GET: RolUsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            RolUsuarioRemoveRequest rolUsuarioRemove = new RolUsuarioRemoveRequest(id);

            return View(rolUsuarioRemove);
        }

        // POST: RolUsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RolUsuarioRemoveRequest rolUsuarioRemove)
        {
            try
            {
                var result = rolUsuarioApiService.Remove(rolUsuarioRemove);

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
