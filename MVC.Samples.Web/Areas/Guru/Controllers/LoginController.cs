using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Areas.Guru.Controllers
{
    public class LoginController : Controller
    {
        // GET: Guru/LogIn
        public ActionResult Index()
        {
            return View();
        }
    }
}