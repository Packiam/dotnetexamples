using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Areas.Ravi.Models;
using MVC.Samples.Web.Controllers;

namespace MVC.Samples.Web.Areas.Ravi.Controllers
{
    public class EmployeeLoginController : BaseController
    {
        // GET: Guru/EmployeeLogin
        public ActionResult Index()
        {
            try
            {
                ///if (!Session.IsNewSession) { Session.Clear(); }
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

                String UserId = Session["UserId"]?.ToString();
                String employeeid = Session["EmployeeId"]?.ToString();

                //string val = "admin";
                if (user == null || pass == null) { return View(); }
                if (user == UserId && pass == employeeid) { Session["LOGIN_USERNAME"] = "Ravi, Admin"; return RedirectToAction("Employee", "EmployeeLogin", new { area = "Ravi" }); }
                ViewBag.ErrorMessage = "Wrong Password";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }
        [Authorize]
        public ActionResult Employee()
        {
            return View();
        }
    }
}