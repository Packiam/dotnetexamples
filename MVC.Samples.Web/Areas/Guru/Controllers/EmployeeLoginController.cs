using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Areas.Guru.Models;
using MVC.Samples.Web.Controllers;
using MVC.Samples.Web.Helper;

namespace MVC.Samples.Web.Areas.Guru.Controllers
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
            GuruModel model;
            ILoginSession loginSession;
            try
            {
                loginSession = new EmployeeLoginProcess();
                string empId = login.EmployeeCode;
                string pass = login.Password;

                //String password = Session["Password"]?.ToString();
                //String employeeId = Session["EmployeeId"]?.ToString();
                //model = UserSessionHandler.ReadUserSession(empId,pass);
                model = loginSession.ReadUserSession(empId);

                if (model == null) { ViewBag.ErrorMessage = "Wrong Username"; return View(); }
                string employeeId = model.EmployeeCode;
                string password = model.Password;
                if (empId == null || pass == null) { return View(); }
                if (empId == employeeId && pass == password) { Session["LOGIN_USERNAME"] = "Guru, Admin"; return RedirectToAction("Employee", "EmployeeLogin", new { area = "Guru" }); }
                ViewBag.ErrorMessage = "Wrong UserName or Password";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }


        [Authorize]
        [CustomAuthorize1("Admin", "EndUser")]
        public ActionResult Employee()
        {
            return View();
        }
    }
}