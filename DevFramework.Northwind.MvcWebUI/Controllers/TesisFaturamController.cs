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
        public TesisFaturamController(ITesisFaturamService tesisFaturamService)
        {
            tesisFaturamService = _tesisFaturamService;
        }
        public ActionResult TesisFaturamGetir()
        {
            var model = new TesisFaturamListViewModel
            {
                tesisFaturams = _tesisFaturamService.GetAll()
            };
            return Json(new { data = model.tesisFaturams }, JsonRequestBehavior.AllowGet);
        }
    }
}