using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.BLL.Interfaces.Guru;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using MVC.Samples.Data.Models.Guru;
using MVC.Samples.Web.Areas.Guru.Models;
using MVC.Samples.Web.Controllers;
using MVC.Samples.Web.Helper;
using MVC.Samples.Web.Models;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class LoginController : BaseController
    {
        MyDatabase myDatabase = new MyDatabase();
        MenuModel menu = new MenuModel();
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

        [HttpPost]
        public ActionResult Index(UserLogin user)
        {
            UserRegistration userModel = null;
            //string message = registration.ValidateUser(user, out userModel);
            //if (!string.IsNullOrEmpty(message)) { ViewBag.Message = message; return View(); }
            //UserSessionHandler.ClearUserSession();
            //if (userModel.Role == "Admin")
            //{
            //    UserSessionHandler.AddRoleSession(new MenuModel()
            //    {
            //        MenuName = "MasterScreen",
            //        Action = "Index",
            //        ControllerName = "Crud"
            //    });
            //}
            //else if (userModel.Role == "EndUser")
            //{
            //    UserSessionHandler.AddRoleSession(new MenuModel()
            //    {
            //        MenuName = "MyProfile",
            //        Action = "Details",
            //        ControllerName = "Crud"
            //    });
            //}
            // return RedirectToAction("Contact", "Home", new { area = "Ravi" });

            string name = user.Name;
            string loginRole = Session["MenuDetails"]?.ToString();
            if (!string.IsNullOrEmpty(loginRole))
            {
                if (registration.ValidateUser(user, out userModel) == "ok")
                {
                    Session["User_Name"] = name;
                    ViewBag.SuccessLogin = "Logged in Successfully";
                    menu.MenuName = "MasterScreen";
                    menu.Action = "Index";
                    menu.ControllerName = "Crud";

                    return RedirectToAction("Contact", "Home", new { area = "Ravi" });

                }
                else if (registration.ValidateUser(user, out userModel) == "Unauthorized Role")
                {

                    menu.MenuName = "MyProfile";
                    menu.Action = "Details";
                    menu.ControllerName = "Crud";
                }
            }
            return View();
        }

        public ActionResult MyProfile()
        {
            return View();
        }
    }
}
