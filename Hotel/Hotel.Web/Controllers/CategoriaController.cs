using Hotel.Application.Contract;
using Hotel.Application.Dto.Categoria;
using Hotel.Infrastructure.Models;
using Hotel.Web.Models.Categoria.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        // GET: categoriaController
        public ActionResult Index()
        {

            var result = this.categoriaService.Get();

            if (!result.Success)    
                ViewBag.Message = result.Message;

            var categorias = result.Data;

            if (categorias == null)
                throw new Exception();

            List<CategoriaResponse> categoriaResponses = new List<CategoriaResponse>();

            foreach(var categoria in categorias)
            {
                CategoriaResponse categoriaResponse = new CategoriaResponse()
                {
                    IdCategoria = categoria.IdCategoria,
                    Descripcion = categoria.Descripcion
                };

                categoriaResponses.Add(categoriaResponse);
            }

            return View(categoriaResponses);

        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            var result = categoriaService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var departmet = result.Data as CategoriaModels;

            return View(departmet);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaAddDto categoriaAddDto)
        {
            try
            {

                var result = this.categoriaService.Add(categoriaAddDto);


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
            var result = categoriaService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var departmet = result.Data as CategoriaModels;

            return View(departmet);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaUpdateDto categoriaUpdateDto)
        {
            try
            {
                var result = this.categoriaService.Update(categoriaUpdateDto);


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

