using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Areas.Guru.Models;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class LoginController : Controller
    {
        // GET: Guru/LogIn
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            string user = login.UserName;
            string pass = login.Password;
            string val = "admin";
            if (user != null && pass != null)
            {
                if (user == val && pass == val)
                {
                    return RedirectToAction("About", "Home", new { area = "" });
                }
                else
                {
                    ViewBag.ErrorMessage = "Name and password are not equal";
                    return View();
                }
            }
            return View();
        }
    }
}
