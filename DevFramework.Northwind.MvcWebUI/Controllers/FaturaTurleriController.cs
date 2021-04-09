using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class FaturaTurleriController : Controller
    {
        private IFaturaTurleriService _faturaTurleriService;
        public FaturaTurleriController(IFaturaTurleriService faturaTurleriService)
        {
            _faturaTurleriService = faturaTurleriService;
        }
        // GET: FaturaTurleri
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FaturaTurleriList()
        {
            return View();

        }
        public ActionResult FaturaTurleriGetir()
        {
            var model = new FaturaTurleriListViewModel
            {
                faturaTurleris = _faturaTurleriService.GetAll()
            };
            return Json(new { data = model.faturaTurleris }, JsonRequestBehavior.AllowGet);

        }
        //Fatura türlerini getirme forma
        [HttpGet]
        public ActionResult FaturaTurleriKayit(int id)
        {

            var model =new FaturaTurleriListViewModel
            {
                faturaTurleriGet = _faturaTurleriService.GetById(id)
            };
            return View(model);
        }
        //faturaturleri kaydetme ve güncelleme action
        [HttpPost]
        public ActionResult FaturaTurleriKayit(FaturaTurleriListViewModel faturaTurleries)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (faturaTurleries.faturaTurleriGet.Id > 0)
                {
                    //Edit 
                    var model = new FaturaTurleriListViewModel
                    {
                        faturaTurleriGet = _faturaTurleriService.Update(faturaTurleries.faturaTurleriGet)
                    };
                }
                else
                {
                    //Save
                    var model = new FaturaTurleriListViewModel
                    {
                        faturaTurleriGet = _faturaTurleriService.Add(faturaTurleries.faturaTurleriGet)
                    };

                }

                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }
        //fatura türleri göster 
        [HttpGet]
        public ActionResult FaturaTurleriSil(int id)
        {
            var model = new FaturaTurleriListViewModel
            {
                faturaTurleriGet = _faturaTurleriService.GetById(id)
            };
            return View(model);
        }
        //faturatürleri sil
        [HttpPost]
        [ActionName("FaturaTurleriSil")]
        public ActionResult Delete(int id)
        {
            bool status = false;
            if (id != 0)
            {
                _faturaTurleriService.Delete(id);
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}