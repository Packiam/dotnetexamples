using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.BLL.Interfaces.Guru;
using MVC.Samples.Data;
using MVC.Samples.Data.Models.Guru;
using MVC.Samples.Web.Areas.Guru.Models;
using MVC.Samples.Web.Controllers;
using MVC.Samples.Web.Helper;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class LoginController : BaseController
    {
        MyDatabase myDatabase = new MyDatabase();
        private readonly IRegistration registration;

        public LoginController(IRegistration registration)
        {
            this.registration = registration;
        }
        // GET: Guru/LogIn
        
        public ActionResult Index()
        {
            try
            {
                ///if (!Session.IsNewSession) { Session.Clear(); }
                //TempData["MyData"] = "Guru";
                //Session["Session_MyData"] = "Guru Session";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        /*[HttpPost]
        public ActionResult Index_Interface(LoginModel login)
        {
            GuruModel model;
            ILoginSession loginSession;
            try
            {
                loginSession = new UserLoginProcess();
                string user = login.UserName;
                string pass = login.Password;
                if (user == null) { ViewBag.ErrorMessage = "Wrong Username"; return View(); }

                //model = UserSessionHandler.ReadUserSession(user);
                if (user == null || pass == null) { return View(); }
                if (myDatabase.userRegistrations.Any(x => x.Name == user) && myDatabase.userRegistrations.Any(x => x.Password == pass)) {
                    AddUserSession(GuruModel model);
                    return RedirectToAction("Index", "Home", new { area = "Guru" });
                }
                model = loginSession.ReadUserSession(user);
                if (model == null) { ViewBag.ErrorMessage = "Wrong Username"; return View(); }
                string userId = model.Name;
                string password = model.Password;

                //string userId = Session["UserId"]?.ToString();
                //string password = Session["Password"]?.ToString();
                //string val = "admin";

                //if (user == null || pass == null) { return View(); }
                if (user == userId && pass == password)
                {
                    Session["LOGIN_USERNAME"] = "Guru, Admin";
                    return RedirectToAction("Index", "Home", new { area = "Guru" });
                }
                ViewBag.ErrorMessage = "Wrong Password";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }*/

        [HttpPost]
        public ActionResult Index(UserLogin user)
        {
            //GuruModel model;
            //ALoginProcess loginSession;
            
                //loginSession = new UserLoginAbstractProcess();
                string name = user.Name;
                if (registration.ValidateUser(user) == "ok")
                {
                    Session["User_Name"] = user.Name;
                    ViewBag.SuccessLogin = "Logged in Successfully";
                    return RedirectToAction("Contact", "Home", new { area = "Ravi" });
                }
                return View();


                //model = UserSessionHandler.ReadUserSession(user);
                //model = loginSession.ReadUserSession(user);
                /*if (model == null) { ViewBag.ErrorMessage = "Wrong Username"; return View(); }
                string userId = model.Name;
                string password = model.Password;*/

                //string userId = Session["UserId"]?.ToString();
                //string password = Session["Password"]?.ToString();
                //string val = "admin";

                /*if (user == null || pass == null) { return View(); }
                if (user == userId && pass == password)
                {
                    Session["LOGIN_USERNAME"] = "Guru, Admin";
                    return RedirectToAction("Index", "Home", new { area = "Guru" });
                }*/
                
           
        }
        public ActionResult MyProfile()
        {
            return View();
        }
       



    }
}
