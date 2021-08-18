using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Areas.Ravi.Helper;
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
            ALoginProcess loginSession;
            try
            {
                loginSession = new EmpLoginAbstractProcess();
                string empId = login.EmployeeCode;
                string pass = login.Password;

                //String registeredPassword = Session["Password"]?.ToString();
                //String registeredEmpCode = Session["EmployeeId"]?.ToString();

                model = loginSession.ReadUserSession(empId);

                if (model == null) { ViewBag.ErrorMessage = "Wrong Username"; return View(); }
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