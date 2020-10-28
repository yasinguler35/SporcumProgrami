using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class SporcuKategoriController : Controller
    {
        private ISporcuKategoriService _sporcuKategoriService;
        public SporcuKategoriController(ISporcuKategoriService sporcuKategoriService)
        {
            _sporcuKategoriService = sporcuKategoriService;
        }
        // GET: SporcuKategori
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SporcuKategoriList()
        {
            return View();

        }
        public ActionResult SporcuKategoriGetir()
        {
            var model = new SporcuKategoriListViewModel
            {
                SporcuKategories = _sporcuKategoriService.GetAll()
            };
            return Json(new { data = model.SporcuKategories }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult SporcuKategoriKayit(int id)
        {

            var model = new SporcuKategoriListViewModel
            {
                SporcuKategoriGet = _sporcuKategoriService.GetById(id)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SporcuKategoriKayit(SporcuKategoriListViewModel sporcukategories)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (sporcukategories.SporcuKategoriGet.Id > 0)
                {
                    //Edit 
                    var model = new SporcuKategoriListViewModel
                    {
                        SporcuKategoriGet = _sporcuKategoriService.Update(sporcukategories.SporcuKategoriGet)
                    };
                }
                else
                {
                    //Save
                    var model = new SporcuKategoriListViewModel
                    {
                        SporcuKategoriGet = _sporcuKategoriService.Add(sporcukategories.SporcuKategoriGet)
                    };

                }

                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult SporcuKategoriSil(int id)
        {
            var model = new SporcuKategoriListViewModel
            {
                SporcuKategoriGet = _sporcuKategoriService.GetById(id)
            };
            return View(model);
        }

        [HttpPost]
        [ActionName("SporcuKategoriSil")]
        public ActionResult Delete(int id)
        {
            bool status = false;
            if (id != 0)
            {
                _sporcuKategoriService.Delete(id);
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

    }
}