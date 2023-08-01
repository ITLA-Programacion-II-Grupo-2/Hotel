using Hotel.Application.Contract;
using Hotel.Application.Dto.Categoria;
using Hotel.Infrastructure.Models;
using Hotel.Web.Controllers.Extentions;
using Hotel.Web.Models.Categoria.Request;
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

        // GET: CategoriaController
        public ActionResult Index()
        {

            var result = this.categoriaService.Get();

            if (!result.Success)
                ViewBag.Message = result.Message;

            var categorias = result.Data;

            if (categorias == null)
                throw new Exception();

            List<CategoriaResponseModel> categoriaResponses = new List<CategoriaResponseModel>();

            foreach (var categoria in categorias)
            {
                CategoriaResponseModel categoriaResponse = new CategoriaResponseModel()
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
            try
            {
                var result = categoriaService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var categoria = result.Data as CategoriaModels;

                if (categoria == null)
                    throw new Exception("No existe la categoria.");

                CategoriaResponseModel categoriaResponse = categoria.ConvertGetByIdToCategoriaResponse();

                return View(categoriaResponse);
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
        public ActionResult Create(CategoriaAddRequest categoriaAddDto)
        {
            try
            {
                var categoria = categoriaAddDto.ConvertAddRequestToAddDto();

                var result = this.categoriaService.Add(categoria);

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
                var result = categoriaService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var categoria = result.Data as CategoriaModels;

                if (categoria == null)
                    throw new Exception("No existe la categoria.");

                CategoriaUpdateRequest categoriaToUpdate = categoria.ConvertCategoriaToUpdateRequest();

                return View(categoriaToUpdate);
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
        public ActionResult Edit(int id, CategoriaUpdateRequest categoriaUpdate)
        {
            try
            {
                var categoria = categoriaUpdate.ConvertirUpdateRequestToUpdateDto();

                var result = this.categoriaService.Update(categoria);

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

