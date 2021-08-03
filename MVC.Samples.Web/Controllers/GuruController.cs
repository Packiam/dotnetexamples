using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Samples.Web.Models;

namespace MVC.Samples.Web.Controllers
{
    public class GuruController : Controller
    {
        // GET: Guru
        [HttpGet]
        public ActionResult Index()
        {
            UserModel userModel;
            try
            {
                userModel = new UserModel();
                userModel.CityList = GetCityList();
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

    }
}