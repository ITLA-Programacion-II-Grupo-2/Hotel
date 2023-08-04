using Hotel.Web.Api.ApiServices.Interfaces;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Http.Interfaces;
using Hotel.Web.Models.Usuario.Request;
using Hotel.Web.Models.Usuario.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class UsuarioHttpController : Controller
    {
        private readonly IUsuarioHttpService usuarioHttpService;
        public UsuarioHttpController(IUsuarioHttpService usuarioHttpService)
        {
            this.usuarioHttpService = usuarioHttpService;
        }

        // GET: UsuarioApiController
        public ActionResult Index()
        {
            try
            {
                UsuarioListResponse usuarioList = new UsuarioListResponse();

                usuarioList = usuarioHttpService.Get();

                if (!usuarioList.Success)
                    throw new Exception(usuarioList.Message);


                return View(usuarioList.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioApiController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
               UsuarioDetailsResponse usuario = new UsuarioDetailsResponse();

                usuario = usuarioHttpService.GetById(id);

                if (!usuario.Success)
                    throw new Exception(usuario.Message);


                return View(usuario.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAddRequest usuarioAdd)
        {
            try
            {
                var result = usuarioHttpService.Add(usuarioAdd);

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

        // GET: UsuarioApiController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                UsuarioDetailsResponse usuario = new UsuarioDetailsResponse();

                usuario = usuarioHttpService.GetById(id);

                if (!usuario.Success)
                    throw new Exception(usuario.Message);
                if (usuario.Data == null)
                    throw new Exception("Usuario nulo");

                UsuarioUpdateRequest usuarioUpdate = usuario.Data.ConvertUsuarioToUpdateRequest();

                return View(usuarioUpdate);

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: UsuarioApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateRequest usuarioUpdate)
        {
            try
            {
                var result = usuarioHttpService.Update(usuarioUpdate);

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

        // GET: UsuarioApiController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioRemoveRequest usuarioRemove = new UsuarioRemoveRequest(id);

            return View(usuarioRemove);
        }

        // POST: UsuarioApiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioRemoveRequest usuarioRemove)
        {
            try
            {
                var result = usuarioHttpService.Remove(usuarioRemove);

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
