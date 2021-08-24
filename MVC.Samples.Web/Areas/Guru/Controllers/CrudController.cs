using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class CrudController : Controller
    {
        MyDatabase myDatabase = new MyDatabase();
        // GET: Guru/Crud
        public ActionResult Index()
        {
            return View(myDatabase.userRegistrations.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserRegistration objEmp)
        {
            myDatabase.userRegistrations.Add(objEmp);
            myDatabase.SaveChanges();
            return View();
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
            var data = myDatabase.userRegistrations.Find(userReg.Id);
            if (data != null)
            {
                data.Name = userReg.Name;
                data.Address = userReg.Address;
                data.UserName = userReg.UserName;
                data.Age = userReg.Age;
                data.EmpCode = userReg.EmpCode;
            }
            myDatabase.SaveChanges();
            return View();
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

            int empId = Convert.ToInt32(id);
            var emp = myDatabase.userRegistrations.Find(empId);
            myDatabase.userRegistrations.Remove(emp);
            myDatabase.SaveChanges();

            return View();
        }

    }
}