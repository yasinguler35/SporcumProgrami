using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class TesisDemirbaslarController : Controller
    {
        private ITesisDemirbaslarService _tesisDemirbaslar;
        public TesisDemirbaslarController(ITesisDemirbaslarService tesisDemirbaslar)
        {
            _tesisDemirbaslar = tesisDemirbaslar;
        }
        // GET: TesisDemirbaslar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TesisDemirbaslarList()
        {
            return View();

        }
        public ActionResult TesisDemirbaslarGetir()
        {
            var model = new TesisDemirbaslarListViewModel
            {
                tesisDemirbaslars = _tesisDemirbaslar.GetAll()
            };
            return Json(new { data = model.tesisDemirbaslars }, JsonRequestBehavior.AllowGet);

        }
    }
}