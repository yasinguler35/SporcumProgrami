using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class SporcuFotoController : Controller
    {
        private ISporcuFotoService _sporcuFotoService;
        public SporcuFotoController(ISporcuFotoService sporcuFotoService)
        {
            _sporcuFotoService = sporcuFotoService;
        }
        // GET: SporcuFoto
        public ActionResult Index()
        {
            var model = new SporcuFotoListViewModel
            {
                SporcuFotos = _sporcuFotoService.GetAll().OrderByDescending(i=>i.Id).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }


            //Save
            var model = new SporcuFoto {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            };
            _sporcuFotoService.Add(model);

            return RedirectToAction("Index");
        }
    }
}