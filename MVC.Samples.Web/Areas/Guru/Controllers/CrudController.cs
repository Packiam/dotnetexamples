using MVC.Samples.BLL.Interfaces.Guru;
using MVC.Samples.BLL.Services.Guru;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using MVC.Samples.Web.Helper;
using MVC.Samples.Web.Controllers;
using MVC.Samples.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class CrudController : BaseController
    {
        MyDatabase myDatabase = new MyDatabase();
        private readonly IRegistration registration;
        public CrudController(IRegistration registration)
        {
            //this.registration = new RegistrationService();
            this.registration = registration;
        }

        // GET: Guru/Crud
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
                return View("Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRegistration objEmp)
        {
            try
            {
                /*
                 * 1. Username mandatory.
                 * 2. Password mandatory.
                 * 3. Code, Name mandatory.
                 * 4. Role Mandatory.
                 * 5. Password and Confirm password has to be equal.
                 * 6. Code duplication issue
                 * 7. Username duplication.
                */
                string message = registration.BasicValidations(objEmp);
                if (message != "") { ViewBag.ErrorMessage = message; return View(objEmp); }

                registration.SaveUser(objEmp);
                UserSessionHandler.ClearUserSession();

                if (objEmp.Role == "Admin")
                {
                    UserSessionHandler.AddRoleSession(new MenuModel()
                    {
                        MenuName = "MasterScreen",
                        Action = "Index",
                        ControllerName = "Crud"
                    });
                }
                else if (objEmp.Role == "EndUser")
                {
                    UserSessionHandler.AddRoleSession(new MenuModel()
                    {
                        MenuName = "MyProfile",
                        Action = "Details",
                        ControllerName = "Crud"
                    });
                }
                return RedirectToAction("About", "Home", new { area = "Guru", name = objEmp.Name });

                //string name = objEmp.Name;
                //string role = objEmp.Role;
                //string empCode = objEmp.EmpCode;
                //MenuModel menu = new MenuModel();
                //if (role == "Admin"|| role=="EndUser")
                //{
                //    menu.MenuName = "MasterScreen";
                //    menu.Action = "Index";
                //    menu.ControllerName = "Crud";
                //    UserSessionHandler.AddRoleSession(menu);
                //}
                //else
                //{
                //    menu.MenuName = "MyProfile";
                //    menu.Action = "Details";
                //    menu.ControllerName = "Crud";
                //    UserSessionHandler.AddRoleSession(menu);
                //}

                //if (!string.IsNullOrEmpty(message))
                //{
                //    if (!string.IsNullOrEmpty(errorMessage))
                //    {
                //        if (registration.UserNameValidation(name) && registration.EmpCodeValidation(empCode))
                //        {
                //            Session["User_Name"] = objEmp.Name;
                //            registration.SaveUser(objEmp);
                //            return RedirectToAction("About", "Home", new { area = "Guru" ,name=objEmp.Name});
                //        }
                //        else { ViewBag.Error = "User Name or employee code already exit"; }
                //    }
                //    else { ViewBag.Message = "Password Should be minimum 4 and not null"; return View(); }
                //}
                //else { ViewBag.ErrorMessage = "Age should be above 18 and below 100"; return View(); }
                //return View();
            }
            catch (Exception err)
            {
                return ErrorView(err);
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
            return RedirectToAction("Details", "Crud", new { area = "Guru", id = userReg.Id });
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
                return RedirectToAction("Index", "Login", new { area = "Guru" });
            }
            catch (Exception err)
            {
                return ErrorView(err);
            }

        }

    }
}