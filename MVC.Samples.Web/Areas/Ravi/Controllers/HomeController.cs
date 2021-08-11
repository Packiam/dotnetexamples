using MVC.Samples.Web.Areas.Ravi.Models;
using MVC.Samples.Web.Controllers;
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
        public ActionResult Index(RaviUserModel raviuser)
        {

            string pass = raviuser.Password;
            string confpass = raviuser.ConformPassword;
            
            if(pass == confpass)
            {
                Session["Name"] = raviuser.Name;
                Session["Password"] = raviuser.Password;
                return RedirectToAction("Contact", "Home", new { area = "" });
            }

            return View();
        }

       
    }
}