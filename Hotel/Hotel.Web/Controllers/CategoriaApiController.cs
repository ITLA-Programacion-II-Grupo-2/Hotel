﻿using Hotel.Web.Api.ApiService;
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
            CategoriaDetailsResponse categoriadetail = new CategoriaDetailsResponse();
            categoriadetail = this.categoriaApiService.GetById(id);

            return View(categoriadetail.Data);
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



        // GET: CategoriaApiController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaDetailsResponse categoriadetail = new CategoriaDetailsResponse();
            categoriadetail = this.categoriaApiService.GetById(id);

            return View(categoriadetail.Data);
        }

        // POST: CategoriaApiController/Edit/5
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

