using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Areas.Ravi.Models;
using MVC.Samples.Web.Controllers;
using static MVC.Samples.Web.Areas.Ravi.Helper.SessionHandler;

namespace MVC.Samples.Web.Areas.Ravi.Controllers
{
    public class EmployeeLoginController : BaseController
    {
        // GET: Guru/EmployeeLogin
        public ActionResult Index()
        {
            try
            {
               
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
                string empId = login.EmployeeCode;
                string pass = login.Password;

                loginSession = new EmployeeLoginProcess();
                model = loginSession.ReadUserSession(empId);

                string employeeId = model.EmployeeCode;
                string password = model.Password;

                //string val = "admin";
                if (empId == null || pass == null) { return View(); }
                if (empId == employeeId && pass == password) { Session["LOGIN_USERNAME"] = "Ravi, Admin"; return RedirectToAction("Employee", "EmployeeLogin", new { area = "Ravi" }); }
                
                ViewBag.ErrorMessage = "Invalid Credentials";
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