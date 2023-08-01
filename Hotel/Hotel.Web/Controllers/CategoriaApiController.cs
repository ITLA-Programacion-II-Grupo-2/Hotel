using Hotel.Web.Api.ApiService;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Controllers.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class CategoriaApiController : Controller
    {
        private readonly ICategoriaApiService categoriaApiService;
        public CategoriaApiController(ICategoriaApiService categoriaApiService)
        {
            this.categoriaApiService = categoriaApiService;
        }

        // GET: CategoriaApiController
        public ActionResult Index()
        {
            try
            {
                CategoriaListResponse categoriaList = new CategoriaListResponse();

                categoriaList = categoriaApiService.Get();

                if (!categoriaList.Success)
                    throw new Exception(categoriaList.Message);


                return View(categoriaList.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoriaApiController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaDetailsResponse categoria = new CategoriaDetailsResponse();

                categoria = categoriaApiService.GetById(id);

                if (!categoria.Success)
                    throw new Exception(categoria.Message);


                return View(categoria.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoriaApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaAddRequest categoriaAdd)
        {
            try
            {
                var result = categoriaApiService.Add(categoriaAdd);

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
                CategoriaDetailsResponse categoria = new CategoriaDetailsResponse();

                categoria = categoriaApiService.GetById(id);

                if (!categoria.Success)
                    throw new Exception(categoria.Message);
                if (categoria.Data == null)
                    throw new Exception("Usuario nulo");

                 //CategoriaUpdateRequest categoriaUpdate = categoria.Data.ConvertCategoriaToUpdateRequest();

               return View();

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
        public ActionResult Edit(int id, CategoriaUpdateRequest categoriaUpdate)
        {
            try
            {
                var result = categoriaApiService.Update(categoriaUpdate);

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

