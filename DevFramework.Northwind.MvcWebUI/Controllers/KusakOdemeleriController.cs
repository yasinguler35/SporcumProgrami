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
        private IKusakOdemeleriService _kusakOdemleriService;
        public KusakOdemeleriController(IKusakOdemeleriService kusakOdemleriService)
        {
            _kusakOdemleriService = kusakOdemleriService;
        }
        // GET: KusakOdemeleri
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KusakOdemeleriList()
        {
            return View();

        }
        public ActionResult KusakOdemleriGetir()
        {
            var model = new KusakOdemeleriListViewModel
            {
                kusakOdemleriDetays = _kusakOdemleriService.GetKusakOdemleriDetay()
            };
            return Json(new { data = model.kusakOdemleris }, JsonRequestBehavior.AllowGet);

        }
    }
}