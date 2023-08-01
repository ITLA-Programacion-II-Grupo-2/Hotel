using Hotel.Application.Contract;
using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Application.Service;
using Hotel.Infrastructure.Models;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Models.Piso.Request;
using Hotel.Web.Models.Piso.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class PisoController : Controller
    {
        private readonly IPisoService pisoService;

        public PisoController(IPisoService pisoService)
        {
            this.pisoService = pisoService;
        }

        // GET: CategoriaController
        public ActionResult Index()
        {

            var result = this.pisoService.Get();

            if (!result.Success)
                ViewBag.Message = result.Message;

            var pisos = result.Data;

            if (pisos == null)
                throw new Exception();

            List<PisoResponseModel> pisoResponses = new List<PisoResponseModel>();

            foreach (var piso in pisos)
            {
                PisoResponseModel pisoResponse = new PisoResponseModel()
                {
                    IdPiso = piso.IdPiso,
                    Descripcion = piso.Descripcion
                };

                pisoResponses.Add(pisoResponse);
            }

            return View(pisoResponses);

        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = pisoService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var piso = result.Data as PisoModels;

                if (piso == null)
                    throw new Exception("No existe el piso.");

                PisoResponseModel pisoResponse = piso.ConvertGetByIdToCategoriaResponse();

                return View(pisoResponse);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PisoAddRequest pisoAddDto)
        {
            try
            {
                var piso = pisoAddDto.ConvertAddRequestToAddDto();

                var result = this.pisoService.Add(piso);

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

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = pisoService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var piso = result.Data as PisoModels;

                if (piso == null)
                    throw new Exception("No existe el piso.");

                PisoUpdateRequest pisoToUpdate = piso.ConvertPisoToUpdateRequest();

                return View(pisoToUpdate);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PisoUpdateRequest pisoUpdate)
        {
            try
            {
                var piso = pisoUpdate.ConvertirUpdateRequestToUpdateDto();

                var result = this.pisoService.Update(piso);

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
