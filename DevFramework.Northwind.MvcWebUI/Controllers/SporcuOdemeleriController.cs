using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class SporcuOdemeleriController : Controller
    {
        private ISporcuOdemeleriService _sporcuOdemeleriService;
        // GET: SporcuOdemeleri
        public SporcuOdemeleriController(ISporcuOdemeleriService sporcuOdemeleriService)
        {
            _sporcuOdemeleriService = sporcuOdemeleriService;
        }

        public ActionResult Aylik(int ?id)
        {
            ViewBag.sporcuid = id;
            TempData["sporcuid"] = id;
            return View();
        }

        public ActionResult SporcuOdemelerGetir(int id)
        {
            var model = new SporcuOdemeleriListViewModel
            {
                sporcuOdemeleridetay = _sporcuOdemeleriService.GetSporcuOdemeleriDetay().Where(i=>i.SporcuId==id).OrderByDescending(i=>i.Yil).ToList()
            };
        
            return Json(new { data = model.sporcuOdemeleridetay }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SporcuOdemelerKayit(int id)
        {
            var model = new SporcuOdemeleriListViewModel
            {
                SporcuOdemeGet = _sporcuOdemeleriService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SporcuOdemelerKayit(SporcuOdemeleriListViewModel sporcuodemeleris)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (sporcuodemeleris.SporcuOdemeGet.Id > 0)
                {
                    //Edit 
                    var model = new SporcuOdemeleriListViewModel
                    {
                        SporcuOdemeGet = _sporcuOdemeleriService.Update(sporcuodemeleris.SporcuOdemeGet)
                    };
                }
                else
                {
                    sporcuodemeleris.SporcuOdemeGet.SporcuId = Convert.ToInt32(TempData["sporcuid"]);
                    //Save
                    var model = new SporcuOdemeleriListViewModel
                    {
                        
                        SporcuOdemeGet = _sporcuOdemeleriService.Add(sporcuodemeleris.SporcuOdemeGet)
                    };

                }

                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}