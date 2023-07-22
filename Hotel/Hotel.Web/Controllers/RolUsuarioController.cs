using Hotel.Application.Contract;
using Hotel.Web.Controllers.Adapters;
using Hotel.Web.Models.RolUsuario.Response;
using Hotel.Web.Models.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RolUsuarioController : Controller
    {
        private readonly IRolUsuarioService rolUsuarioService;

        public RolUsuarioController(IRolUsuarioService rolUsuarioService)
        {
            this.rolUsuarioService = rolUsuarioService;
        }

        // GET: RolUsuarioController
        public ActionResult Index()
        {
            var result = rolUsuarioService.GetRolUsuarios();

            if (!result.Success)
                ViewBag.Message = result.Message;

            var rolUsuarios = result.Data;

            if (rolUsuarios == null)
                throw new Exception();

            List<RolUsuarioResponse> rolUsuariosResponses = new List<RolUsuarioResponse>();

            foreach (var rol in rolUsuarios)
            {
                RolUsuarioResponse rolUsuarioResponse = new RolUsuarioResponse()
                {
                    IdRolUsuario = rol.IdRolUsuario,
                    Rol = rol.Rol
                };

                rolUsuariosResponses.Add(rolUsuarioResponse);
            }

            return View(rolUsuariosResponses);
        }

        // GET: RolUsuarioController/Details/5
        public ActionResult Details(int id)
        {
            var result = rolUsuarioService.

            if (!result.Success)
                ViewBag.Message = result.Message;

            var rolUsuario = result.Data;

            if (rolUsuario == null)
                throw new Exception();

            RolUsuarioResponse rolUsuarioResponse = new RolUsuarioResponse()
            {
                IdRolUsuario = rolUsuario.IdRolUsuario,
                Rol = rolUsuario.Rol
            };

            return View(rolUsuarioResponse);
        }

        // GET: RolUsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: RolUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: RolUsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
