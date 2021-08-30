using MVC.Samples.Web.Areas.Ravi.Models;
using MVC.Samples.Web.Controllers;
using MVC.Samples.Web.Areas.Ravi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Areas.Ravi.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Ravi/Home
        [HttpGet]
        public ActionResult Index()
        {
            RaviUserModel raviuserModel;
            try
            {
                raviuserModel = new RaviUserModel();
               
                return View();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
            finally
            {
                raviuserModel = null;
            }
        }


        [HttpPost]
        public ActionResult Index(RaviUserModel raviUser)
        {
            //SessionHandler.AddUserSession(raviUser);

            Session["UserId"] = raviUser.Name;
            Session["Password"] = raviUser.Password;
            Session["EmployeeId"] = raviUser.EmployeeCode;

            return RedirectToAction("Contact", "Home", new { area = "Ravi" });
        }


        [CustomAuthorize1("Admin", "EndUser")]
        public ActionResult About()
        {
            return View();
        }

        [CustomAuthorize1("Admin", "EndUser")]
        public ActionResult Contact()
        {

            return View();
        }
    }
}