using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class KusakOdemeleriController : Controller
    {
        private IKusaklarService _kusaklarService;
        private IKusakOdemeleriService _kusakOdemleriService;
        public KusakOdemeleriController(IKusakOdemeleriService kusakOdemleriService, IKusaklarService kusaklarService)
        {
            _kusakOdemleriService = kusakOdemleriService;
            _kusaklarService = kusaklarService;
        }
        // GET: KusakOdemeleri
        public ActionResult Index(int ?id)
        {
            TempData["sporcuid"] = id;
            return View();
        }
        public ActionResult KusakOdemeleriList()
        {
         
            return View();

        }
        public ActionResult KusakOdemeleriGetir(int Id)
        {
            var model = new KusakOdemeleriListViewModel
            {
                kusakOdemleriDetays = _kusakOdemleriService.GetKusakOdemleriDetay().Where(i=>i.SporcuId==Id).ToList()
            };
            return Json(new { data = model.kusakOdemleriDetays }, JsonRequestBehavior.AllowGet);

        }
        //kusakları getirme forma
        [HttpGet]
        public ActionResult KusakOdemeleriKayit(int Id)
        {
            //kusaklar  drobdowlisti doldurma
            var modelkusak = new KusaklarListViewModel
            {
                kusaklars = _kusaklarService.GetAll()
            };
            ViewBag.kusaklargoster = modelkusak.kusaklars.OrderByDescending(i => i.Id);


            var model = new KusakOdemeleriListViewModel
            {
               kusakOdemeleriDetayGet =_kusakOdemleriService.GetKusakOdemleriDetay().FirstOrDefault(i => i.Id == Id)
            };
            return View(model);
        }
    }
}