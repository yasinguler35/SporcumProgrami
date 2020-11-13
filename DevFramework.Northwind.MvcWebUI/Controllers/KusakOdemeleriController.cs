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
        private ISporcuService _sporcuService;
        private IKusakOdemeleriService _kusakOdemleriService;
        public KusakOdemeleriController(IKusakOdemeleriService kusakOdemleriService, ISporcuService sporcuService)
        {
            _kusakOdemleriService = kusakOdemleriService;
            _sporcuService = sporcuService;
        }
        // GET: KusakOdemeleri
        public ActionResult Index(int ?id)
        {
            TempData["sporcuid"] = id;
            return View();
        }
        public ActionResult KusakOdemeleriList()
        {
            //var modelfoto = new SporcuListViewModel
            //{
            //    Sporcus = _sporcuService.GetAll()
            //};
            //ViewBag.sporcugoster = new SelectList (modelfoto.Sporcus.ToList(),"Id","AdSoyad");
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
    }
}