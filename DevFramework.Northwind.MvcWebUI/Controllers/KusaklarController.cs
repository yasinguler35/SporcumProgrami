using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class KusaklarController : Controller
    {

        private IKusaklarService _kusaklarService;
        public KusaklarController(IKusaklarService kusaklarService)
        {
            _kusaklarService = kusaklarService;
        }
        // GET: Kusak
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KusaklarList()
        {
            return View();

        }
        public ActionResult KusaklarGetir()
        {
            var model = new KusaklarListViewModel
            {
                kusaklars = _kusaklarService.GetAll()
            };
            return Json(new { data = model.kusaklars }, JsonRequestBehavior.AllowGet);

        }
        //kusakları getirme forma
        [HttpGet]
        public ActionResult KusaklarKayit(int id)
        {

            var model = new KusaklarListViewModel
            {
                kusaklarGet = _kusaklarService.GetById(id)
            };
            return View(model);
        }
        //kusak kaydetme ve güncelleme action
        [HttpPost]
        public ActionResult KusaklarKayit(KusaklarListViewModel kusaklars)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (kusaklars.kusaklarGet.Id > 0)
                {
                    //Edit 
                    var model = new KusaklarListViewModel
                    {
                        kusaklarGet = _kusaklarService.Update(kusaklars.kusaklarGet)
                    };
                }
                else
                {
                    //Save
                    var model = new KusaklarListViewModel
                    {
                        kusaklarGet = _kusaklarService.Add(kusaklars.kusaklarGet)
                    };

                }

                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }
        //kusaklari göster 
        [HttpGet]
        public ActionResult KusaklarSil(int id)
        {
            var model = new KusaklarListViewModel
            {
                kusaklarGet = _kusaklarService.GetById(id)
            };
            return View(model);
        }
        //kusaklari sil
        [HttpPost]
        [ActionName("KusaklarSil")]
        public ActionResult Delete(int id)
        {
            bool status = false;
            if (id != 0)
            {
                _kusaklarService.Delete(id);
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}