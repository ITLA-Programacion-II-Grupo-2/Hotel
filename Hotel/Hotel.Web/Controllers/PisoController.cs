using Hotel.Application.Contract;
using Hotel.Application.Dto.Categoria;
using Hotel.Application.Dto.Piso;
using Hotel.Infrastructure.Models;
using Hotel.Web.Models.Categoria.Response;
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

        // GET: categoriaController
        public ActionResult Index()
        {

            var result = this.pisoService.Get();

            if (!result.Success)
                ViewBag.Message = result.Message;

            var pisos = result.Data;

            if (pisos == null)
                throw new Exception();

            List<PisoResponse> pisoResponses = new List<PisoResponse>();

            foreach (var piso in pisos)
            {
                PisoResponse pisoResponse = new PisoResponse()
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
            var result = pisoService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var piso = result.Data as CategoriaModels;

            return View(piso);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PisoAddDto pisoAddDto)
        {
            try
            {

                var result = this.pisoService.Add(pisoAddDto);


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
            var result = pisoService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var piso = result.Data as PisoModels;

            return View(piso);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PisoUpdateDto pisoUpdateDto)
        {
            try
            {
                var result = this.pisoService.Update(pisoUpdateDto);


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
