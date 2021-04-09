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
    }
}