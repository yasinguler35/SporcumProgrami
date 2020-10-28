
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class SporcuController : Controller
    {

        private ISporcuService _sporcuService;
        private ISporcuFotoService _sporcuFotoService;
        private ISporcuKategoriService _sporcuKategoriService;
        //private ISporcuDal _sporcuDal;
        public SporcuController(/*ISporcuDal sporcuDal,*/ ISporcuService sporcuService, ISporcuFotoService sporcuFotoService, ISporcuKategoriService sporcuKategoriService)
        {
            //_sporcuDal = sporcuDal;
            _sporcuKategoriService = sporcuKategoriService;
            _sporcuService = sporcuService;
            _sporcuFotoService = sporcuFotoService;
        }
        // GET: Sporcu
        //Sporcu İndex sayfası
        public ActionResult Index()
        {
            return View();
        }
        //sporcuların listelendiği sayfa
        public ActionResult SporcuList()
        {
            return View();
        }
        //datatable sporcuları getiren method datatablelistler.js dosyasında kullanılıyor
        public ActionResult SporcuGetir()
        {
            var model = new SporcuListViewModel
            {
                Sporcus=_sporcuService.GetAll()
            };
           return Json(new { data = model.Sporcus}, JsonRequestBehavior.AllowGet);
        }

        //datatable sporcuları kaydeden ve güncelleyen method datatablelistler.js dosyasında kullanılıyor
        [HttpGet]
        public ActionResult SporcuKayit(int id)
        {
            
            var model = new SporcuListViewModel
            {
                SporcuGet = _sporcuService.GetById(id)
            };
            fotogetir();
            kategorigetir();
            return View(model);
        }

        void fotogetir()
        {
            var modelfoto = new SporcuFotoListViewModel
            {
                SporcuFotos = _sporcuFotoService.GetAll()
            };
            ViewBag.sporfotogoster = modelfoto.SporcuFotos.OrderByDescending(i => i.Id);
        }
        void kategorigetir()
        {
            var modelfoto = new SporcuKategoriListViewModel
            {
                SporcuKategories = _sporcuKategoriService.GetAll()
            };
            ViewBag.sporkategorigoster = modelfoto.SporcuKategories.OrderByDescending(i => i.Id);
        }
        [HttpPost]
        public ActionResult SporcuKayit(SporcuListViewModel sporcus)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                    if (sporcus.SporcuGet.Id > 0)
                    {
                    //Edit 
                    var model = new SporcuListViewModel
                    {
                        SporcuGet = _sporcuService.Update(sporcus.SporcuGet)
                    };
                    }
                    else
                    {
                    //Save
                    var model = new SporcuListViewModel
                    {
                        SporcuGet = _sporcuService.Add(sporcus.SporcuGet)
                    };
                 
                }
                    
                    status = true;
                
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult SporcuSil(int id)
        {
            var model = new SporcuListViewModel
            {
                SporcuGet = _sporcuService.GetById(id)
            };
            return View(model);
        }

        [HttpPost]
        [ActionName("SporcuSil")]
        public ActionResult Delete(int id)
        {
            bool status = false;
            if (id!=0)
            {
                _sporcuService.Delete(id);
                status = true;
            }
          
            return new JsonResult { Data = new { status = status } };
        }

    }
}