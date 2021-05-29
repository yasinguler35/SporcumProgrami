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

        //tesisdemirbas getirme forma
        [HttpGet]
        public ActionResult TesisDemirbaslarKayit(int id)
        {
            var model = new TesisDemirbaslarListViewModel
            {
                tesisDemirbaslarGet = _tesisDemirbaslar.GetById(id)
            };
            return View(model);
        }
        //tesisdemirbas kaydetme ve güncelleme action
        [HttpPost]
        public ActionResult TesisFaturamKayit(TesisDemirbaslarListViewModel tesisDemirbas)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (tesisDemirbas.tesisDemirbaslarGet.Id > 0)
                {
                    //Edit 
                    var model = new TesisDemirbaslarListViewModel
                    {
                        tesisDemirbaslarGet = _tesisDemirbaslar.Update(tesisDemirbas.tesisDemirbaslarGet)
                    };
                }
                else
                {
                    //Save
                    var model = new TesisDemirbaslarListViewModel
                    {
                        tesisDemirbaslarGet = _tesisDemirbaslar.Add(tesisDemirbas.tesisDemirbaslarGet)
                    };

                }

                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }
       
    }
}