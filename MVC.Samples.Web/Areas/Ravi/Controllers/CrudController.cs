using MVC.Samples.BLL.Interfaces.Ravi;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Controllers;
using MVC.Samples.Web.Areas.Ravi.Helper;
using MVC.Samples.Web.Models;

namespace MVC.Samples.Web.Areas.Ravi.Controllers
{
    public class CrudController : BaseController
    {
        MyDatabase myDatabase = new MyDatabase();
        private readonly IRegistration registration;

        public CrudController(IRegistration registration)
        {
            this.registration = registration;
        }

        // GET: Ravi/Crud

        public ActionResult Index()
        {
            try
            {
                return View(myDatabase.userRegistrations.ToList());
            }
            catch (Exception ex)
            {
                //Log the errors
                ViewBag.Message = "Sorry, Some error occured while processing Main page.";
                return ErrorView(ex);
            }
        }

        public ActionResult Create()
        {
            if (!Session.IsNewSession) { Session.Clear(); }
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRegistration objEmp)
        {
            try
            {
                string message = registration.BasicValidations(objEmp);
                if (message != "") { ViewBag.ErrorMessage = message; return Json(new { Status = false, Message = message }); }
                Session["Role"] = objEmp.Role;
                Session["User_Name"] = objEmp.Name;
                registration.SaveUser(objEmp);

                if (objEmp.Role == "Admin")
                {
                    SessionHandler.AddRoleSession(new MenuModel()
                    {
                        MenuName = "MasterScreen",
                        Action = "Index",
                        ControllerName = "Crud"
                    });
                    SessionHandler.AddRoleSession(new MenuModel()
                    {
                        MenuName = "MyProfile",
                        Action = "Details",
                        ControllerName = "Crud"
                    });

                }
                else if (objEmp.Role == "EndUser")
                {
                    SessionHandler.AddRoleSession(new MenuModel()
                    {
                        MenuName = "MyProfile",
                        Action = "Details",
                        ControllerName = "Crud"
                    });
                }
                return Json(new { Status = true, result = "Redirect", url = Url.Action("About", "Home", new { area = "Ravi" }) });
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message, result = "Redirect", url = Url.Action("About", "Home", new { area = "Ravi" }) });
            }
            finally
            {

            }
        }

        public ActionResult Details(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = myDatabase.userRegistrations.Find(empId);
            return View(emp);
        }

        public ActionResult Edit(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = myDatabase.userRegistrations.Find(empId);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(UserRegistration userReg)
        {
            registration.UpdateUser(userReg);
            return RedirectToAction("Details", "Crud", new { area = "Ravi", id = userReg.Id });
        }

        public ActionResult Delete(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = myDatabase.userRegistrations.Find(empId);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(string id, UserRegistration userReg)
        {
            try
            {
                int empId = Convert.ToInt32(id);
                var emp = myDatabase.userRegistrations.Find(empId);
                myDatabase.userRegistrations.Remove(emp);
                myDatabase.SaveChanges();
                return RedirectToAction("Index", "Login", new { area = "Ravi" });
            }
            catch (Exception err)
            {
                return ErrorView(err);
            }

        }
    }
}