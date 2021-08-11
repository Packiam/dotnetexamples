using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Areas.Guru.Models;
using MVC.Samples.Web.Controllers;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Guru/LogIn
        public ActionResult Index()
        {
            try
            {
                ///if (!Session.IsNewSession) { Session.Clear(); }
                TempData["MyData"] = "Guru";
                Session["Session_MyData"] = "Guru Session";
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
                string user = login.UserName;
                string pass = login.Password;

                String UserId = Session["UserId"]?.ToString();
                String password = Session["Password"]?.ToString();

                //string val = "admin";
                string val1 = TempData["MyData"]?.ToString();
                string session = Session["Session_MyData"]?.ToString();
                if (user == null || pass == null) { return View(); }
                if (user == UserId && pass == password) { Session["LOGIN_USERNAME"] = "Guru, Admin"; return RedirectToAction("About", "Home", new { area = "" }); }

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
