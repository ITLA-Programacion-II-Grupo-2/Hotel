using Hotel.Application.Contract;
using Hotel.Infrastructure.Models;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models.Usuario;
using Hotel.Web.Models.Usuario.Request;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            try
            {
                var result = usuarioService.GetUsuariosWithRol();

                if (!result.Success)
                    throw new Exception(result.Message);

                var usuarios = result.Data as List<UserWithRolModel>;

                if (usuarios == null)
                    throw new Exception("No hay usuarios.");

                List<UsuarioResponse> usuariosResponses = usuarios
                .Select(p => p.ConvertUserWithRolToUsuarioResponse()).ToList();

                return View(usuariosResponses);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = usuarioService.GetUsuarioWithRol(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var usuario = result.Data as UserWithRolModel;

                if (usuario == null)
                    throw new Exception("No existe el usuario.");

                    UsuarioResponse usuarioResponse = usuario.ConvertUserWithRolToUsuarioResponse();

                return View(usuarioResponse);
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAddRequest usuarioAdd)
        {
            try
            {
                var usuario = usuarioAdd.ConvertAddRequestToAddDto();

                var result = this.usuarioService.Add(usuario);

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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = usuarioService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var usuario = result.Data as UsuarioModel;

                if (usuario == null)
                    throw new Exception("No existe el usuario.");

                UsuarioUpdateRequest usuarioToUpdate = usuario.ConvertUsuarioToUpdateRequest();

                return View(usuarioToUpdate);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateRequest usuarioUpdate)
        {
            try
            {
                var usuario = usuarioUpdate.ConvertUpdateRequestToUpdateDto();

                var result = this.usuarioService.Update(usuario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioRemoveRequest usuarioRemove = new UsuarioRemoveRequest(id);

            return View(usuarioRemove);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioRemoveRequest usuarioRemove)
        {
            try
            {
                var usuario = usuarioRemove.ConvertRemoveDtoToRemoveRequest();

                var result = this.usuarioService.Remove(usuario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
