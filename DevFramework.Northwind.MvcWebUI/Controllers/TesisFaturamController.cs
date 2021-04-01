using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class TesisFaturamController : Controller
    {
        private ITesisFaturamService _tesisFaturamService;
        private IFaturaTurleriService _faturaTurleriService;
        public TesisFaturamController(ITesisFaturamService tesisFaturamService, IFaturaTurleriService faturaTurleriService)
        {
            _tesisFaturamService = tesisFaturamService;
            _faturaTurleriService = faturaTurleriService;
        }
        public ActionResult TesisFaturamGetir()
        {
            var model = new TesisFaturamListViewModel
            {
                tesisFaturalariDetays = _tesisFaturamService.GetTesisFaturamDetay()
            };
            return Json(new { data = model.tesisFaturalariDetays }, JsonRequestBehavior.AllowGet);
        }
        // GET: Kusak
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TesisFaturamList()
        {
            return View();

        }
        //tesisfaturam getirme forma
        [HttpGet]
        public ActionResult TesisFaturamKayit(int id)
        {

            var model = new TesisFaturamListViewModel
            {
                tesisFaturamGet = _tesisFaturamService.GetById(id)
            };
            return View(model);
        }
        //tesisfaturam kaydetme ve güncelleme action
        [HttpPost]
        public ActionResult TesisFaturamKayit(TesisFaturamListViewModel tesisFaturams)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (tesisFaturams.tesisFaturamGet.Id > 0)
                {
                    //Edit 
                    var model = new TesisFaturamListViewModel
                    {
                        tesisFaturamGet = _tesisFaturamService.Update(tesisFaturams.tesisFaturamGet)
                    };
                }
                else
                {
                    //Save
                    var model = new TesisFaturamListViewModel
                    {
                        tesisFaturamGet = _tesisFaturamService.Add(tesisFaturams.tesisFaturamGet)
                    };

                }

                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }
        //kusaklari göster 
        [HttpGet]
        public ActionResult TesisFaturamSil(int id)
        {
            var model = new TesisFaturamListViewModel
            {
                tesisFaturamGet = _tesisFaturamService.GetById(id)
            };
            return View(model);
        }
        //kusaklari sil
        [HttpPost]
        [ActionName("TesisFaturamSil")]
        public ActionResult Delete(int id)
        {
            bool status = false;
            if (id != 0)
            {
                _tesisFaturamService.Delete(id);
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        void faturaturugetir()
        {
            var model = new FaturaTurleriListViewModel
            {
                faturaTurleris = _faturaTurleriService.GetAll()
            };
            ViewBag.faturaturugoster = model.faturaTurleris.OrderByDescending(i => i.Id);
        }

    }
}