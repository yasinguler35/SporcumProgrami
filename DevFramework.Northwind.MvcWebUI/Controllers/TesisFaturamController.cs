﻿using DevFramework.Northwind.Business.Abstract;
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
            _tesisFaturamService = tesisFaturamService;
        }
        public ActionResult TesisFaturamGetir()
        {
            var model = new TesisFaturamListViewModel
            {
                tesisFaturalariDetays = _tesisFaturamService.GetTesisFaturamDetay()
            };
            return Json(new { data = model.tesisFaturalariDetays }, JsonRequestBehavior.AllowGet);
        }
        // GET: Kusak
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TesisFaturamList()
        {
            return View();

        }
    }
}