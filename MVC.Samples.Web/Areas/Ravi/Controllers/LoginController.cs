using MVC.Samples.Web.Areas.Ravi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Areas.Ravi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Ravi/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            string user = login.Name;
            string pass = login.Password;
            string val = "admin";
            if(user == val && pass == val)
            {
                return RedirectToAction("About", "Home", new { area = "" });
            }
            else
            {
                ViewBag.ErrorMessage = "Name and password are not equal";
                return View();
            }
        }
    }
}