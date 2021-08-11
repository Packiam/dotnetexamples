using MVC.Samples.Web.Areas.Ravi.Models;
using MVC.Samples.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Areas.Ravi.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Ravi/Login
        public ActionResult Index()
        {
            try
            {
                TempData["MyData"] = "ravi";
                Session["Session_MyData"] = "ravi Session";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        public ActionResult Index(LoginModel login)
        {
            try
            {
                string user = login.Name;
                string pass = login.Password;

                string registeduser = Session["Name"]?.ToString();
                string registedPassword = Session["Password"]?.ToString();

                if(user == null || pass == null) { return View(); }
                if (user == registeduser && pass == registedPassword) { Session["LOGIN_USERNAME"] = "ravi,admin"; return RedirectToAction("About", "Home", new { area = "" }); }


                ViewBag.ErrorMessage = "Invalid Credentials";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }
    }
}