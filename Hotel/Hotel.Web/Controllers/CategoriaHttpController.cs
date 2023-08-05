using Hotel.Web.Api.ApiService;
using Hotel.Web.Models.Categoria.Request;
using Hotel.Web.Models.Categoria.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class CategoriaHttpController : Controller
    {
        private readonly ICategoriaApiService categoriaHttpService;
        public CategoriaHttpController(ICategoriaApiService categoriaHttpService)
        {
            this.categoriaHttpService = categoriaHttpService;
        }
        // GET: CategoriaHttpController
        public ActionResult Index()
        {
            try
            {
                CategoriaListResponse categoriaList = new CategoriaListResponse();

                categoriaList = categoriaHttpService.Get();

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

        // GET: CategoriaHttpController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaDetailsResponse usuario = new CategoriaDetailsResponse();

                usuario = categoriaHttpService.GetById(id);

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

        // GET: CategoriaHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaAddRequest categoriaAdd)
        {
            try
            {
                var result = categoriaHttpService.Add(categoriaAdd);

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

        // GET: CategoriaHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaDetailsResponse categoriadetail = new CategoriaDetailsResponse();
            categoriadetail = this.categoriaHttpService.GetById(id);

            return View(categoriadetail.Data);
        }

        // POST: CategoriaHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaUpdateRequest categoriaUpdate)
        {
            try
            {
                var result = categoriaHttpService.Update(categoriaUpdate);

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
