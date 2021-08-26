
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using MVC.Samples.Web.Models;

namespace MVC.Samples.Web.Controllers
{
    public class HomeController : BaseController
    {  
        
        // GET: /Home/
        [HttpGet]
        public ActionResult Index(string id, string name)
        {
            UserModel userModel;
            try
            {
                userModel = new UserModel();
                userModel.CityList = GetCityList();
                ViewBag.MyData = "Packiam Jepakumar...";
                TempData["mytempdata"] = "My Sample data...";
                return View(userModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                userModel = null;
            }
        }

        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            user.CityList = GetCityList();
            //DB Store the data.
            return View(user);
        }
        private List<SelectListItem> GetCityList()
        {
            List<SelectListItem> cityList = new List<SelectListItem>();
            cityList.Add(new SelectListItem() { Text = "Tirunelveli", Value = "TEN" });
            cityList.Add(new SelectListItem() { Text = "Tuticorin", Value = "TUT" });
            cityList.Add(new SelectListItem() { Text = "Theni", Value = "THE" });
            return cityList;
        }

        public ActionResult Index1()
        {
            Console.WriteLine("I am working from Index - 1");
            return View();
        }

        public ActionResult About(String name)
        {
            ViewBag.SuccessMessage = "Welcome" +" "+ name;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string val1 = TempData["MyData"]?.ToString();
            string session = Session["Session_MyData"]?.ToString();
            return View();
        }
    }
}