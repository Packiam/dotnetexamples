using MVC.Samples.BLL.Interfaces.Ravi;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using MVC.Samples.Data.Models.Ravi;
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
        MyDatabase myDatabase = new MyDatabase();
        private readonly IRegistration registration;

        public LoginController(IRegistration registration)
        {
            this.registration = registration;
        }
        // GET: Ravi/Login
        public ActionResult Index()
        {
            if (!Session.IsNewSession) { Session.Clear(); }
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin user)
        {
            string name = user.Name;
            if(registration.ValidateUser(user) == "ok")
            {
                Session["User_Name"] = user.Name;
                ViewBag.SuccessLogin = "Logged in Successfully";
                return RedirectToAction("Contact", "Home", new { area="Ravi" });
            }
            return View();

           /* RaviUserModel model;
            ALoginProcess loginSession;

            try
            {
                loginSession = new UserLoginAbstractProcess();

                string user = login.Name;
                string pass = login.Password;

                if(user == null) { ViewBag.ErrorMessage = "Wrong Usename";return View(); }

                //model = SessionHandler.ReadUserSession(user);
                model = loginSession.ReadUserSession(user);
                if (model == null) { ViewBag.ErrorMessage = "Wrong Usename"; return View(); }

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
            } */
        }
    }
}