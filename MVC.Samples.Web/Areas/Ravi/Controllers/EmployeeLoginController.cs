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

                String registeredName = Session["UserId"]?.ToString();
                String registerdEmpCode = Session["EmployeeId"]?.ToString();

                //string val = "admin";
                if (user == null || pass == null) { return View(); }
                if (user == registeredName && pass == registerdEmpCode) { Session["STUDENT_USER"] = "Ravi, Admin"; return RedirectToAction("Employee", "EmployeeLogin", new { area = "" }); }
                
                ViewBag.ErrorMessage = "Invalid Credentials";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }
    
        public ActionResult Employee()
        {
            return View();
        }
    }
}