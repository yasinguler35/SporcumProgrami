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
        [HttpGet]
        public ActionResult KusaklarKayit(int id)
        {

            var model = new KusaklarListViewModel
            {
                kusaklarGet = _kusaklarService.GetById(id)
            };
            return View(model);
        }
    }
}