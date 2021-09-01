using MVC.Samples.BLL.Interfaces.Ravi;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using MVC.Samples.Data.Models.Ravi;
using MVC.Samples.Web.Areas.Ravi.Helper;
using MVC.Samples.Web.Areas.Ravi.Models;
using MVC.Samples.Web.Controllers;
using MVC.Samples.Web.Models;
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
            UserRegistration userModel = null;
            string message = registration.ValidateUser(user, out userModel);
            if (!string.IsNullOrEmpty(message)) { ViewBag.Message = message; return View(); }
            Session["Role"] = userModel.Role;
            Session["User_Name"] = user.Name;
            if (userModel.Role == "Admin")
            {
                SessionHandler.AddRoleSession(new MenuModel()
                {
                    MenuName = "MasterScreen",
                    Action = "Index",
                    ControllerName = "Crud"
                });
            }
            else if (userModel.Role == "EndUser")
            {
                SessionHandler.AddRoleSession(new MenuModel()
                {
                    MenuName = "MyProfile",
                    Action = "Details",
                    ControllerName = "Crud"
                });
            }
            
            return RedirectToAction("Contact", "Home", new { area = "Ravi" });
        }
    }
}