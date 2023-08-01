using Hotel.Web.Api.ApiService;
using Hotel.Web.Models.Categoria.Response;
using Hotel.Web.Models.Piso.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class PisoApiController : Controller
    {
        private readonly IPisoApiService pisoApiService;
        public PisoApiController(IPisoApiService pisoApiService)
        {
            this.pisoApiService = pisoApiService;
        }

        // GET: CategoriaApiController
        public ActionResult Index()
        {
            try
            {
                PisoListResponse pisoList = new PisoListResponse();

                pisoList = pisoApiService.Get();

                if (!pisoList.Success)
                    throw new Exception(pisoList.Message);


                return View(pisoList.Data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }


    }
}
