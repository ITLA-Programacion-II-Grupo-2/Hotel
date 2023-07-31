﻿using Hotel.Application.Contract;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models.RolUsuario.Request;
using Hotel.Web.Models.RolUsuario.Response;
using Microsoft.AspNetCore.Mvc;
using RolUsuarioIModel = Hotel.Infrastructure.Models.RolUsuarioModel;
using RolUsuarioModel = Hotel.Web.Models.RolUsuario.RolUsuarioModel;

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
            try
            {
                var result = rolUsuarioService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var rolUsuarios = result.Data as List<RolUsuarioIModel>;

                if (rolUsuarios == null)
                    throw new Exception("No hay usuarios.");

                List<RolUsuarioModel> rolUsuarioList = rolUsuarios
                .Select(p => p.ConvertModelToWebModel()).ToList();

                return View(rolUsuarioList);
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
                var result = rolUsuarioService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var rolUsuario = result.Data as RolUsuarioIModel;

                if (rolUsuario == null)
                    throw new Exception("No hay usuarios.");

                RolUsuarioModel rolUsuarioModel = rolUsuario.ConvertModelToWebModel();

                return View(rolUsuarioModel);
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
                var rolUsuario = rolUsuarioAdd.ConvertAddRequestToDto();

                var result = rolUsuarioService.Add(rolUsuario);

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
                var result = rolUsuarioService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var rolUsuario = result.Data as RolUsuarioIModel;

                if (rolUsuario == null)
                    throw new Exception("No hay usuarios.");

                RolUsuarioUpdateRequest rolUsuarioUpdate = rolUsuario.ConvertModelToUpdateRequest();

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
                var rolUsuario = rolUsuarioUpdate.ConvertUpdateRequestToDto();

                var result = rolUsuarioService.Update(rolUsuario);

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
                var rolUsuario = rolUsuarioRemove.ConvertRemoveRequestToDto();

                var result = rolUsuarioService.Remove(rolUsuario);

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
