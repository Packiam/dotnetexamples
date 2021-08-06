using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class HomeController : Controller
    {
        // GET: Guru/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}