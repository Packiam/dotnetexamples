using MVC.Samples.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Controllers
{
    public class RaviController : Controller
    {
        // GET: Ravi
        [HttpGet]
        public ActionResult Index()
        {
            RaviUserModel raviuserModel = new RaviUserModel();
            raviuserModel.CityList = GetCityList();
            return View(raviuserModel);
        }


        [HttpPost]
        public ActionResult Index(RaviUserModel raviuser)
        {
            raviuser.CityList = GetCityList();
            //DB Store the data.
            return View(raviuser);
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