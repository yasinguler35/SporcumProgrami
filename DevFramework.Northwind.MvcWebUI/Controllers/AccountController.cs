﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Login()
        {
            return View();
        }
        // GET: Account
        [HttpPost]
        public ActionResult Login(string userName,string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user!= null)
            {
                AuthenticationHelper.CreateAuthCookie(
                new Guid(), user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                _userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray(),
                false,
                user.FirstName,
                user.LastName);
                return RedirectToAction("Index", "Sporcu");
            }
            return View();
        }
    }
}