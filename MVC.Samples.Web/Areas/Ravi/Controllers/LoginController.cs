using MVC.Samples.Web.Areas.Ravi.Helper;
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
            RaviUserModel model;
            try
            {
                string user = login.Name;
                string pass = login.Password;

                if(user == null) { ViewBag.ErrorMessage = "Wrong Usename";return View(); }

                model = SessionHandler.ReadUserSession(user);
                if(model == null) { ViewBag.ErrorMessage = "Wrong Usename"; return View(); }

                string userId = model.Name;
                string password = model.Password;
                
                if(user == null || pass == null) { return View(); }
                if (user == userId && pass == password) 
                { 
                    Session["LOGIN_USERNAME"] = "ravi,admin"; 
                    return RedirectToAction("Contact", "Home", new { area = "Ravi" }); 
                }

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