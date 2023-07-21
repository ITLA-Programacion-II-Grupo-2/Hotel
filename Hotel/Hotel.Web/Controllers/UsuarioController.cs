using Hotel.Application.Contract;
using Hotel.Application.Dtos.Usuario;
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
            var result = usuarioService.GetUsuariosWithRol();

            if (!result.Success)
                ViewBag.Message = result.Message;

            var usuarios = result.Data;

            if (usuarios == null)
                throw new Exception();

            List<UsuarioResponse> usuariosResponses = new List<UsuarioResponse>();

            foreach (var usuarioWithRolModel in usuarios)
            {
                UsuarioResponse usuarioResponse = new UsuarioResponse
                {
                    IdUsuario = usuarioWithRolModel.IdUsuario,
                    NombreCompleto = usuarioWithRolModel.NombreCompleto,
                    Correo = usuarioWithRolModel.Correo,
                    RolUsuario = usuarioWithRolModel.Rol
                };

                usuariosResponses.Add(usuarioResponse);
            }

            return View(usuariosResponses);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            var result = usuarioService.GetUsuarioWithRol(id);

            if (!result.Success)
                ViewBag.Message = result.Message;
            var usuario = result.Data;

            if (usuario == null)
                throw new Exception();

            UsuarioResponse usuarioResponse = new UsuarioResponse
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                RolUsuario = usuario.Rol
            };

            return View(usuarioResponse);
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
                var usuario = new UsuarioAddDto()
                {
                    NombreCompleto =  usuarioAdd.NombreCompleto,
                    Correo = usuarioAdd.Correo,
                    Clave =  usuarioAdd.Clave,
                    IdRolUsuario = usuarioAdd.IdRolUsuario,
                    ChangeUser = 1,
                    ChangeDate = DateTime.Now
                };

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
            var result = usuarioService.GetUsuario(id);

            if (!result.Success)
                ViewBag.Message = result.Message;

            var usuario = result.Data;

            if (usuario == null)
                throw new Exception();


            UsuarioUpdateRequest usuarioToUpdate = new UsuarioUpdateRequest
            {
                IdUsuario = id,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = usuario.IdRolUsuario
            };

            return View(usuarioToUpdate);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateRequest usuarioUpdate)
        {
            try
            {
                var usuario = new UsuarioUpdateDto()
                {
                    IdUsuario = usuarioUpdate.IdUsuario,
                    NombreCompleto = usuarioUpdate.NombreCompleto,
                    Correo = usuarioUpdate.Correo,
                    IdRolUsuario = usuarioUpdate.IdRolUsuario,
                    ChangeUser = 1,
                    ChangeDate = DateTime.Now
                };

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
            UsuarioRemoveRequest usuarioRemove = new UsuarioRemoveRequest()
            {
                IdUsuario = 11
            };

            return View(usuarioRemove);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioRemoveRequest usuarioRemove)
        {
            try
            {
                var usuario = new UsuarioRemoveDto()
                {
                    IdUsuario = id,
                    ChangeUser = 1,
                    ChangeDate = DateTime.Now
                };

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
