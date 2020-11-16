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
            Session["sporcuid"] = id;
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

            //kusaklar detay listeleme
            var model = new KusakOdemeleriListViewModel
            {
               kusakOdemeleriGet =_kusakOdemleriService.GetById(Id)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult KusakOdemeleriKayit(KusakOdemeleriListViewModel kusakodemeleris)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (kusakodemeleris.kusakOdemeleriGet.Id > 0)
                {
                    //Edit 
                    var model = new KusakOdemeleriListViewModel
                    {
                        kusakOdemeleriGet = _kusakOdemleriService.Update(kusakodemeleris.kusakOdemeleriGet)
                    };
                }
                else
                {
                    kusakodemeleris.kusakOdemeleriGet.SporcuId =Convert.ToInt32(Session["sporcuid"]);
                    //Save
                    var model = new KusakOdemeleriListViewModel
                    {
                        kusakOdemeleriGet = _kusakOdemleriService.Add(kusakodemeleris.kusakOdemeleriGet)
                    };

                }

                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}