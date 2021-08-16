using MVC.Samples.Web.Areas.Ravi.Helper;
using MVC.Samples.Web.Areas.Ravi.Models;
using MVC.Samples.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVC.Samples.Web.Areas.Ravi.Helper.SessionHandler;

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
            ILoginSession loginSession;

            try
            {
                string user = login.Name;
                string pass = login.Password;
                if (user == null) { ViewBag.ErrorMessage = "Wrong Username"; return View(); }

                loginSession = new UserLoginProces();

                model = loginSession.ReadUserSession(user);

                if (model == null) { ViewBag.ErrorMessage = "Wrong Username"; return View(); }
                string userId = model.Name;
                string password = model.Password;


                if (user == null || pass == null) { return View(); }
                if (user == userId && pass == password)
                {
                    Session["LOGIN_USERNAME"] = "Ravi, Admin";
                    return RedirectToAction("About", "Home", new { area = "Ravi" });
                }
                ViewBag.ErrorMessage = "Wrong Password";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

    }
}